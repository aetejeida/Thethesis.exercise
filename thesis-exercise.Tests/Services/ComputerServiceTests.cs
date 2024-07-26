using NUnit.Framework.Constraints;
using thesis_exercise.data.Repositories;
using thesis_exercise.data.Repositories.Interface;
using thesis_exercise.model.DTOs;
using thesis_exercise.services.Implementation;
using thesis_exercise.services.Interface;
using thesis_exercise.Tests.TestCases;

namespace thesis_exercise.Tests.Services
{
    internal class ComputerServiceTests : TestCaseBase
    {

        IComputerRepository _computerRepository;
        IComputerService _computerService;
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _computerRepository = new ComputerRepository(_dbContext);
            _computerService = new ComputerService(_computerRepository, _mapper);
        }

        [TearDown]
        public override void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Test, TestCaseSource(typeof(InitialObjectTestCases), nameof(InitialObjectTestCases.LoadCamputersObject))]
        public async Task CreateComputer_ShouldPass(IList<ComputerDTO> payloads)
        {   // Arrange
            List<ComputerDTO> results = new List<ComputerDTO>();
            foreach (var payload in payloads)
            { 
                // Act
                var result = await _computerService.Create(payload);
                results.Add(result);
            }

            // Assert
            Assert.That(results.Count(), Is.EqualTo(5));
            Assert.That(_dbContext.Computers.Count(), Is.EqualTo(5));
            Assert.That(_dbContext.ComputerUsbPorts.Where(x => x.ComputerId == 3).Count(), Is.EqualTo(0));
        }

        [Test, TestCaseSource(typeof(InitialObjectTestCases), nameof(InitialObjectTestCases.LoadCamputersObject))]
        public async Task CreateComputer_ShouldFail(IList<ComputerDTO> payloads)
        {
            // Arrange
            foreach (var payload in payloads)
            {
                // Act
                // Assert
                Assert.ThrowsAsync<ArgumentNullException>(() => _computerService.Create(null));
            }
        }

        [Test]
        public async Task GetCatalogs_ShouldPass()
        {
            // Arrange
            // Act
            var result = await _computerService.GetCatalogs();
            
            // Assert
            Assert.That(result.HardDisks.Count(), Is.EqualTo(8));
            Assert.That(result.Memories.Count(), Is.EqualTo(5));
            Assert.That(result.Processors.Count(), Is.EqualTo(8));
            Assert.That(result.UsbPorts.Count(), Is.EqualTo(3));

        }

        [Test]
        public async Task GetCatalogs_ShouldFail()
        {
            //Arrage
            _dbContext.HardDisks.RemoveRange(_dbContext.HardDisks);
            _dbContext.Memories.RemoveRange(_dbContext.Memories);
            _dbContext.Processors.RemoveRange(_dbContext.Processors);
            _dbContext.UsbPorts.RemoveRange(_dbContext.UsbPorts);

            // Act
            var result = await _computerService.GetCatalogs();

            //Assert
            Assert.That(result.HardDisks.Count(), Is.EqualTo(8));
            Assert.That(result.Memories.Count(), Is.EqualTo(5));
            Assert.That(result.Processors.Count(), Is.EqualTo(8));
            Assert.That(result.UsbPorts.Count(), Is.EqualTo(3));

        }


        [Test, TestCaseSource(typeof(InitialObjectTestCases), nameof(InitialObjectTestCases.LoadCamputersObject))]
        public async Task GetCatalogComputer_ShouldPass(IList<ComputerDTO> payloads)
        {
            //Arrage
            List<ComputerDTO> results = new List<ComputerDTO>();
            foreach (var payload in payloads)
            {
                // Act
                var result = await _computerService.Create(payload);
                results.Add(result);
            }

            var computers = await _computerService.Get();
            //Assert
            Assert.That(computers.Count(), Is.EqualTo(results.Count()));
        }

        [Test, TestCaseSource(typeof(InitialObjectTestCases), nameof(InitialObjectTestCases.LoadCamputersObject))]
        public async Task GetCatalogComputerValidateTexts_ShouldPass(IList<ComputerDTO> payloads)
        { 
            //Arrage
            List<ComputerDTO> results = new List<ComputerDTO>();
            foreach (var payload in payloads)
            {
                var result = await _computerService.Create(payload);
                results.Add(result);
            }
            // Act
            var computers = await _computerService.Get();

            //Assert
            Assert.That(computers.FirstOrDefault().DiskSpace, Is.EqualTo("1 TB SSD"));
            Assert.That(computers.LastOrDefault().Memory, Is.EqualTo("16 GB"));
            Assert.That(computers.FirstOrDefault().Processor, Is.EqualTo("Intel® Celeron™ N3050 Processor"));
            Assert.That(computers.FirstOrDefault(x => x.ComputerId == 4).UsbPorts, Is.EqualTo("5 X USB C, 6 X USB 3.0, 6 X USB 2.0"));
        }
    }
}
