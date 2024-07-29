using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9_ProgettoSettimanale.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Users
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nome utente.
        /// </summary>
        [Required]
        [StringLength(20)]
        public required string Name { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [StringLength(20)]
        public required string Password { get; set; }
        /// <summary>
        /// Ruoli utente.
        /// </summary>
        public List<Roles> Roles { get; set; } = [];
        /// <summary>
        /// Tutti gli ordini di un utente.
        /// </summary>
        public List<Orders> Orders { get; set; } = [];
    }

}