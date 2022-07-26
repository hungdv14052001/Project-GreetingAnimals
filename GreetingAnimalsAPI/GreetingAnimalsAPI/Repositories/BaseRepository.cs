using GreetingAnimalsAPI.Data;
using GreetingAnimalsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly EntityContext _ctx;
        private DbSet<T> Model { get; set; }

        /// <summary>
        /// Initialization Base Repository
        /// </summary>
        /// <param name="ctx"></param>
        public BaseRepository(EntityContext ctx)
        {
            this._ctx = ctx;
            Model = ctx.Set<T>();
        }

        /// <summary>
        /// Create Entity
        /// </summary>
        /// <param name="baseEntity"></param>
        /// <returns>BaseEntity</returns>
        public BaseEntity CreateEntity(BaseEntity baseEntity)
        {
            T entity = baseEntity as T;
            Model.Add(entity);
            SaveChange();
            return baseEntity;
        }

        /// <summary>
        /// Delete entity by id of entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEntityById(int id)
        {
            bool result = false;
            if (EntityExist(id))
            {
                T entity = GetEntityById(id);
                try
                {
                    Model.Remove(entity);
                    SaveChange();
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// get all entity in DataBase
        /// </summary>
        /// <returns>List<BaseEntity></returns>
        public List<T> GetAllEntity()
        {
            List<T> entities = new List<T>();
            foreach (T entity in Model.ToList())
            {
                entities.Add(entity);
            }
            return entities;
        }

        /// <summary>
        /// Get All Entity By Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> GetAllEntityByKey(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntityById(int id)
        {
            T entity;
            try
            {
                entity = Model.Find(id);
            }
            catch
            {
                entity = null;
            }
            return entity;
        }

        /// <summary>
        /// Update Entity in DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="baseEntity"></param>
        /// <returns>bool</returns>
        public bool UpdateEntity(int id, BaseEntity baseEntity)
        {
            try
            {
                baseEntity.Id = id;
                _ctx.Entry(baseEntity).State = EntityState.Modified;
                SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Save action when change context
        /// </summary>
        public void SaveChange()
        {
            _ctx.SaveChanges();
        }

        /// <summary>
        /// check entity exist by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EntityExist(int id)
        {
            bool result = false;
            foreach(T entity in Model.ToList())
            {
                BaseEntity baseEntity = entity as BaseEntity;
                if(baseEntity.Id== id)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
