using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class EmailVerifications
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public bool IsVerified { get; set; } = false;

    }
}
