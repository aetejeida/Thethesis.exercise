using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class Computer
{
    public int Id { get; set; }

    public int ProcessorId { get; set; }

    public int MemoryId { get; set; }

    public int HardDiskId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<ComputerUsbPort> ComputerUsbPorts { get; set; } = new List<ComputerUsbPort>();

    public virtual HardDisk HardDisk { get; set; } = null!;

    public virtual Memory Memory { get; set; } = null!;

    public virtual Processor Processor { get; set; } = null!;
}
