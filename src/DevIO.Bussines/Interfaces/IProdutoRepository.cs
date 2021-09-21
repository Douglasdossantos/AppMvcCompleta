using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoRepository :IRepository<Produto>
    {
        Task<Produto> ObterProdutoFornecedor(Guid Id);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<IEnumerable<Produto>> ObterProdutosFornecedor(Guid FornecedorId);
    }
}
