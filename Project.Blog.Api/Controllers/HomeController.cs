using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Projeto.Blog.Data.Context;
using Projeto.Blog.Data.Entity;
using Projeto.Blog.Domain.Configuration;
using Projeto.Blog.Domain.IService;
using Projeto.Blog.Domain.Models;
using Model = Projeto.Blog.Domain.Models;

namespace Project.Blog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HomeController : Controller
    {
        private readonly IServicePublicacao _servicePublicacao;
        public HomeController(IServicePublicacao servicePublicacao)
        {
            _servicePublicacao = servicePublicacao;
        }


        [HttpGet]
        public async Task<IActionResult> BuscandoTodos()
        {
            var response = await _servicePublicacao.BuscarTodosService();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscandoPorId(string id)
        {
            var response = await _servicePublicacao.BuscarPorIdService(id);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarPublicacaoPorId(Model.Publicacao model)
        {
            var response = await _servicePublicacao.DeletarPorIdService(model.Id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> AlterarPublicacaoPorId(Model.Publicacao model)
        {
            var response = await _servicePublicacao.AlterarPublicacaoService(model, model.Id);
            return Ok(response);
        }

        [HttpPost]
        [Route("Publicacao")]
        public async Task<IActionResult> AdicionarPublicacao(Model.Publicacao model)
        {
            var response = await _servicePublicacao.AdicionarPublicacaoService(model);
            return Ok(response);
        }
    }
}