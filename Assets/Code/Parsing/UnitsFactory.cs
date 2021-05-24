using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Parsing
{
    public sealed class UnitsFactory
    {
        private List<IUnitFactory> factories;

        private const string parsingFailedMessage = "Failed to create unit: '{0}'";
        private const string dataFolderName = "data";
        private const string parsableString = "{{\"units\": {0}}}";

        public UnitsFactory()
        {
            factories = new List<IUnitFactory>();
        }

        public void AddFactory(IUnitFactory factory)
        {
            if(!factories.Contains(factory))
                factories.Add(factory);
        }

        public List<IUnit> ParseFile(string filename)
        {
            var result = new List<IUnit>();
            var units = ParseString(File.ReadAllText(Path.Combine(Application.dataPath, dataFolderName, filename)));

            foreach(var currentUnit in units)
            {
                IUnit unit = null;
                foreach(var factory in factories)
                {
                    if(factory.TryConstruct(currentUnit.unit, out unit))
                    {
                        break;
                    }
                }
                if(unit != null)
                    result.Add(unit);
                else
                    Debug.Log(String.Format(parsingFailedMessage, currentUnit.unit.type));
            }

            return result;
        }

        public List<Unit> ParseString(string data)
        {
            return JsonUtility.FromJson<Units>(String.Format(parsableString, data)).units;
        }

        private class Units
        {
            public List<Unit> units;
        }
    }
}
