using Application;
using AutoMapper;
using System.Linq;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MartianRobotsSimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarsMisionController : ControllerBase
    {
        private IMisionRepository MisionRepository;

        private readonly IMapper Mapper;
        public IRobotProcessor Processor { get; set; }
        public ISurface MarsSurface { get; set; }
        public MarsMisionController(IRobotProcessor _processor, ISurface _marsSurface, IMisionRepository _repository, IMapper _mapper)
        {
            Processor = _processor;
            MarsSurface = _marsSurface;
            Processor.MarsSurface = MarsSurface;
            MisionRepository = _repository;
            Mapper = _mapper;
        }

        /// <summary>
        /// Return all the mision since the beginning of time.
        /// </summary>
        /// <returns>Al the mision</returns>
        /// <response code="200">Returns a list with all mision. Recomendation deserialize to json the values of robotsInputs,robotsResult and scents.</response>
        [HttpGet]
        public IEnumerable<MisionModel> Get()
        {
            return MisionRepository.GetAllMisions();
        }

        /// <summary>
        /// Get a MarsMision by id.
        /// </summary>
        /// <param name="id">Mision Identificator</param>
        /// <returns>The mision with this id</returns>
        /// <response code="200">Returns a mision model. Recomendation deserialize to json the values of robotsInputs,robotsResult and scents.</response>
        [HttpGet("{id}")]
        public MisionModel Get(int id)
        {
            return MisionRepository.GetById(id);
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
            Processor.ExcecuteEachRobotCommand(inputCommand.ToList());

            MisionRepository.Add(Mapper.Map<MisionModel>(Processor));

            return Processor.GetSimplifiedResult();
        }
    }
}
