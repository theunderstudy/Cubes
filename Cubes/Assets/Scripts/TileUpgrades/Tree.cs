using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tree : Resource
{
   
    public override bool WorkUpgrade(float workDone)
    {
        CurrentWorkTowardsHarvest += workDone;
        if (CurrentWorkTowardsHarvest >= WorkRequiredToHarvest)
        {
            Debug.Log("Harvest complete");
            UpdateModel();
            return true;
        }

        Debug.Log("Working " + UpgradeType + ". work = " + CurrentWorkTowardsHarvest + "/"+WorkRequiredToHarvest);
        return false;
    }

    private void UpdateModel()
    {
        //deactivate the tree
        UpgradeModels[0].SetActive(false);
        //activate the log
        UpgradeModels[1].SetActive(true);
    }

    public override BuildingMaterial TakeMaterial(Transform carryPos)
    {
        //deparent the log
        //lmao this will all have to change
        BuildingMaterial _log = UpgradeModels[1].GetComponent<BuildingMaterial>();
        _log.transform.parent = carryPos;//the log
        _log.transform.DOLocalMove(Vector3.zero,0.5f);
        _log.transform.DOLocalRotate(Vector3.zero,0.5f);
        MyCube.UpgradeTile(CubeUpgradeTypes.Nil);
        return _log;
    }

}
