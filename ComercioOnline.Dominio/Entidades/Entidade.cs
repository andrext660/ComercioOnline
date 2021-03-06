﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComercioOnline.Dominio.Entidades
{
    public abstract class Entidade
    {

        private List <string> _mensagemValidacao { get; set; }

        private List <string> mensagemValidacao
        {
             get { return _mensagemValidacao ?? (_mensagemValidacao = new List<string>()); }
        }



        public void LimparMensagensValidicao()
        {
            _mensagemValidacao.Clear();
        }

        public abstract void Validate();

        public bool Ehvalido
        {
            get { return !mensagemValidacao.Any(); }
        }

        public void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public string ObterMensagemValidacao()
        {
            return string.Join(". ", mensagemValidacao);

        }
        
    }
}
