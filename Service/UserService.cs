using AutoMapper;
using Contract;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public UserService(IRepositoryManager repository, IMapper mapper, IConfiguration configuration, IEmailService emailService)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
            _emailService = emailService;
        }


          #region register

             public async Task<ServiceResponse<RegisterUserResponseDto>> RegisterAsync(RegisterUserDto dto)
             {
                try
                {
                    var existingUser = await _repository.User.GetByEmailAsync(dto.Email, trackChanges: false);
                    if (existingUser != null)
                        return new ServiceResponse<RegisterUserResponseDto>(false, "البريد الإلكتروني مستخدم بالفعل", null);

                    var user = _mapper.Map<User>(dto);

                    _repository.User.CreateUser(user);
                    _repository.Save();

                    var userProfileDto = _mapper.Map<RegisterUserResponseDto>(user);

                    return new ServiceResponse<RegisterUserResponseDto>(true, "تم التسجيل بنجاح", userProfileDto);
                }
                catch (Exception ex)
                {
                    return new ServiceResponse<RegisterUserResponseDto>(false, ex.Message, null);
                }
             }


        #endregion


        #region login

        public async Task<ServiceResponse<UserLoginResponseDto>> LoginAsync(UserLoginDto dto)
        {
            try
            {
                var user = await _repository.User.GetByEmailAsync(dto.Email, trackChanges: false);
                if (user == null || user.Password != dto.Password)
                    return new ServiceResponse<UserLoginResponseDto>(false, "البريد الإلكتروني أو كلمة المرور غير صحيحة", null);

                var token = GenerateJwtToken(user);
                var userProfileDto = _mapper.Map<UserLoginResponseDto>(user);
                userProfileDto.token = token;

                return new ServiceResponse<UserLoginResponseDto>(true, "تم تسجيل الدخول بنجاح", userProfileDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UserLoginResponseDto>(false, ex.Message, null);
            }
        }

        private string GenerateJwtToken(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Username", user.Username),
                        new Claim("Email", user.Email),
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(2),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating JWT token: " + ex.Message);
            }
        }

        #endregion


        #region email verification
          
            public async Task<ServiceResponse<string>> SendCode(ForgetPasswordDto dto)
            {
                try
                {

                    var userEmailVerifications = new EmailVerifications();
                   
                    var resetToken = new Random().Next(1000, 10000).ToString();
                    userEmailVerifications.ResetToken = resetToken;
                    userEmailVerifications.Email = dto.Email;
                    userEmailVerifications.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(3);

                    _repository.EmailVerifications.CreateEmailVerifications(userEmailVerifications);
                    _repository.Save();


                    var emailSubject = "تاكيد البريد الإلكترونى!";
                    var emailMessage = $"الرجاء استخدام الرمز التالي لتاكيد البريد الالكترونى: {resetToken}";

                    var emailSent = await _emailService.SendEmailAsync(dto.Email, emailSubject, emailMessage);
                    if (!emailSent)
                        return new ServiceResponse<string>(false, "فشل إرسال البريد الإلكتروني");

                    return new ServiceResponse<string>(true, "تم إرسال رمز تاكيد البريد إلى بريدك الإلكتروني", null);
                }
                catch (Exception ex)
                {
                    return new ServiceResponse<string>(false, ex.Message, null);
                }
            }


        public async Task<ServiceResponse<string>> VerifyResetCodeAsync(VerifyResetCodeDto dto)
        {
            try
            {
                var user = await _repository.EmailVerifications.GetByEmailAsync(dto.Email, trackChanges: false);
                if (user == null)
                    return new ServiceResponse<string>(false, "لم يتم ارسال الكود", null);

                if (user.ResetToken != dto.Code && user.IsVerified == false)
                    return new ServiceResponse<string>(false, "الرمز غير صحيح", null);

                if (user.ResetTokenExpiry == null || user.ResetTokenExpiry < DateTime.UtcNow)
                {
                    user.IsVerified = true;
                    return new ServiceResponse<string>(false, "انتهت صلاحية الرمز", null);
                }
                user.IsVerified = true;
                return new ServiceResponse<string>(true, "الرمز صحيح", null);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>(false, ex.Message, null);
            }
        }

        #endregion
    }
}
