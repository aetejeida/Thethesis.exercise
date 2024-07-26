using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class ComputerMemory
{
    public int Id { get; set; }

    public int ComputerId { get; set; }

    public int MemoryId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Computer Computer { get; set; } = null!;

    public virtual Memory Memory { get; set; } = null!;
}
