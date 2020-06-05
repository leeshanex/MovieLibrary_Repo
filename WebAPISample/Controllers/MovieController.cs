using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/movie
        [HttpGet]
        public IActionResult Get()
        {
           
            var movie = _context.Movies.ToList();
            return Ok(movie);
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            var movie = _context.Movies.Where(m => m.MovieId == id).Single();
            return Ok();
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid data");
            }

            var createMovie = _context.Movies.Add(value);
                
                _context.SaveChanges();
            
            return Ok();
        }

        // PUT api/movie
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid model");
            }
            for ( id = 0; id >= movie.MovieId; id++)
            {
                var existingMovie = _context.Movies.Where(m => m.MovieId == id).FirstOrDefault();
                if (existingMovie != null)
                {
                    existingMovie.Title = movie.Title;
                    existingMovie.Director = movie.Director;
                    existingMovie.Genre = movie.Genre;

                    _context.SaveChanges();
                }
            }
            return Ok();
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Where(d => d.MovieId == id).FirstOrDefault();
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChangesAsync();
            }
            return Ok(movie);
        }
    }
}