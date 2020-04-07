using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Blog.Domain.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>> BuscarTodosRepository();

        Task<T> BuscarPorIdRepository(string id);

        Task<string> DeletarPorIdRepository(string id);

        Task<string> AlterarPorIdRepository(T model, string id);

        Task<string> AdicionarRepository(T model);
    }
}
