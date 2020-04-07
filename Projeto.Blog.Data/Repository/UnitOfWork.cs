using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Blog.Data.Context;
using Projeto.Blog.Domain.IRepository;

namespace Projeto.Blog.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoMongoDB _context;

        public UnitOfWork(ContextoMongoDB context)
        {
            _context = context;
        }

        private IRepositoryPublicacao _repositoryPublicacao;
        public IRepositoryPublicacao RepositoryPublicacao => _repositoryPublicacao ?? (_repositoryPublicacao = new RepositoryPublicacao(_context));
    }
}
