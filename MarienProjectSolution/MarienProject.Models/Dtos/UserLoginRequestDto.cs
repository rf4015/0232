using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos
{
    public class UserLoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Key { get; set; }
    }
}
