using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCube : MonoBehaviour
{
    public Key Key
    {
        get;
        private set;
    }

    public CubeUpgrade CurrentUpgrade;
    public CubeUpgradeTypes CurrentUpgradeType;
    public void InitializeCube(Key key)
    {
        this.Key = key;
        transform.position = new Vector3(key.X,0,key.Z);
    }

    public void UpgradeTile(CubeUpgrade newUpgrade)
    {
        if (CurrentUpgrade)
        {
            Destroy(newUpgrade.gameObject);
            //HACK:
            return;
            Destroy(CurrentUpgrade);
        }

        CurrentUpgrade = newUpgrade;
        CurrentUpgrade.MyCube = this;
        CurrentUpgradeType = newUpgrade.UpgradeType;
        newUpgrade.transform.parent = transform;
        newUpgrade.transform.localPosition = Vector3.zero;           
    }

    public  void UpgradeTile(CubeUpgradeTypes newUpgradeType)
    {
        if (CurrentUpgrade)
        {
            Destroy(CurrentUpgrade.gameObject);
            CurrentUpgrade = null;
            CurrentUpgradeType = CubeUpgradeTypes.Nil;
            //HACK:
            return;
            Destroy(CurrentUpgrade);
        }
    }
}
