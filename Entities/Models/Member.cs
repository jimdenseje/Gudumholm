using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;

namespace Entities.Models
{
    public class Member
    {
        public Member() { }

        [SetsRequiredMembers]
        public Member(string Name, string CPR, MemberType MemberType, Household Household) =>
            (this.Name, this.CPR, this.MemberType, this.Household) = (Name, CPR, MemberType, Household);

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(11)]
        public required string CPR { get; set; }

        [Required]
        public required virtual MemberType MemberType { get; set; }

        [Required]
        public required virtual Household Household { get; set; }

        public virtual ICollection<Sport> Sports { get; set; }
               = new List<Sport>();
    }
}
