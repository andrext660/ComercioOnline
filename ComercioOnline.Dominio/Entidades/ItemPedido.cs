using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public override void Validate()
        {
          if (Quantidade == 0)
            {
                AdicionarCritica("Quantidade não pode ser nula");

            }

          if(ProdutoId == 0)
            {
                AdicionarCritica("Não foi identificado qual a referência");
            }

        }
    }
}
