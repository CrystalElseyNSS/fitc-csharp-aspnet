using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSharpApiProject.Repositories;

namespace CSharpApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly PlotRepository _plotRepository;
        public PlotController(IConfiguration configuration)
        {
            _plotRepository = new PlotRepository(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_plotRepository.GetAllPlots());
        }

        //https://localhost:5001/api/plot/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var singlePlot = _plotRepository.GetPlotById(id);
            if (singlePlot == null)
            {
                return NotFound();
            }
            return Ok(singlePlot);
        }
    }
}