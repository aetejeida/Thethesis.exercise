using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class Memory
{
    public int Id { get; set; }

    public int Size { get; set; }

    public int SizeTypeId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();

    public virtual SizeType SizeType { get; set; } = null!;
}
