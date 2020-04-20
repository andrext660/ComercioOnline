using ComercioOnline.Dominio.Contratos;
using ComercioOnline.Dominio.Entidades;
using ComercioOnline.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Repositorio.Repositorios
{
    class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio

    {
       
        public UsuarioRepositorio(Context context) : base(context)
        {


        }


    }
}
