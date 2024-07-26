using Microsoft.AspNetCore.Mvc;
using thesis_exercise.model.DTOs;
using thesis_exercise.services.Interface;

namespace thesis_exercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComputerController : ControllerBase
{
    private readonly IComputerService _computerService;

    public ComputerController(IComputerService computerService)
    {
        _computerService = computerService;
    }

    [HttpGet("catalogs")]
    public async Task<IActionResult> GetCatalogos()
    {
        CatalogsDTO model = await _computerService.GetCatalogs();
        return Ok(new CatalogsBaseDTO { Catalogs = model });
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string query = "")
    {
        var result = await _computerService.Get(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ComputerDTO model)
    {
        await _computerService.Create(model);
        return Ok();
    }

    [HttpPatch("{computerId:int}")]
    public async Task<IActionResult> Patch(int computerId, [FromBody] ComputerDTO model)
    {
        await _computerService.Update(computerId, model);
        return Ok();
    }
}
