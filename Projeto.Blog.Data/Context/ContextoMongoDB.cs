using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Projeto.Blog.Domain.Configuration;
using Projeto.Blog.Domain.Models;

namespace Projeto.Blog.Data.Context
{
    public class ContextoMongoDB
    {
        // Inicializando cliente mongo
        private readonly MongoClient _cliente;
        public MongoClient Cliente => _cliente;

        // Inicializando base de dados
        private readonly IMongoDatabase _BaseDeDados;
        public IMongoDatabase BaseDeDados => _BaseDeDados;

        public ContextoMongoDB(IOptions<Config> options)
        {
            _cliente = new MongoClient(options.Value.ConnectionString);
            _BaseDeDados = _cliente.GetDatabase(options.Value.DatabaseName);
        }

    }
}
