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
            // Retrieve all movies from db logic
            var movie = _context.Movies.ToList();
            return Ok(movie);
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Retrieve movie by id from db logic
            // return Ok(movie);
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
    
            // Create movie in db logic
            //var movie = _context.Movies.Add(value);
            //_context.SaveChangesAsync();

        // PUT api/movie
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
<<<<<<< HEAD
            
=======

>>>>>>> fac9134684a1bcbbc9cc38be1d2d41fe63b7f897
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
                //else
                //{
                //    return NotFound();
                //}
               
            }
            return Ok();
            //// Update movie in db logic
            //var updatedMovie = _context.Movies.Find(movie);
            //updatedMovie.Title = movie.Title;
            //updatedMovie.Director = movie.Director;
            //updatedMovie.Genre = movie.Genre;
<<<<<<< HEAD
            //updatedMovie.ImageUrl = movie.ImageUrl;
=======
            ////updatedMovie.ImageUrl = movie.ImageUrl;
            return Ok();
>>>>>>> fac9134684a1bcbbc9cc38be1d2d41fe63b7f897

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
            
            // Delete movie from db logic
            //movie movie = _context.movies.find(id);
            //_context.movies.remove(movie);
            //_context.savechanges();
            return Ok(movie);
        }

       
    }
}