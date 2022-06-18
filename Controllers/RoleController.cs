using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concord_Cougars_Course_Project.Models;
using Concord_Cougars_Course_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Concord_Cougars_Course_Project.Controllers
{
    public class RoleController : Controller
    {
        SwimSchoolDbContext db;
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public RoleController(SwimSchoolDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult AllRole()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(IdentityRole role)
        {
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("AllRole");
            }
            return View();
        }
        public async Task<IActionResult> AddUserRole(string id)
        {
            var roleDisplay = db.Roles.Select(x => new { Id = x.Id, Value = x.Name }).ToList();
            RoleAddUserRoleViewModel vm = new RoleAddUserRoleViewModel();
            var user = await userManager.FindByIdAsync(id);
            vm.User = user;
            vm.RoleList = new SelectList(roleDisplay, "Id", "value");
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserRole (RoleAddUserRoleViewModel vm)
        {
            var user = await userManager.FindByIdAsync(vm.User.Id);
            var role = await roleManager.FindByIdAsync(vm.Role);
            var result = await userManager.AddToRoleAsync(user, role.Name);
            if(result.Succeeded)
            {
                return RedirectToAction("AllUsers", "Account");

            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            var roleDisplay = db.Roles.Select(x => new { Id = x.Id, value = x.Name }).ToList();
            vm.User = user;
            vm.RoleList = new SelectList(roleDisplay, "Id", "Value");
            return View(vm);
        }
    }
}
