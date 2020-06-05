using ComercioOnline.Dominio.Contratos;
using ComercioOnline.Dominio.Entidades;
using ComercioOnline.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComercioOnline.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio

    {
       
        public UsuarioRepositorio(Context context) : base(context)
        {


        }

        public Usuario Obter(string email, string senha)
        {
            return Context.Usuarios.FirstOrDefault(u=> u.Email == email && u.Senha == senha);
        }
    }
}
