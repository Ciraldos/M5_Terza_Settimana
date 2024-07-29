using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9_ProgettoSettimanale.Models
{
    public class Roles
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nome del ruolo.
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        /// <summary>
        /// Utenti che appartengono al ruolo.
        /// </summary>
        public List<Users> Users { get; set; } = [];
    }
}
