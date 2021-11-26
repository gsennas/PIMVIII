using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PimVIII.Models;

namespace PimVIII.Data
{
    public class PimVIIIContext : DbContext
    {
        public PimVIIIContext (DbContextOptions<PimVIIIContext> options)
            : base(options)
        {
        }

        public DbSet<PimVIII.Models.Endereco> Endereco { get; set; }
        public DbSet<PimVIII.Models.Pessoa> Pessoa { get; set; }
        public DbSet<PimVIII.Models.Telefone> Telefone { get; set; }
    }
}
