using Application;
using Domain;
using Infrastructure;
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
        private readonly MisionDbContext dbContext;
        public IRobotProcessor Processor { get; set; }
        public ISurface MarsSurface { get; set; }
        public MarsMisionController(IRobotProcessor _processor, ISurface _marsSurface, MisionDbContext _dbContext)
        {
            Processor = _processor;
            MarsSurface = _marsSurface;
            Processor.MarsSurface = MarsSurface;
            dbContext = _dbContext;
        }

        // GET: api/<MarsMisionController>
        [HttpGet]
        public IEnumerable<IScent> Get()
        {
            var temp = dbContext.Mision.ToArray();
            return Processor.MarsSurface.Scent;
        }

        // GET api/<MarsMisionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates and execute a MarsMision then return the result.
        /// </summary>
        /// <param name="inputCommand"></param>
        /// <returns>All the lines in the command</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /MarsMision
        ///     [
        ///         "5 3",
        ///         "1 1 E",
        ///         "RFRFRFRF",
        ///         "3 2 N",
        ///         "FRRFLLFFRRFLL",
        ///         "0 3 W",
        ///         "LLFFFRFLFL"
        ///     ]
        ///
        /// </remarks>
        /// <response code="200">Returns the final grid position and orientation of all robots.</response>
        /// <response code="400">If the format is not correct</response>
        [HttpPost]
        public List<string> Post([FromBody] string[] inputCommand)
        {
            Processor.IsCommandValid(inputCommand.ToList());
            var response = Processor.ExcecuteEachRobotCommand(inputCommand.ToList());

            var mision = new MisionModel()
            {
                RobotsQuantity = response.Count,
                Surface = Processor.MarsSurface.ToString()
            };
            //response.ForEach(res=>mision.RobotsResult.Add(new RobotOutputModel() { 
            //    IsLost = res.
            //}));
            //mision.RobotsCommands.Add(new RobotCommadModel() { 
            //    Instructions
            //});
            dbContext.Mision.Add(mision);
            dbContext.SaveChanges();
            return response;
        }
    }
}
