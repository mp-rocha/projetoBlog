using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Blog.Domain.IRepository
{
    public interface IUnitOfWork
    {
        IRepositoryPublicacao RepositoryPublicacao { get; }
    }
}
