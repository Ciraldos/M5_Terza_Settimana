using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace W9.Project.DataLayer.Entities;

[Index("Name", Name = "UQ__Roles__737584F6C7B8672F", IsUnique = true)]
public partial class Role
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
}
