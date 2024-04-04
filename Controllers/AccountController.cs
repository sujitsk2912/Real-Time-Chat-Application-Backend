using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Time_Chat_Application_Backend.Database;


namespace Real_Time_Chat_Application_Backend.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            UserRegistration model = new UserRegistration();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(UserRegistration userLogin)
        {
            try
            {
                AccountDbContext accountDbContext = new AccountDbContext();

                if (ModelState.IsValid)
                {
                    var status = accountDbContext.UserRegistrations.Where(m => m.Username == userLogin.Username && m.Password == userLogin.Password).FirstOrDefault();
                    if (status != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["AlertMessage"] = "Invalid username or password.";
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return View(userLogin);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                AccountDbContext dbContext = new AccountDbContext();

                dbContext.UserRegistrations.Add(userRegistration);
                dbContext.SaveChanges();

                TempData["AlertMessage"] = "User registered successfully";
                return RedirectToAction("Register", "Account");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            return View(userRegistration);
        }

        [HttpGet]
        public IActionResult Forget()
        {
            UserRegistration model = new UserRegistration();
            return View(model);
        }

        [HttpPost]
        public IActionResult Forget(UserRegistration userForget)
        {
            try
            {
                AccountDbContext accountDbContext = new AccountDbContext();

                if (ModelState.IsValid)
                {
                    var user = accountDbContext.UserRegistrations.FirstOrDefault(m => m.Username == userForget.Username);

                    if (user != null)
                    {
                        TempData["AlertMessage"] = $"Your password is: {user.Password}";
                    }
                    else
                    {
                        TempData["AlertMessage"] = "Invalid username.";
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }
            return View(userForget);
        }
    }
}
