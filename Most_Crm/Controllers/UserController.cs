using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Most_Crm.Data;
using Most_Crm.DTO;
using Most_Crm.Models;

namespace CrmProjesi.Controllers
{
    public class UserController : Controller
    {
        private readonly CRMDbContext _context;

        public UserController(CRMDbContext context)
        {
            _context = context;
        }

        // Kayıt ol (GET)
        public IActionResult Register()
        {
            return View();
        }

        // Kayıt ol (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
                {
                    ModelState.AddModelError("Email", "Bu e-posta zaten kayıtlı.");
                    return View(userDto);
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password), // Hash işlemi burada
                    IsConfirmed = false
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View(userDto);
        }


        // Giriş yap (GET)
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserDTO userDto)
        {
            if (!ModelState.IsValid)
                return View(userDto);

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash)) // Hash karşılaştırma
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı veya bilgiler hatalı.");
                return View(userDto);
            }

            var internalEmails = new List<string>
            {
          "info@mostidea.com.tr"
    
             };


            if (!internalEmails.Contains(user.Email.ToLower()) && !user.IsConfirmed)
            {
                if (!string.IsNullOrEmpty(user.RejectionReason))
                {
                    ModelState.AddModelError("", $"Hesabınız reddedildi.<br> Sebep: {user.RejectionReason}");
                }
                else
                {
                    ModelState.AddModelError("", "Hesabınız henüz onaylanmamış.");
                }

                return View(userDto);
            }


            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.FullName),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);


            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,authProperties);

            TempData["LoginSuccess"] = $"Giriş başarılı. Hoş geldiniz, {user.FullName}!";

            return RedirectToAction("Index", "Dashboard");
        }


        // Çıkış Yap Sayfası (GET)
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        // Çıkış işlemini yapan metod (POST)
        [HttpPost, ActionName("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutConfirmed()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // Kullanıcıları Onayla (GET)
        public async Task<IActionResult> ApproveUser()
        {
            var unconfirmedUsers = await _context.Users.Where(u => !u.IsConfirmed).ToListAsync();
            return View(unconfirmedUsers);
        }

        // Kullanıcı onaylama işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.IsConfirmed = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ApproveUser));
        }

        // Kullanıcı reddetme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectUser(int id, string reason)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.IsConfirmed = false;
            user.RejectionReason = reason; //  Sebep burada saklanıyor

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ApproveUser));
        }

    }
}

