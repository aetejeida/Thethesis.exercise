using thesis_exercise.data.Repositories.Interface;
using thesis_exercise.data.Repositories;
using thesis_exercise.services.Implementation;
using thesis_exercise.services.Interface;
using thesis_exercise.Controllers;
using Microsoft.AspNetCore.Mvc;
using thesis_exercise.model.DTOs;

namespace thesis_exercise.Tests.Controllers
{
    internal class ComputerControllerTest : TestCaseBase
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

        [Test, Order(1)]
        public async Task GetEndpointType200_ShouldPass()
        {
            var controller = new ComputerController(_computerService);
            var result = await controller.Get();

            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test, Order(2)]
        public async Task GetEndpointValue_ShouldPass()
        {
            var controller = new ComputerController(_computerService);
            var result = await controller.Get() as OkObjectResult;

            Assert.That(result?.Value, Is.TypeOf<List<ComputerDetailDTO>>());
        }

        [Test, Order(3)]
        public async Task GetCatalogsEndpointType200_ShouldPass()
        {
            var controller = new ComputerController(_computerService);
            var result = await controller.GetCatalogos();

            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test, Order(4)]
        public async Task GetCatalogsEndpointValue_ShouldPass()
        {
            var controller = new ComputerController(_computerService);
            var result = await controller.GetCatalogos() as OkObjectResult;

            Assert.That(result?.Value, Is.TypeOf<CatalogsBaseDTO>());
        }
    }
}
