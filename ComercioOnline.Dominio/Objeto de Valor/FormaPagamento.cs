using ComercioOnline.Dominio.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Dominio.Objeto_de_Valor
{
    public class FormaPagamento
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }



        public bool Ehboleto
        {
            get { return Id == (int)TipoFormaPagamentoEnum.Boleto; }
        }

        public bool EhCartaoCredito
        {
            get { return Id == (int)TipoFormaPagamentoEnum.CartaoCredito; }
        }


        public bool EhDeposito
        {
            get { return Id == (int)TipoFormaPagamentoEnum.Deposito; }
        }

        public bool NaoFoiDefinido
        {
            get { return Id == (int)TipoFormaPagamentoEnum.NaoDefinido; }
        }


    }
}
