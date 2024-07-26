using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class UsbPort
{
    public int Id { get; set; }

    public string? Version { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<ComputerUsbPort> ComputerUsbPorts { get; set; } = new List<ComputerUsbPort>();
}
