using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesignController : ControllerBase
{
    private readonly UserContext _context;
    public DesignController(UserContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Design>> GetAll(){
        return await _context.Designs.ToListAsync();
    }

    [HttpGet("design/by/id/{id}")]
    public async Task<ActionResult<Design>> GetById(int id){
        Design? design = await _context.Designs.FirstOrDefaultAsync(d => d.id == id);
        if(design == null) return NotFound();
        return design;
    }

    [HttpGet("image/by/id/{id}/{version}")]
    public async Task<ActionResult<string>> GetImageLink(int id, string version){
        //Get image link by design id and image version.
        Design? design = await _context.Designs.FirstOrDefaultAsync(d => d.id == id);
        if(design == null) return NotFound();
        string? link = design.imageSourceURL;
        if(link == null) return NotFound();
        if(int.Parse(version) > int.Parse(design.viewNumbers.Max()) || design.viewNumbers.Count() == 0) return NotFound(); 
        //If "version" is larger than the total available versions or there are no available versions, then return not found.
        return LinkBuilder.Build(link, version); 
        //Designs have multiple images, the version number dictates which image will be returned.
    } 

    [HttpGet("image/by/discord/{discord_id}/{version}")]
    public async Task<ActionResult<string>> GetImageLinkByDiscord(string discord_id, string version){
        //Get image link by design id and image version.
        Designer? designer = await _context.Designers.FirstOrDefaultAsync(d => d.discord_id == discord_id);
        if(designer == null) return NotFound();
        Design? design = await _context.Designs.FirstOrDefaultAsync(d => d.created_by == designer.designer_id);
        if(design == null) return NotFound();
        string? link = design.imageSourceURL;
        if(link == null) return NotFound();
        if(int.Parse(version) > int.Parse(design.viewNumbers.Max()) || design.viewNumbers.Count() == 0) return NotFound(); 
        //If "version" is larger than the total available versions or there are no available versions, then return not found.
        return LinkBuilder.Build(link, version); 
        //Designs have multiple images, the version number dictates which image will be returned.
    }

    [HttpGet("designs/by/model/{modelName}")]
    public async Task<ActionResult<IEnumerable<Design>>> GetByModelName(string modelName){
        List<Design> designs = await _context.Designs.Where(d => d.model_name == modelName).ToListAsync();
        if(designs.Count() == 0 || designs == null) return NotFound();
        return designs;
    }

    [HttpGet("designs/by/designer/{designer_id}")]
    public async Task<ActionResult<IEnumerable<Design>>> GetByDesignerId(Guid designer_id){
        List<Design> designs = await _context.Designs.Where(d => d.created_by == designer_id).ToListAsync();
        if(designs.Count() == 0 || designs == null) return NotFound();
        return designs;
    }

    [HttpGet("designs/by/discord/{discord_id}")]
    public async Task<ActionResult<IEnumerable<Design>>> GetByDiscordId(string discord_id){
        Designer? designer = await _context.Designers.FirstOrDefaultAsync(d => d.discord_id == discord_id);
        if(designer == null) return NotFound();
        List<Design> designs = await _context.Designs.Where(d => d.created_by == designer.designer_id).ToListAsync();
        if(designs.Count() == 0 || designs == null) return NotFound();
        return designs;
    }

    
}
