using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesignerController : ControllerBase
{
    private readonly UserContext _context;
    public DesignerController(UserContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Designer>> GetAll()
    {
        return await _context.Designers.ToListAsync();
    }
    
    [HttpGet("designer/by/id/{id}")]
    public async Task<ActionResult<Designer>> GetById(string id)
    {
        Designer? designer = await _context.Designers.FirstOrDefaultAsync(d => d.designer_id.ToString() == id);
        if(designer == null) return NotFound();
        return designer;
    }

    [HttpGet("designer/by/username/{username}")]
    public async Task<ActionResult<Designer>> GetByUsername(string username){
        Designer? designer = await _context.Designers.FirstOrDefaultAsync(d => d.username == username);
        if(designer == null) return NotFound();
        return designer;
    }

    [HttpGet("designer/by/discord/{discord_id}")]
    public async Task<ActionResult<Designer>> GetByDiscordId(string discord_id){
        Designer? designer = await _context.Designers.FirstOrDefaultAsync(d => d.discord_id == discord_id);
        if(designer == null) return NotFound();
        return designer;
    }

    [HttpGet("designer/by/instagram/{instagram_tag}")]
    public async Task<ActionResult<Designer>> GetByInstagramTag(string instagram_tag){
        Designer? designer = await _context.Designers.FirstOrDefaultAsync(d => d.instagram_tag == instagram_tag);
        if(designer == null) return NotFound();
        return designer;
    }

    [HttpGet("designer/by/twitter/{twitter_tag}")]
    public async Task<ActionResult<Designer>> GetByTwitterTag(string twitter_tag){
        Designer? designer = await _context.Designers.FirstOrDefaultAsync(d => d.twitter_tag == twitter_tag);
        if(designer == null) return NotFound();
        return designer;
    }
}
