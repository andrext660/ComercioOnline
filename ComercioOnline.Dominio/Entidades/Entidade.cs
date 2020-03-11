using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComercioOnline.Dominio.Entidades
{
    public abstract class Entidade
    {

        public List <string> _mensagemValidacao { get; set; }

        private List <string> mensagemValidacao
        {
             get { return _mensagemValidacao ?? (_mensagemValidacao = new List<string>()); }
        }


        public abstract void Validate();

        protected bool Ehvalido
        {
            get { return !mensagemValidacao.Any(); }
        }

        public void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }
    }
}
