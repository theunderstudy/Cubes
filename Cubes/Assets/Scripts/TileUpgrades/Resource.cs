using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Resource : CubeUpgrade
{
    public float WorkRequiredToHarvest;
    protected float CurrentWorkTowardsHarvest;
    public int UnitsPerHarvest;
    public float AmountHarvested;
    public CubeUpgradeTypes UpgradeType;

    public abstract bool HarvestResource(float workDone);

    public virtual Vector3 GetHarvestLocation() { return transform.position; }
    
}
