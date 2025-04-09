using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoListAPI.Presentation.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service)
        {
            _service = service;
        }


        #region email verification

            [HttpPost("SendCode")]
            public async Task<IActionResult> SendCode([FromBody] ForgetPasswordDto dto)
            {
                try
                {
                    var response = await _service.UserService.SendCode(dto);
                    return response.Success ? Ok(response) : BadRequest(response);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
                }
            }

        
            [HttpPost("VerifyResetCode")]
            public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCodeDto dto)
            {
                try
                {
                    var response = await _service.UserService.VerifyResetCodeAsync(dto);
                    return response.Success ? Ok(response) : BadRequest(response);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
                }
            }

        #endregion


        #region register

        [HttpPost("register")]
            public async Task<IActionResult> Register([FromForm] RegisterUserDto dto)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest("البيانات المدخلة غير صحيحة");

                    var response = await _service.UserService.RegisterAsync(dto);
                    if (!response.Success)
                        return BadRequest(response);

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
                }
            }

        #endregion


        #region login

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest(new ServiceResponse<UserLoginResponseDto>(false, "البيانات المدخلة غير صحيحة", null));

                    var response = await _service.UserService.LoginAsync(dto);
                    return response.Success ? Ok(response) : BadRequest(response);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new ServiceResponse<string>(false, ex.Message, null));
                }
            }

        #endregion


    }
}
