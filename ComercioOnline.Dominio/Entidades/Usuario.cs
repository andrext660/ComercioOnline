using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Dominio.Entidades
{
   public class Usuario: Entidade
    {


        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public bool EhAdministrador { get; set; }

        //Usuario pode ter nenhum ou vários pedidos
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
           
            if (string.IsNullOrEmpty(Senha))
            {
                AdicionarCritica("O campo de senha não pode ser vazio");
            }


            if (string.IsNullOrEmpty(Email))
            {
                AdicionarCritica("O email não foi informado");
            }

        }
    }
}
