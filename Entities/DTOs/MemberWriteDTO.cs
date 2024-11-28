using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using Entities.Models;

namespace Entities.DTOs
{
    public class MemberWriteDTO
    {

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(11)]
        public required string CPR { get; set; }

        public virtual MemberType? MemberType { get; set; }

        public int? MemberTypeId { get; set; }

        public virtual Household? Household { get; set; }

        public int? HouseholdId { get; set; }

        public virtual ICollection<Sport> Sports { get; set; }
               = new List<Sport>();
    }
}
