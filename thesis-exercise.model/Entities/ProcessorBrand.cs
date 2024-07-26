using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class ProcessorBrand
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<Processor> Processors { get; set; } = new List<Processor>();
}
