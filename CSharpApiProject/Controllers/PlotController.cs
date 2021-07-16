using Microsoft.AspNetCore.Mvc;
using CSharpApiProject.Repositories;
using CSharpApiProject.Data;

namespace CSharpApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly PlotRepository _plotRepository;
        public PlotController(ApplicationDbContext context)
        {
            _plotRepository = new PlotRepository(context);
        }

        [HttpGet]
        public IActionResult GetAllPlots()
        {
            var plots = _plotRepository.GetAllPlots();
            return Ok(plots);
        }

        // https://localhost:5001/api/plot/5
        [HttpGet("{id}")]
        public IActionResult GetPlotById(int id)
        {
            var plot = _plotRepository.GetPlotById(id);
            if (plot == null)
            {
                return NotFound();
            }
            return Ok(plot);
        }
    }
}