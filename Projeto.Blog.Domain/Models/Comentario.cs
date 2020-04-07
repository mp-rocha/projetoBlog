using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Blog.Domain.Models
{
    public class Comentario : ModelBase
    {
        public string Autor { get; set; }

        public string Conteudo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
