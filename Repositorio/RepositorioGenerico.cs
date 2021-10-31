﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CadastroProduto.Interfaces.IRepositorioGenerico;

namespace CadastroProduto.Repositorio
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly ContextoDb _contexto;

        public RepositorioGenerico(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        public async Task Alterar(TEntity entity)
        {
            try
            {
                _contexto.Set<TEntity>().Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(int codigo)
        {
            try
            {
                var entity = await RecuperarPorCodigo(codigo);
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(string codigo)
        {
            try
            {
                var entity = await RecuperarPorCodigo(codigo);
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(TEntity entity)
        {
            try
            {
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Inserir(TEntity entity)
        {
            try
            {
                await _contexto.AddAsync(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Inserir(List<TEntity> entities)
        {
            try
            {
                await _contexto.AddRangeAsync(entities);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            try
            {
                return await _contexto.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> recuperarComFraseSql(string fraseSQL)
        {
            try
            {
                return await _contexto.Set<TEntity>().FromSqlRaw(fraseSQL).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> RecuperarPorCodigo(int codigo)
        {
            try
            {
                return await _contexto.Set<TEntity>().FindAsync(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> RecuperarPorCodigo(string codigo)
        {
            try
            {
                return await _contexto.Set<TEntity>().FindAsync(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
