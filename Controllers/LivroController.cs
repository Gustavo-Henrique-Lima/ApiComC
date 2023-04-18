using Microsoft.AspNetCore.Mvc;
using APIC.Models;
using APIC.Services;

namespace Controllers
{
    [ApiController]
    [Route("livros")]
    public class LivroController : ControllerBase
    {
         [HttpGet]
        public ActionResult<List<Livro>> getAll() =>LivroService.getAll();

        [HttpGet("{id}")]
        public ActionResult<Livro> get(int id)
        {
            var livro = LivroService.get(id);
            if(livro == null)
            return NotFound();
            return livro;
        }

       [HttpPost]
        public IActionResult create(Livro livro)
        {
            LivroService.add(livro);
            return CreatedAtAction(nameof(get), new {id=livro.id},livro);
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var livro = LivroService.get(id);
            if(livro is null)
                return NotFound();
            LivroService.remove(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult update(int id,Livro livro)
        {
            if (id != livro.id)
                return BadRequest();
            var existingLivro = LivroService.get(id);
            if (existingLivro is null)
                return NotFound();
            LivroService.update(livro);
            return NoContent();
        }
         [HttpGet("minvalue={minValue}&&maxvalue={maxValue}")]
        public ActionResult<List<Livro>> getValue(double minValue,double maxValue)
        {
                List<Livro> livros=LivroService.filter(minValue,maxValue);
                if(livros.Count>0)
                    return livros;
                return NoContent();
        }
    }
}