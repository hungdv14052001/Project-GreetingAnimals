using GreetingAnimalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Repositories
{
    public interface IRepository<T>
    {
        BaseEntity CreateEntity(BaseEntity baseEntity);
        List<T> GetAllEntity();
        List<T> GetAllEntityByKey(string key);
        T GetEntityById(int id);
        bool UpdateEntity(int id, BaseEntity baseEntity);
        bool DeleteEntityById(int id);
    }
}
