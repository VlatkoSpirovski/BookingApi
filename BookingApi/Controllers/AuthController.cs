/*
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookingApi.Helpers;
using BookingApi.Models;
using BookingApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Add this using directive
using Microsoft.IdentityModel.Tokens;

namespace BookingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly EmailService _emailService;
    private readonly IConfiguration _configuration;
    private readonly AuthHelpers _helper;
    public AuthController(
        UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, 
        EmailService emailService,
        IConfiguration configuration,
        AuthHelpers authHelper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _configuration = configuration;
        _helper = authHelper;
    }

    [AllowAnonymous]
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel1 model1)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new IdentityUser { UserName = model1.Email, Email = model1.Email };
        var result = await _userManager.CreateAsync(user, model1.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new { message = "Registration failed" });
        }

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, token }, Request.Scheme);

        // Send confirmation email
        var emailSubject = "Please confirm your email address";
        var emailMessage = $"Please confirm your account by clicking this link: <a href='{confirmationLink}'>link</a>";
        await _emailService.SendEmailAsync(user.Email, emailSubject, emailMessage);

        return Ok(new { message = "Registration successful. Please confirm your email." });
    }

    [AllowAnonymous]
    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginModel1 model1)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var user = await _userManager.FindByEmailAsync(model1.Email);
        if (user == null)
        {
            return Unauthorized(new { message = "Invalid credentials for the Email" });
        }
        
        var result = await _signInManager.PasswordSignInAsync(user, model1.Password, false, false);
        if (!result.Succeeded)
        {
            return Unauthorized(new { message = "Invalid credentials for the Password" });
        }
        
        return Ok(new { token = _helper.GenerateJWTToken(user)});
    }

    [HttpGet("confirmemail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return Ok("Email confirmed successfully.");
        }

        return BadRequest("Email confirmation failed.");
    }

    [HttpGet("/api/users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }


}
*/
