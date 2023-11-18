﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstNames { get; set; } = null!;

        public string LastNames { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        //public string Address { get; set; } = null!;

        //public string Residence { get; set; } = null!;

        //public string? PostalCode { get; set; }

        //public int MunicipalityId { get; set; }

        //public int? UserId { get; set; }

        //public int? RoleId { get; set; }

        public bool? State { get; set; }

        //public string RolName { get; set; } = null!;

        //public  string UserName { get; set; } = null!;

        //public string UserPassword { get; set; } = null!;

        //public byte[]? ProfileImage { get; set; }
    }
}
