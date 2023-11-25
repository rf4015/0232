using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos
{
    public class UserRegisterRequestDto
    {
        [Required]
        public string FirstNames { get; set; }
        [Required]

        public string LastNames { get; set; }
        [Required]

        public string Phone { get; set; }
        [Required]

        public string EmailAddress { get; set; }
        [Required]

        public string Dni { get; set; }
        [Required]
        public int? RoleId { get; set; }
        [Required]
        public bool? State { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string? ProfileImage { get; set; }
    }
}
