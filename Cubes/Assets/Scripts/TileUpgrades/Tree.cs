using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Resource
{
    public override BuildingMaterial TakeMaterial()
    {
        throw new System.NotImplementedException();
    }

    public override bool WorkUpgrade(float workDone)
    {
        CurrentWorkTowardsHarvest += workDone;
        if (CurrentWorkTowardsHarvest >= WorkRequiredToHarvest)
        {
            Debug.Log("Harvest complete");
            return true;
        }

        Debug.Log("Working " + UpgradeType + ". work = " + CurrentWorkTowardsHarvest + "/"+WorkRequiredToHarvest);
        return false;
    }
}
