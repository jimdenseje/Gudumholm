using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using Entities.Models;

namespace Entities.DTOs
{
    public class MemberReadDTO
    {
        public required string Name { get; set; }
        public required virtual MemberType MemberType { get; set; }
        public required virtual Household Household { get; set; }

        public virtual ICollection<Sport> Sports { get; set; }
               = new List<Sport>();
    }
}
