using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Projeto.Blog.Data.Entity
{
    public class Publicacao
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Autor { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public string[] Tags { get; set; }

        public DateTime DataCriacao { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }
}

