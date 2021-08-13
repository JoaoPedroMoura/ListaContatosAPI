using ListaContatosAPI.Data;
using ListaContatosAPI.Data.DTos;
using ListaContatosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaContatoController : ControllerBase
    {
        private ContatoContext context;
        public ListaContatoController(ContatoContext Context)
        {
            context = Context;
        }
        [HttpPost]
        public IActionResult AdicionarContato([FromBody] CreateContatoDto contatoDto)
        {

            Contato contato = new Contato()
            {
                Email = contatoDto.Email,
                PrimeiroNome = contatoDto.PrimeiroNome,
                UltimoNome = contatoDto.UltimoNome,
                Telefone = contatoDto.Telefone
            };

            context.Add(contato);
            context.SaveChanges();
            return CreatedAtAction(nameof(ObterContatosPorNome), new { PrimeiroNome = contato.PrimeiroNome }, contato);
        }
        [HttpGet]
        public IActionResult ObterContatos()
        {
            return Ok(context.Contatos);
        }
        [HttpGet("api/nome/{primeiroNome}")]
        public IActionResult ObterContatosPorNome(string primeiroNome)
        {
            Contato contato = context.Contatos.FirstOrDefault(c => c.PrimeiroNome == primeiroNome);
            if (contato != null)
            {
                ReadContatoDto contatoDto = new ReadContatoDto()
                {
                    Id = contato.Id,
                    PrimeiroNome = contato.PrimeiroNome,
                    UltimoNome = contato.UltimoNome,
                    Email = contato.Email,
                    Telefone = contato.Telefone
                };
                return Ok(contatoDto);
            }
            return NotFound();
        }
        [HttpGet("api/email/{email}")]
        public IActionResult ObterContatosPorEmail(string email)
        {
            Contato contato = context.Contatos.FirstOrDefault(c => c.Email == email);
            if (contato != null)
            {
                ReadContatoDto contatoDto = new ReadContatoDto()
                {
                    Id = contato.Id,
                    PrimeiroNome = contato.PrimeiroNome,
                    UltimoNome = contato.UltimoNome,
                    Email = contato.Email,
                    Telefone = contato.Telefone
                };
                return Ok(contatoDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult EditarContato(int id, [FromBody] UpdateContatoDto contatoDto)
        {
            Contato contato= context.Contatos.FirstOrDefault(c => c.Id == id);
            if (contato != null)
            {
                contato.PrimeiroNome = contatoDto.PrimeiroNome;
                contato.UltimoNome = contatoDto.UltimoNome;
                contato.Email = contatoDto.Email;
                contato.Telefone = contatoDto.Telefone;
                context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Contato contato = context.Contatos.FirstOrDefault(c => c.Id == id);

            if (contato != null)
            {
                context.Remove(contato);
                context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}