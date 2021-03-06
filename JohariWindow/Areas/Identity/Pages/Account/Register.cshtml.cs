using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace JohariWindow.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager< ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        //added role manager
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private Client ClientObj { get; set; }

        private Friend FriendObj { get; set; }

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,// added role manager
            RoleManager<IdentityRole> roleManager,IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            // added role manager
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
             
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        [BindProperty]
        public List<string> Roles { get; set; }
       
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            //ADDED THESE LINES
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            
           public string PhoneNumber { get; set; }

            ////added this after changing users to identity
         
            public DateTime DOB { get; set; }
          
             public string Gender { get; set; }

        }
        public int userCount;
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            userCount = _unitOfWork.ApplicationUser.List().Count();
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
           
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //retrieve the role from the form
            string role = Request.Form["rdUserRole"].ToString();
            if (role == "") { role = SD.AdminRole; }
          
                //make the first login a manager)
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //expand identityuser with applicationuser properties
             
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber,
                    DOB=Input.DOB,
                    Gender=Input.Gender
              

                };

                var result = await _userManager.CreateAsync(user, Input.Password);

             
                //add the roles to the ASPNET Roles table if they do not exist yet
                if (!await _roleManager.RoleExistsAsync(SD.AdminRole))
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.AdminRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.ClientRole)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.FriendRole)).GetAwaiter().GetResult();
                  
                }
                if (result.Succeeded)
                {
                    //assign role to the user (from the form radio options available after the first manager is created)
                    if (role == SD.ClientRole)
                    {
                        await _userManager.AddToRoleAsync(user, SD.ClientRole);
                    }
                    else
                    {
                        if (role == SD.FriendRole)
                        {
                            await _userManager.AddToRoleAsync(user, SD.FriendRole);
                        }
                        else
                        {
                            if (role == SD.AdminRole)
                            {
                              
                                await _userManager.AddToRoleAsync(user, SD.AdminRole);
                            }
                            
                        }
                    }
                    _logger.LogInformation("User created a new account with password.");
                    //add to client table
                    if (role==SD.ClientRole)
                    {
                        ClientObj = new Client
                        {
                            ASPNETUserID = user.Id,
                            DOB = Input.DOB,
                            FirstName = Input.FirstName,
                            LastName = Input.LastName,
                            Gender = Input.Gender


                        };
                        _unitOfWork.Client.Add(ClientObj);
                    }
                   
                    if(role==SD.FriendRole)
                    {
                        FriendObj = new Friend
                        {
                            ASPNETUserID = user.Id,
                          Relationship="",
                          HowLong="",
                           


                        };
                        _unitOfWork.Friend.Add(FriendObj);
                        Console.WriteLine(" user created " + user.Id);
                    }
                    
                   
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }



    }
}
