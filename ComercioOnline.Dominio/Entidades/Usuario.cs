using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Dominio.Entidades
{
    class Usuario: Entidade
    {


        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
