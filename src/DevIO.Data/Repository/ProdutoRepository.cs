using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) :  base(context)
        {
                
        }
        public async Task<Produto> ObterProdutoFornecedor(Guid Id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedor(Guid FornecedorId)
        {
            return await Buscar(p => p.FornecedorID == FornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome)
                .ToListAsync();
            
        }
    }
}
