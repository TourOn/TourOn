﻿using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TourOn.Models;
using System.Net;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Web.Hosting;

namespace TourOn.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		ApplicationDbContext db = new ApplicationDbContext();
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public AccountController()
		{
		}

		public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// This doesn't count login failures towards account lockout
			// To enable password failures to trigger account lockout, change to shouldLockout: true
			var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(returnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.RequiresVerification:
					return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError("", "Invalid login attempt.");
					return View(model);
			}
		}

		//
		// GET: /Account/VerifyCode
		[AllowAnonymous]
		public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
		{
			// Require that the user has already logged in via username/password or external login
			if (!await SignInManager.HasBeenVerifiedAsync())
			{
				return View("Error");
			}
			return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
		}

		//
		// POST: /Account/VerifyCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// The following code protects for brute force attacks against the two factor codes. 
			// If a user enters incorrect codes for a specified amount of time then the user account 
			// will be locked out for a specified amount of time. 
			// You can configure the account lockout settings in IdentityConfig
			var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(model.ReturnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError("", "Invalid code.");
					return View(model);
			}
		}

		//
		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult RegisterBand()
		{
			var model = new RegisterViewModel();
			return View(model);
		}

		//
		// POST: /Account/RegisterBand
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> RegisterBand(/*[Bind(Exclude = "ProfilePicture")]*/ RegisterViewModel model)
		{

			if (ModelState.IsValid)
			{
                // To convert the user uploaded Photo as Byte Array before save to DB
                //byte[] imageData = null;
                //if (Request.Files.Count > 0)
                //{
                //    HttpPostedFileBase poImgFile = Request.Files["ProfilePicture"];

                //    using (var binary = new BinaryReader(poImgFile.InputStream))
                //    {
                //        imageData = binary.ReadBytes(poImgFile.ContentLength);
                //    }
                //}

                var user = new ApplicationUser
				{
					AccountType = ApplicationUser.BandAccountType,
					Size = model.Size,
					Showcase = model.Showcase,
					UserName = model.Email,
					Email = model.Email,
					Name = model.Name,
					Phone = model.Phone,
					PublicEmail = model.PublicEmail,
					City = model.City,
					State = model.State,
					Genre = model.Genre,
					Region = model.Region
                    //ProfilePicture = imageData
                };

				var result = await UserManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

					// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
					// Send an email with this link
					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction("Index", "Home");
				}
			}
			// If we got this far, something failed, redisplay form
			return View(model);
		}

		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult RegisterVenue()
		{
			var model = new RegisterViewModel();
			return View(model);
		}

		// POST: /Account/RegisterVenue
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> RegisterVenue(/*[Bind(Exclude = "ProfilePicture")]*/ RegisterViewModel model)
		{
			//for venues
			if (ModelState.IsValid)
			{
                // To convert the user uploaded Photo as Byte Array before save to DB
                //byte[] imageData = null;
                //if (Request.Files.Count > 0)
                //{
                //    HttpPostedFileBase poImgFile = Request.Files["ProfilePicture"];

                //    using (var binary = new BinaryReader(poImgFile.InputStream))
                //    {
                //        imageData = binary.ReadBytes(poImgFile.ContentLength);
                //    }
                //}

                var user = new ApplicationUser
				{
					AccountType = ApplicationUser.VenueAccountType,
					Street = model.Street,
					Zip = model.Zip,
					Capacity = model.Capacity,
					Equipment = model.Equipment,
					Parking = model.Parking,
					UserName = model.Email,
					Email = model.Email,
					Name = model.Name,
					Phone = model.Phone,
					PublicEmail = model.PublicEmail,
					City = model.City,
					State = model.State,
					Genre = model.Genre,
					Region = model.Region
                    //ProfilePicture = imageData
                };

				var result = await UserManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

					// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
					// Send an email with this link
					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction("Index", "Home");
				}
			}
			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/ConfirmEmail
		[AllowAnonymous]
		public async Task<ActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return View("Error");
			}
			var result = await UserManager.ConfirmEmailAsync(userId, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");
		}

		//
		// GET: /Account/ForgotPassword
		[AllowAnonymous]
		public ActionResult ForgotPassword()
		{
			return View();
		}

		//
		// POST: /Account/ForgotPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await UserManager.FindByNameAsync(model.Email);
				if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
				{
					// Don't reveal that the user does not exist or is not confirmed
					return View("ForgotPasswordConfirmation");
				}

				// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
				// Send an email with this link
				// string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
				// var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
				// await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
				// return RedirectToAction("ForgotPasswordConfirmation", "Account");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/ForgotPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		//
		// GET: /Account/ResetPassword
		[AllowAnonymous]
		public ActionResult ResetPassword(string code)
		{
			return code == null ? View("Error") : View();
		}

		//
		// POST: /Account/ResetPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await UserManager.FindByNameAsync(model.Email);
			if (user == null)
			{
				// Don't reveal that the user does not exist
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			AddErrors(result);
			return View();
		}

		//
		// GET: /Account/ResetPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ResetPasswordConfirmation()
		{
			return View();
		}

		//
		// POST: /Account/ExternalLogin
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult ExternalLogin(string provider, string returnUrl)
		{
			// Request a redirect to the external login provider
			return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
		}

		//
		// GET: /Account/SendCode
		[AllowAnonymous]
		public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
		{
			var userId = await SignInManager.GetVerifiedUserIdAsync();
			if (userId == null)
			{
				return View("Error");
			}
			var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
			var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
			return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
		}

		//
		// POST: /Account/SendCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> SendCode(SendCodeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			// Generate the token and send it
			if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
			{
				return View("Error");
			}
			return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
		}

		//
		// GET: /Account/ExternalLoginCallback
		[AllowAnonymous]
		public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
		{
			var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
			if (loginInfo == null)
			{
				return RedirectToAction("Login");
			}

			// Sign in the user with this external login provider if the user already has a login
			var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(returnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.RequiresVerification:
					return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
				case SignInStatus.Failure:
				default:
					// If the user does not have an account, then prompt the user to create an account
					ViewBag.ReturnUrl = returnUrl;
					ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
					return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
			}
		}

		//
		// POST: /Account/ExternalLoginConfirmation
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Manage");
			}

			if (ModelState.IsValid)
			{
				// Get the information about the user from the external login provider
				var info = await AuthenticationManager.GetExternalLoginInfoAsync();
				if (info == null)
				{
					return View("ExternalLoginFailure");
				}
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await UserManager.CreateAsync(user);
				if (result.Succeeded)
				{
					result = await UserManager.AddLoginAsync(user.Id, info.Login);
					if (result.Succeeded)
					{
						await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
						return RedirectToLocal(returnUrl);
					}
				}
				AddErrors(result);
			}

			ViewBag.ReturnUrl = returnUrl;
			return View(model);
		}

		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return RedirectToAction("Index", "Home");
		}

		//
		// GET: /Account/ExternalLoginFailure
		[AllowAnonymous]
		public ActionResult ExternalLoginFailure()
		{
			return View();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_userManager != null)
				{
					_userManager.Dispose();
					_userManager = null;
				}

				if (_signInManager != null)
				{
					_signInManager.Dispose();
					_signInManager = null;
				}
			}

			base.Dispose(disposing);
		}


		public ActionResult CurrentUserProfile()
		{
			//get data for profile page's account
			var currentUserID = User.Identity.GetUserId();
			return RedirectToAction("UserProfile", new { userID = currentUserID });
		}

		public ActionResult UserProfile(string userID)
		{
			//get data for profile page's account
			var currentUserID = User.Identity.GetUserId();
			var user = (from u in db.Users
						where u.Id == userID
						select u).FirstOrDefault();
            //var model = new CommentViewModel();
            //model.ApplicationUser = user;
            ////populate comment with an empty comment
            //model.Comment = new Models.Comment {};
            ////set subject of new comments to the current profile
            //model.Comment.SubjectID = user.Id;
            ////populate list of comments to display for current profile
            //model.Comments = (from c in db.Comments
            //                  where c.SubjectID == user.Id
            //                  select c);
            //int thumbsUp = 0;
            //int thumbsDown = 0;
            //foreach (var c in model.Comments)
            //{
            //    if (c.ThumbsUp == true)
            //    {
            //        thumbsUp++;
            //    }
            //    else
            //    {
            //        thumbsDown++;
            //    }
            //}
            //ViewBag.ThumbsUp = thumbsUp;
            //ViewBag.ThumbsDown = thumbsDown;
            ////return data to the partial view
            //return View("_CurrentUserProfile", model);
			var model = new CommentViewModel();
			model.ApplicationUser = user;
			//populate comment with an empty comment
			model.Comment = new Models.Comment { };
			//set subject of new comments to the current profile
			model.Comment.SubjectID = user.Id;
			//populate list of comments to display for current profile
			model.Comments = (from c in db.Comments
							  where c.SubjectID == user.Id
							  select c);
			int thumbsUp = 0;
			int thumbsDown = 0;
			foreach (var c in model.Comments)
			{
				if (c.ThumbsUp == true)
				{
					thumbsUp++;
				}
				else
				{
					thumbsDown++;
				}
			}
			ViewBag.ThumbsUp = thumbsUp;
			ViewBag.ThumbsDown = thumbsDown;

			bool isCurrentUser;
			if (currentUserID == user.Id)
			{
				isCurrentUser = true;
			}
			else
			{
				isCurrentUser = false;
			}

			ViewBag.Editable = isCurrentUser;

			//return data to the partial view
			return View("_UserProfile", model);
		}

		public ActionResult VenueList()
		{
			var venues = (from v in db.Users
							  where v.AccountType == ApplicationUser.VenueAccountType
							  select v);
			return View(venues);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "CommentID,AuthorID,SubjectID,ThumbsUp,CommentHeader,CommentBody")] Comment comment)
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                
                //var userID = User.Identity.GetUserId();
                //comment.Author = (from u in db.Users
                //                    where u.Id == userID
                //                    select u).FirstOrDefault();
                comment.AuthorID = User.Identity.GetUserId();
				comment.Publisher = (from u in db.Users
									 where u.Id == comment.AuthorID
									 select u.Name).FirstOrDefault();
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("UserProfile", new { userID = comment.SubjectID });
            }

            return RedirectToAction("Index", "Home");
        }

        //EDIT PROFILE
        public ActionResult EditProfile()
        {
            var userID = User.Identity.GetUserId();
            var user = (from u in db.Users
                        where u.Id == userID
                        select u).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            if (user.AccountType == 1)
            {
                return View("EditBandProfile", user);
            }
            else if (user.AccountType ==2)
            {
                return View("EditVenueProfile", user);
            }
            return View(user);
        }

        // POST
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Exclude = "ProfilePicture")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                // To convert the user uploaded Photo as Byte Array before save to DB
                byte[] imageData = null;

                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["ProfilePicture"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                        user.ProfilePicture = imageData;
                    }
                }
                if (user.ProfilePicture.Length == 0)
                {
                    string path = HostingEnvironment.ApplicationPhysicalPath + @"images\no-image.jpg";
                    byte[] noImg = System.IO.File.ReadAllBytes(path);
                    user.ProfilePicture = noImg;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CurrentUserProfile","Account",user);
            }
            return View(user);
        }

        public FileContentResult UserPhotos()
        {
            var userID = User.Identity.GetUserId();
            var user = (from u in db.Users
                        where u.Id == userID
                        select u).FirstOrDefault();
            //// to get the user details to load user Image
            //var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            //var userImage = bdUsers.Users.Where(x => x.Id == userID).FirstOrDefault();
            if (user.ProfilePicture == null)
            {
                string path = HostingEnvironment.ApplicationPhysicalPath + @"images\no-image.jpg";
                byte[] noImg = System.IO.File.ReadAllBytes(path);
                user.ProfilePicture = noImg;
            }
            return new FileContentResult(user.ProfilePicture, "image/jpeg");
        }


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}