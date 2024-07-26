namespace thesis_exercise.model.DTOs
{
    public class ComputerDTO
    {
        public int Id { get; set; }
        public int HardDiskId { get; set; }
        public int MemoryId { get; set; }
        public int ProcessorId { get; set; }
        public IList<int> UsbPortsIds { get; set; }
    }
}
