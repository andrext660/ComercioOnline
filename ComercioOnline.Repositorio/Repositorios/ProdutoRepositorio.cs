using ComercioOnline.Dominio.Contratos;
using ComercioOnline.Dominio.Entidades;
using ComercioOnline.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Repositorio.Repositorios
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(Context context) : base(context)
        {
        }
    }
}
