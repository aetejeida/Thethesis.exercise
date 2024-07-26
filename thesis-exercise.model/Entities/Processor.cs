using System;
using System.Collections.Generic;

namespace thesis_exercise.data;

public partial class Processor
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string Model { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual ProcessorBrand Brand { get; set; } = null!;

    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();
}
