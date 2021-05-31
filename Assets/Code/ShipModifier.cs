using System;
using System.Collections.Generic;

namespace Asteroids
{
    public class ShipModifier
    {
        protected IShipController ship;
        private ShipModifier next;

        private const string IndexOutOfRangeMessage = "Индекс меньше нуля или больше/равен числу элементов";

        public ShipModifier(IShipController _ship)
        {
            ship = _ship;
        }

        public ShipModifier Add(ShipModifier nextModifier)
        {
            if(next == null)
                next = nextModifier;
            else
                next.Add(nextModifier);
            
            return nextModifier;
        }

        public ShipModifier this[int index]
        {
            get
            {
                ShipModifier modifier = this;

                if(index < 0)
                    throw new IndexOutOfRangeException(IndexOutOfRangeMessage);

                for(var i = 0; i < index; i++)
                {
                    if(modifier.next != null)
                    {
                        modifier = modifier.next;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(IndexOutOfRangeMessage);
                    }
                }

                return modifier;
            }
        }

        public IEnumerable<ShipModifier> Modifiers
        {
            get
            {
                ShipModifier modifier = this;

                do
                {
                    yield return modifier;
                    modifier = modifier.next;
                } while(modifier != null);
            }
        }

        public virtual void Handle()
        {
            if(next != null)
                next.Handle();
        }
    }
}
