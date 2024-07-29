using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace W9.Project.DataLayer.Entities;

[Index("Email", Name = "UQ__Users__A9D10534BF460FE6", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(80)]
    public string Email { get; set; } = null!;

    [StringLength(128)]
    public string Password { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
