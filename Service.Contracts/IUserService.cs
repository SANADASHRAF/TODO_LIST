using Shared;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUserService
    {
        // register
        Task<ServiceResponse<RegisterUserResponseDto>> RegisterAsync(RegisterUserDto dto);

        // login
        Task<ServiceResponse<UserLoginResponseDto>> LoginAsync(UserLoginDto dto);

        // email verification
        Task<ServiceResponse<string>> SendCode(ForgetPasswordDto dto);
        Task<ServiceResponse<string>> VerifyResetCodeAsync(VerifyResetCodeDto dto);
    }
}
