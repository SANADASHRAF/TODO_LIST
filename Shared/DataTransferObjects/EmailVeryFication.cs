using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{

    public record ForgetPasswordDto
    {
        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "يجب إدخال بريد إلكتروني صالح")]
        public string Email { get; set; }
    }


    public record VerifyResetCodeDto
    {

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "يجب إدخال بريد إلكتروني صالح")]
        public string Email { get; set; }

        [Required(ErrorMessage = "الرمز مطلوب")]
        public string Code { get; set; }
    }
}
