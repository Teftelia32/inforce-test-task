using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using URLShortener.Managers.Interfaces;
using URLShortener.Models;

[Route("api/[controller]")]
[ApiController]
public class UrlShortenerController : ControllerBase
{
    private readonly IUrlManager _urlManager;

    public UrlShortenerController(IUrlManager urlManager)
    {
        _urlManager = urlManager;
    }

    [Authorize]
    [HttpGet("{urlId}")]
    public async Task<IActionResult> GetUrlDetails(int urlId)
    {
        var url = await _urlManager.GetUrlDetailsAsync(urlId);

        if (url == null)
            return NotFound();

        return Ok(url);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUrl([FromBody] string originalUrl)
    {
        var userId = Convert.ToInt32(User.FindFirstValue("userId"));

        var url = await _urlManager.CreateUrlAsync(originalUrl, userId);

        return Ok(url);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteUrl(int id)
    {
        var userId = Convert.ToInt32(User.FindFirstValue("userId"));

        var result = await _urlManager.DeleteUrlAsync(id, userId);

        if (!result)
            return Forbid();

        return NoContent();
    }

    [HttpGet("user-urls")]
    public async Task<IActionResult> GetUrlsByUser()
    {
        var userId = Convert.ToInt32(User.FindFirstValue("userId"));
        var urls = await _urlManager.GetUrlsByUserAsync(userId);

        return Ok(urls);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUrls()
    {
        var urls = await _urlManager.GetAllUrlsAsync();
        return Ok(urls);
    }
}
