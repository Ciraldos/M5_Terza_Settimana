using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace W9.Project.DataLayer.Entities;

[Index("UserId", "RoleId", Name = "UK_UsersRoles", IsUnique = true)]
public partial class UsersRole
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("UsersRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UsersRoles")]
    public virtual User User { get; set; } = null!;
}
