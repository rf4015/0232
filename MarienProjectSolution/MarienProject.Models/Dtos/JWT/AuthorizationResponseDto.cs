using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos.JWT
{
    public class AuthorizationResponseDto
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public bool Result { get; set; }
        public string? Msg { get; set; }
    }
}
