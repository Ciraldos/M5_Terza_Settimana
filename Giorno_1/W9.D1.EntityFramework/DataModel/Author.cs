using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.D1.EntityFramework.DataModel
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public required string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public required string LastName { get; set; }
        [StringLength(80, MinimumLength = 5)]
        public required string Email { get; set; }
    }
}