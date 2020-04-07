using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver.Linq;
using Projeto.Blog.Data.Context;
using Projeto.Blog.Domain.IRepository;
using Entity = Projeto.Blog.Data.Entity;
using Model = Projeto.Blog.Domain.Models;

namespace Projeto.Blog.Data.Repository
{
    public class RepositoryPublicacao : RepositoryBase<Model.Publicacao, Entity.Publicacao>, IRepositoryPublicacao
    {

        public RepositoryPublicacao(ContextoMongoDB context) : base(context) { }

        protected override string Collection => "Publicacoes";
    }
}
