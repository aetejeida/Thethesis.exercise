using thesis_exercise.model.DTOs;

namespace thesis_exercise.Tests.TestCases
{
    public class InitialObjectTestCases
    {
        public static IEnumerable<IList<ComputerDTO>> LoadCamputersObject()
        {
            yield return new List<ComputerDTO>()
            {
                new ComputerDTO()
                {
                    HardDiskId = 1,
                    MemoryId = 1,
                    ProcessorId = 1,
                    UsbPortsIds = new List<int> { 1, 2 }
                },
                  new ComputerDTO()
                {
                    HardDiskId = 2,
                    MemoryId = 3,
                    ProcessorId = 4,
                    UsbPortsIds = new List<int> { 1, 2,2,3,2,1,2,1,3,3 }
                },  new ComputerDTO()
                {
                    HardDiskId = 5,
                    MemoryId = 2,
                    ProcessorId = 1,
                    UsbPortsIds = new List<int>()
                },
                  new ComputerDTO()
                {
                    HardDiskId = 8,
                    MemoryId = 4,
                    ProcessorId = 6,
                    UsbPortsIds = new List<int> { 1, 2,2,3,2,1,2,1,3,3,1,2,3,1,2,1,3 }
                },  new ComputerDTO()
                {
                    HardDiskId = 6,
                    MemoryId = 2,
                    ProcessorId = 8,
                    UsbPortsIds = new List<int> { 1, 2, 2, 3, 2, 1, 2, 1, 3, 3, 1, 2, 3, 1, 2, 1, 3, 1, 2, 2, 3, 2, 1, 2, 1, 3, 3, 1, 2, 3, 1, 2, 1, 3}
                },
            };
        }
    }
}
