using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.Core.WireProtocol.Messages;
using Projeto.Blog.Domain.IRepository;
using Projeto.Blog.Domain.IService;
using Projeto.Blog.Domain.Models;
using Swashbuckle.Swagger.Model;

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

        public async Task<string> DeletarPorIdService(string id)
        {
            var response = await _unitOfWork.RepositoryPublicacao.DeletarPorIdRepository(id);
            return response;
        }

        public async Task<string> AlterarPublicacaoService(Publicacao model, string id)
        {
            var response = await _unitOfWork.RepositoryPublicacao.AlterarPorIdRepository(model, id);
            return response;
        }

        public async Task<string> AdicionarPublicacaoService(Publicacao model)
        {
            model.Id = ObjectId.GenerateNewId().ToString();
            var response = await _unitOfWork.RepositoryPublicacao.AdicionarRepository(model);
            
            return response;
        }
    }
}
