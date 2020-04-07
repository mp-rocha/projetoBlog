using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Blog.Data.Entity
{
    public class Comentario
    {
        public string Autor { get; set; }

        public string Conteudo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
