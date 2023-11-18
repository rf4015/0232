using System.ComponentModel.DataAnnotations;

namespace MarienProject.Api.Models.CustomModels
{
    public partial class AllCustomerData
    {
        [Key]
        public int Id { get; set; }
        public string FirstNames { get; set; } = null!;

        public string LastNames { get; set; } = null!;

        public string? Phone { get; set; } = null!;

        public string? EmailAddress { get; set; } = null!;

        public string? Address { get; set; } = null!;

        public string? MunicipalityName { get; set; }

        public string? CityName { get; set; }

        public string? Residence { get; set; } = null!;

        public string? PostalCode { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }

        public bool State { get; set; }
    }
}
