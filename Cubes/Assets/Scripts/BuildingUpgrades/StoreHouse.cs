using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHouse : Building
{
    public List<List<BuildingMaterial>> StoredResources;
    public override bool WorkUpgrade(float workDone)
    {
        throw new System.NotImplementedException();
    }

    public void StoreMaterial()
    {

    }

    public void RetrieveMaterial()
    {

    }

    public override BuildingMaterial TakeMaterial()
    {
        throw new System.NotImplementedException();
    }
}
