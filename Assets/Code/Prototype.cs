using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Asteroids
{
    public static class Prototype
    {
        public static T CloneObject<T>(this T objectToClone)
        {
            if(!typeof(T).IsSerializable)
                throw new NotSupportedException($"{typeof(T).FullName} doesn't support serialization");
            
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using(var stream = new MemoryStream())
            {
                binaryFormatter.Serialize(stream, objectToClone);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
