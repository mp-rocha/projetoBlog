using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Blog.Domain.Response
{
    public class ResponseData<T>
    {
        public T Data { get; set; }

        public ResponseData() { }
        public ResponseData(T data)
        {
            Data = data;
        }
    }
}
