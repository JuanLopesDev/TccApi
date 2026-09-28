using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TccApi.Data;
using TccApi.Models;

namespace TccApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TccController : ControllerBase
{
    private readonly AppDbContext _context;

    public TccController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tcc>>> GetAll()
    {
        return await _context.Tccs.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tcc>> GetById(int id)
    {
        var tcc = await _context.Tccs.FindAsync(id);

        if (tcc == null)
            return NotFound();

        return tcc;
    }

    [HttpPost]
    public async Task<ActionResult<Tcc>> Post(Tcc tcc)
    {
        tcc.Id = 0;
        _context.Tccs.Add(tcc);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = tcc.Id }, tcc);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, Tcc tcc)
    {
        if (id != tcc.Id)
            return BadRequest();

        var existente = await _context.Tccs.FindAsync(id);

        if (existente == null)
            return NotFound();

        existente.TituloTCC = tcc.TituloTCC;
        existente.Autores = tcc.Autores;
        existente.Orientador = tcc.Orientador;
        existente.DataDeConclusao = tcc.DataDeConclusao;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tcc = await _context.Tccs.FindAsync(id);

        if (tcc == null)
            return NotFound();

        _context.Tccs.Remove(tcc);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}