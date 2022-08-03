using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using Project2.ModelView;

namespace Project2.Controllers
{
    [Authorize]

    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUsers> _userManager;
        private readonly RoleManager<AppRoles> _Rol;
        public UsersController(ApplicationDbContext context, UserManager<AppUsers> userManager, RoleManager<AppRoles> rol)
        {
            _context = context;
            _userManager = userManager;
            _Rol = rol;
        }
        public  async Task<IActionResult> Index()

        {
            var users = _context.Users;    
            
            return View(await users.ToListAsync());
        }

        public async Task<IActionResult> showUsers( )
        {
            var users = _context.Users;

            return View(await users.ToListAsync());
        }

        public async Task<IActionResult> editRol(string? id)

        {
            if (id==null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);  
            if (user==null)
            {
                return NotFound();
            }

            ViewData["name"] = user.FirstName;
            ViewData["id"] = user.Id;
            ViewData["rolData"] = new SelectList(_Rol.Roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> editRol(string userId,string rolName)

        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
           await _userManager.AddToRoleAsync(user, rolName);
            return  RedirectToAction("index");
        }
            public async Task<IActionResult> setup()
        {
           await _Rol.CreateAsync(new AppRoles { Name = "admin" });
            await _Rol.CreateAsync(new AppRoles { Name = "support" });
            await _Rol.CreateAsync(new AppRoles { Name = "member" });
            if (await _userManager.FindByNameAsync("admin@taifedu.sa") == null)
            {
                var user = new AppUsers  { FirstName = "فيصل", LastName = "عائض", UserName = "fv99xz@hotmail.com", Email = "fv99xz@hotmail.com" };
                await _userManager.CreateAsync(user, "Faisal1420!");
                await _userManager.AddToRoleAsync(user, "admin");
              
            }


            return Content("تمت بنجاح");  
        }

    }
}
