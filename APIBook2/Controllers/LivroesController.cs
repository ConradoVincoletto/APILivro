using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBook2.Data;
using APIBook2.Model;

namespace APIBook2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroesController : ControllerBase
    {
        private readonly Contexto _context;

        public LivroesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Livroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {

            try
            {
                return await _context.Livros.ToListAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        // GET: api/Livroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            try
            {
                var livro = await _context.Livros.FindAsync(id);

                if (livro == null)
                {
                    return NotFound();
                }

                return livro;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        // GET: api/Livroes/5
        [HttpGet("obterporautor/{autor}")]

        public async Task<ActionResult<IEnumerable<Livro>>> GetByAutor(string autor)
        {
            try
            {

                var livros = await _context.Livros.ToListAsync();
                var livro = livros.Where(x => x.Autor == autor).ToList();

                if (livro == null)
                {
                    return NotFound();
                }

                return livro;
            }
            catch (Exception e)
            {
                return NotFound($"Ocorreu um erro: {e.Message}");
            }
        }

        // PUT: api/Livroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Livroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            try
            {
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLivro", new { id = livro.Id }, livro);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/Livroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            try
            {
                var livro = await _context.Livros.FindAsync(id);
                if (livro == null)
                {
                    return NotFound();
                }

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
