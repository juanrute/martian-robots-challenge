using Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MartianRobotsSimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsMisionController : ControllerBase
    {
        // GET: api/<MarsMisionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MarsMisionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MarsMisionController>
        [HttpPost]
        public void Post([FromBody] string[] inputCommand)
        {
            IRobotProcessor processor = new RobotProcessor();
            //processor.ParseInput(inputCommand.ToArray());
        }

        // PUT api/<MarsMisionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
