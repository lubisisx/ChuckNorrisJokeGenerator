using ChuckNorrisJokeGenerator.Data;
using ChuckNorrisJokeGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]
public class JokesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public JokesController(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandomJoke()
    {
        var url = "https://api.chucknorris.io/jokes/random";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jokeJson = await response.Content.ReadAsStringAsync();
            var joke = JsonConvert.DeserializeObject<Joke>(jokeJson);
            return Ok(joke);
        }

        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
    }

    [HttpPost("favorites")]
    public async Task<IActionResult> SaveFavoriteJoke([FromBody] Joke joke)
    {
        try {
            var existingJoke = _context.Jokes.SingleOrDefaultAsync(j => j.Id == joke.Id);
            if(existingJoke == null) 
            {
                _context.Jokes.Add(joke);
                await _context.SaveChangesAsync();
                return Ok(joke);
            }

            return Ok(joke);
            
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to save joke", ex);
        }
    }

    [HttpGet("favorites")]
    public async Task<IActionResult> GetFavoriteJokes()
    {
        var favoriteJokes = await _context.Jokes.ToListAsync();
        return Ok(favoriteJokes);
    }
}
