using ListaContatosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatosAPI.Data
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> opt):base(opt)
        {

        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
