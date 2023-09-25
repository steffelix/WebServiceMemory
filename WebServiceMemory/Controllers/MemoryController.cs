using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebServiceMemory.Models;
using System.Collections.Generic;
using System.Linq;
using WebServiceExamen;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceMemory.Controllers
{
    //Scaffold-DbContext "Server=.;Database=Memory;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
    //"Server=.;Database=Memory;user Id=memoryapi;Password=memoryapi123"
    //"Server=.;Database=Memory;Trusted_Connection=True;"

    [EnableCors("PolicyAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        [HttpGet("{id}")]

        public IActionResult GetImage(int id)
        {
            MemoryContext memoryContext = new MemoryContext();
            byte[] image = memoryContext.Images.Where(x => x.Id == id).Select(x => x.Image1).First(); //First is omdat het nog als list is ofzo
            Response.ContentType = "image/png";
            return File(image, "image/png");
        }

        [HttpGet("")]

        public IEnumerable<Image> Get()
        {
            MemoryContext context = new MemoryContext();
            return context.Images;
        }

        [HttpGet("Back")]

        public IActionResult GetBack()
        {
            MemoryContext memoryContext = new MemoryContext();
            byte[] image = memoryContext.Images.Where(x => x.IsBack == true).Select(x => x.Image1).First();
            Response.ContentType = "image/png";
            return File(image, "image/png");
        }


        [HttpGet("Theme/{theme}")]

        public IEnumerable<Image> GetTheme(string theme)
        {
            MemoryContext context = new MemoryContext();
            return context.Images.Where(i => i.Theme == theme);
        }

        [HttpGet("Back/{theme}")]

        public IActionResult GetBackTheme(string theme)
        {
            MemoryContext memoryContext = new MemoryContext();
            byte[] image = memoryContext.Images.Where(x => x.IsBack == true && x.Theme == theme).Select(x => x.Image1).First();
            Response.ContentType = "image/png";
            return File(image, "image/png");
        }

        //[HttpPost]
        //public Score Post([FromBody] Score highscore)
        //{
        //    HighScoreRepository repository = new HighScoreRepository();
        //    return repository.Add(highscore);
        //}

        [HttpGet("Score/{id}")]

        public Score GetScore(int id)
        {
            MemoryContext context = new MemoryContext();
            Score score = context.Scores.Where(i => i.Id == id).First();
            return score;
        }

        [HttpGet("Coordinate/{id}")]

        public Coordinate GetCoordinate(int id)
        {
            MemoryContext context = new MemoryContext();
            Coordinate coordinate = context.Coordinates.Where(i => i.Id == id).First();
            return coordinate;
        }

        [HttpGet("Coordinate")]

        public IEnumerable<Coordinate> GetAllCoordinates()
        {
            MemoryContext context = new MemoryContext();
            return context.Coordinates;
        }

        [HttpGet("PlayerScore")]

        public IEnumerable<PlayersScore> GetAllPlayersScores()
        {
            MemoryContext context = new MemoryContext();
            return context.PlayersScores;
        }

        [HttpPost]
        public Coordinate Post([FromBody] Coordinate coordinate)
        {
            CoordinateRepository repository = new CoordinateRepository();
            return repository.Add(coordinate);
        }

        [HttpPost("Combination")]
        public CombinationFound Post([FromBody] CombinationFound combination)
        {
            CombinationFoundRepository repository = new CombinationFoundRepository();
            return repository.Add(combination);
        }

        [HttpPost("PlayersScore")]
        public PlayersScore Post([FromBody] PlayersScore playersscore)
        {
            PlayersScoreRepository repository = new PlayersScoreRepository();
            return repository.Add(playersscore);
        }
    }
}
