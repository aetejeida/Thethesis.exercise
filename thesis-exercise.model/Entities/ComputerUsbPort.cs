using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class ComputerUsbPort
{
    public int Id { get; set; }

    public int ComputerId { get; set; }

    public int UsbPortId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Computer Computer { get; set; } = null!;

    public virtual UsbPort UsbPort { get; set; } = null!;
}
