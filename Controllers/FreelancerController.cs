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
				IdentityResult result = await userManager.CreateAsync(user); // saved to database
				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false); // save cookie
					return RedirectToAction("Index", "Project");

				}
				else {
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				
				}
			}
			return View("Register",modelFromReq);
		}
	}
}
