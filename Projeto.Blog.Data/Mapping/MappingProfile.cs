using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MongoDB.Driver.Linq;
using Entity = Projeto.Blog.Data.Entity;
using Model = Projeto.Blog.Domain.Models;

namespace Projeto.Blog.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Publicacao, Entity.Publicacao>().ReverseMap();
            CreateMap<Model.Comentario, Entity.Comentario>().ReverseMap();
            CreateMap<Model.Usuario, Entity.Usuario>().ReverseMap();
        }
    }
}
