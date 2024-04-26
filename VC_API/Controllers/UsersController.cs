using System.Security.Claims;
using VC_API.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VC_API.Domain.Services.Interfaces;

namespace VC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
    {
        private readonly IUserService _service;
        private readonly ILogger<UsersController> _logger;
        const string NF = "User not found";
        public UsersController(IUserService service, ILogger<UsersController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _service.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("email/{email}")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _service.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        /// <summary>
        /// Registers a user based on the provided user registration data.
        /// </summary>
        /// <param name="request">The user registration data.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the registration operation.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDTO request)
        {
            try
            {
                var user = await _service.Register(request);
                return Ok(new { message = "Registration successful ", user.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Registration failed", error = ex.Message });
            }
        }
        /// <summary>
        /// Logs in a user with the provided email and password.
        /// </summary>
        /// <param name="request">The email and password login details.</param>
        /// <returns>An IActionResult representing the result of the login operation.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(EmailLoginDTO request)
        {
            try
            {
                var token = await _service.Login(request.Email, request.Password, otp);
                if (token == null)
                {
                    return BadRequest(new { message = "Invalid credentials" });
                }
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Login failed", error = ex.Message });

            }
        }
        #region private methods
        private IActionResult NotFound()
        {
            _logger.LogError(NF);
            return NotFound(NF);
        }
        #endregion
    }
}
