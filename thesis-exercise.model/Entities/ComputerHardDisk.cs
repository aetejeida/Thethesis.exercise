using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class ComputerHardDisk
{
    public int Id { get; set; }

    public int ComputerId { get; set; }

    public int HardDiskId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Computer Computer { get; set; } = null!;

    public virtual HardDisk HardDisk { get; set; } = null!;
}
