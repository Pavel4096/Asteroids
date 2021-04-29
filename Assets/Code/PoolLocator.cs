using System;
using System.Collections.Generic;

namespace Asteroids
{
    public static class PoolLocator
    {
        private static Dictionary<(Type, Type), object> pools = new Dictionary<(Type, Type), object>();

        public static PoolManager<TModel, TController> Get<TModel, TController>() where TController : class, IPoolManagable
        {
            (Type model, Type controller) poolType = (typeof(TModel), typeof(TController));

            if(pools.ContainsKey(poolType))
            {
                return (PoolManager<TModel, TController>)pools[poolType];
            }

            throw new KeyNotFoundException($"Pool for ({poolType.model.FullName}, {poolType.controller.FullName}) is not found.");
        }

        public static void Add<TModel, TController>(Func<TModel, TController> objectCreator) where TController : class, IPoolManagable
        {
            (Type, Type) poolType = (typeof(TModel), typeof(TController));

            if(!pools.ContainsKey(poolType))
            {
                pools.Add(poolType, new PoolManager<TModel, TController>(objectCreator));
            }
        }
    }
}
