using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceManager.Controllers
{
	public class FreelancerController : Controller
	{
		private readonly UserManager<Freelancer> userManager;
		private readonly SignInManager<Freelancer> signInManager;

		public FreelancerController(UserManager<Freelancer> userManager, SignInManager<Freelancer> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(FreelancerRegisterVM modelFromReq)
		{
			if (ModelState.IsValid)
			{
				Freelancer user = new Freelancer();
				user.UserName = modelFromReq.UserName;
				user.Email = modelFromReq.Email;
				user.PasswordHash = modelFromReq.Password;
				user.PhoneNumber = modelFromReq.PhoneNumber;
				IdentityResult result = await userManager.CreateAsync(user, modelFromReq.Password); // saved to database
				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false); // save cookie
					return RedirectToAction("Login");

				}
				else {
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}

				}
			}
			return View("Register", modelFromReq);
		}

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(FreelancerLoginVM modelFromReq)
		{
			if (ModelState.IsValid)
			{
				// check
				Freelancer freelancer = await userManager.FindByNameAsync(modelFromReq.UserName);
				if (freelancer != null) { 
					bool found = await userManager.CheckPasswordAsync(freelancer, modelFromReq.Password);
					if (found)
					{
						await signInManager.SignInAsync(freelancer, modelFromReq.RememberMe);
						return RedirectToAction("Index", "Project");

					}
					else
					{
						ModelState.AddModelError("", "Invalid Account!");
					}
				}
				else
				{
					ModelState.AddModelError("", "UserName or Password is Invalid!");
				}

					return View();
			}
			else
			{
				return RedirectToAction("Login", modelFromReq);
			}

		} 

	}
}
