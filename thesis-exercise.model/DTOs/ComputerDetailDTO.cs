namespace thesis_exercise.model.DTOs
{
    public class ComputerDetailDTO
    {
        public int ComputerId { get; set; }
        public string Memory { get; set; }
        public string DiskSpace { get; set; }
        public string Processor { get; set; }

        public string UsbPorts { get; set; }
    }
}
