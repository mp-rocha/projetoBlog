using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Projeto.Blog.Domain.Models;

namespace Projeto.Blog.Domain.IService

{
    public interface IServicePublicacao
    {
        // Sem ResponseData
        Task<List<Publicacao>> BuscarTodosService();
        Task<Publicacao> BuscarPorIdService(string id);
        Task<string> DeletarPorIdService(string id);
        Task<string> AlterarPublicacaoService(Publicacao model, string id);
        Task<string> AdicionarPublicacaoService(Publicacao model);
    }
}
