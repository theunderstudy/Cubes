using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Resource
{
    
    public override bool HarvestResource(float workDone)
    {
        CurrentWorkTowardsHarvest += workDone;
        if (CurrentWorkTowardsHarvest >= WorkRequiredToHarvest)
        {
            return true;
        }
        return false;
    }
}
