using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class UserLoginDto
    {
        [EmailAddress(ErrorMessage = "enter vaild email")]
        [Required(ErrorMessage = " Email Is Required!")]
        public string Email { get; set; }


        [Required(ErrorMessage = " Password Is Required!")]
        [MinLength(6, ErrorMessage = "length must be in 6:10"), MaxLength(10, ErrorMessage = "length must be in 6:10")]
        public string Password { get; set; }
    }

    public record UserLoginResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? token { get; set; }

    }
}
