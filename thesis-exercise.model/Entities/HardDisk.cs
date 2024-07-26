using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class HardDisk
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Size { get; set; } = null!;

    public int SizeTypeId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();

    public virtual SizeType SizeType { get; set; } = null!;
}
