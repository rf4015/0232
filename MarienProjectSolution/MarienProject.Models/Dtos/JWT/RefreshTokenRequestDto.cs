using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos.JWT
{
    public class RefreshTokenRequestDto
    {
        public string? TokenExpired { get; set; }
        public string? RefreshToken { get; set; }
    }
}
