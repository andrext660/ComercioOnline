using ComercioOnline.Dominio.Contratos;
using ComercioOnline.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComercioOnline.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity:class
    {

        protected readonly Context Context;

        public BaseRepositorio(Context context)
        {
            Context = context;
        }

        public void Adicionar(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();

        }

        public void Atualizar(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
            Context.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {

            Context.Remove(entity);
            Context.SaveChanges();
        }

    }
}
