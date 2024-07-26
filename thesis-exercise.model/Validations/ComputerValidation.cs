using FluentValidation;
using thesis_exercise.model.DTOs;

namespace thesis_exercise.model.Validations
{
    public class ComputerValidation : AbstractValidator<ComputerDTO>
    {
        public ComputerValidation() 
        {
            RuleFor(x => x.ProcessorId).NotNull().NotEmpty();
            RuleFor(x => x.HardDiskId).NotNull().NotEmpty();
            RuleFor(x => x.MemoryId).NotNull().NotEmpty();
        }
    }
}
