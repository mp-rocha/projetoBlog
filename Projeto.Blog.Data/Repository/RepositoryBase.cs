using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Projeto.Blog.Data.Context;
using Projeto.Blog.Data.Entity;
using Projeto.Blog.Data.Mapping;
using Projeto.Blog.Domain.IRepository;

namespace Projeto.Blog.Data.Repository
{
    public abstract class RepositoryBase<T, K> : IRepositoryBase<T>
        where T : class // model
        where K : class // entity

    {   
        protected abstract string Collection { get; }
        public IMongoCollection<K> _collection;
        protected readonly ContextoMongoDB _context;
        protected readonly IMapper _mapper;

        public RepositoryBase(ContextoMongoDB context)
        {
            _context = context;
            _collection = _context.BaseDeDados.GetCollection<K>(Collection);
            var config = new MapperConfiguration(cfg => cfg.AddProfile(typeof(MappingProfile)));
            _mapper = config.CreateMapper();
            
        }

        public async Task<List<T>> BuscarTodosRepository()
        {
            List<K> entityList = await _collection.Find(Builders<K>.Filter.Empty).ToListAsync();
            return _mapper.Map<List<T>>(entityList);
        }

        public async Task<T> BuscarPorIdRepository(string id) 
        {
            K entity = await _collection.Find(Builders<K>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();
            return _mapper.Map<T>(entity);
        }

        public async Task<string> DeletarPorIdRepository(string id)
        {
            await _collection.DeleteOneAsync(Builders<K>.Filter.Eq("_id", new ObjectId(id)));
            return "Publicação deletada com sucesso!";
        }

        public async Task<string> AlterarPorIdRepository(T model, string id)
        {
            K entity = _mapper.Map<K>(model);
            await _collection.ReplaceOneAsync(Builders<K>.Filter.Eq("_id", new ObjectId(id)), entity);
            return "Publicação alterada com sucesso!";
        }

        public async Task<string> AdicionarRepository(T model)
        {
            K entity = _mapper.Map<K>(model);
            await _collection.InsertOneAsync(entity);
            return "Adicionado com sucesso!";
        }
    }
}
