using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core.WireProtocol.Messages;
using Projeto.Blog.Domain.IRepository;
using Projeto.Blog.Domain.IService;
using Projeto.Blog.Domain.Models;

namespace Projeto.Blog.Service.Service
{
    public class ServicePublicacao : IServicePublicacao
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServicePublicacao(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Publicacao>> BuscarTodosService()
        {
            List<Publicacao> response = new List<Publicacao>();
            response = await _unitOfWork.RepositoryPublicacao.BuscarTodosRepository();
            return response;
        }

        public async Task<Publicacao> BuscarPorIdService(string id) 
        {
            Publicacao response = new Publicacao();
            response = await _unitOfWork.RepositoryPublicacao.BuscarPorIdRepository(id);
            return response;
        }
    }

}
