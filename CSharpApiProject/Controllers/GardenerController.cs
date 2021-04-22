using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSharpApiProject.Repositories;
using System;

namespace CSharpApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenerController : ControllerBase
    {
        private readonly GardenerRepository _gardenerRepository;
        public GardenerController(IConfiguration configuration)
        {
            _gardenerRepository = new GardenerRepository(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gardenerRepository.GetAllGardeners());
        }

        //https://localhost:5001/api/gardener/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var singleGardener = _gardenerRepository.GetGardenerById(id);
            if (singleGardener == null)
            {
                return NotFound();
            }
            return Ok(singleGardener);
        }
    }
}