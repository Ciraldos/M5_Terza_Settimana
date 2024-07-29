using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.D1.EntityFramework.DataModel
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public required string Title { get; set; }
        [StringLength(2048)]
        public required string Content { get; set; }
        public required Author Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
