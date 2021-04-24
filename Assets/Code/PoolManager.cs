using System;
using System.Collections.Generic;

namespace Asteroids
{
    public sealed class PoolManager<TType, TController> where TController: class, IPoolManagable
    {
        private Dictionary<TType, List<TController>> pool = new Dictionary<TType, List<TController>>();
        private Func<TType, TController> objectCreator;

        public PoolManager(Func<TType, TController> objectCreator_)
        {
            objectCreator = objectCreator_;
        }

        public TController GetOrCreate(TType type)
        {
            List<TController> objectList;
            TController result = null;

            if(!pool.ContainsKey(type))
            {
                pool.Add(type, new List<TController>());
            }
            objectList = pool[type];

            for(int i = 0, count = objectList.Count; i < count; i++)
            {
                if(!objectList[i].IsActive)
                {
                    result = objectList[i];
                    break;
                }
            }

            if(result == null)
            {
                result = objectCreator(type);
                objectList.Add(result);
            }

            return result;
        }
    }
}
