using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class SizeType
{
    public int Id { get; set; }

    public string? TypeCode { get; set; }

    public string? TypeName { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<HardDisk> HardDisks { get; set; } = new List<HardDisk>();

    public virtual ICollection<Memory> Memories { get; set; } = new List<Memory>();
}
