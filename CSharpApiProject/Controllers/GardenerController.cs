using Microsoft.AspNetCore.Mvc;
using CSharpApiProject.Repositories;
using CSharpApiProject.Data;

namespace CSharpApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenerController : ControllerBase
    {
        private readonly GardenerRepository _gardenerRepository;

        public GardenerController(ApplicationDbContext context)
        {
            _gardenerRepository = new GardenerRepository(context);
        }

        [HttpGet]
        public IActionResult GetAllGardeners()
        {
            var gardeners = _gardenerRepository.GetAllGardeners();
            return Ok(gardeners);
        }

        //https://localhost:5001/api/gardener/5
        [HttpGet("{id}")]
        public IActionResult GetGardenerById(int id)
        {
            var gardener = _gardenerRepository.GetGardenerById(id);
            if (gardener == null)
            {
                return NotFound();
            }
            return Ok(gardener);
        }
    }
}