using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Parsing;

public class FileParsing : MonoBehaviour
{
    void Start()
    {
        var unitsFactory = new UnitsFactory();
        unitsFactory.AddFactory(new MagFactory());
        unitsFactory.AddFactory(new InfantryFactory());
        List<IUnit> units2 = unitsFactory.ParseFile("file.json");
    }
}
