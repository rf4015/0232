using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos.Actions
{
    public class CustomerActionsDto
    {
        public string FirstNames { get; set; } = null!;

        public string LastNames { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        //public int UserId { get; set; }

        //public bool? State { get; set; }
    }
}
