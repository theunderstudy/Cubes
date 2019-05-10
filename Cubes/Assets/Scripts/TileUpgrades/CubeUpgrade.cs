using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeUpgradeTypes
{
    Nil=0,
    //resources
    Tree=100,
    //Buildings
    Construction = 200,
    StoreHouse = 201

}
public abstract class CubeUpgrade : MonoBehaviour
{
    public CubeUpgradeTypes UpgradeType;
    public GameObject[] UpgradeModels;
    public GroundCube MyCube;
    public virtual Vector3 GetWorkLocation() { return transform.position; }
    public abstract bool WorkUpgrade(float workDone);
    public abstract BuildingMaterial TakeMaterial(Transform newLogparent);
    
    protected virtual void Awake()
    {
        //set up models
        for (int i = 0; i < UpgradeModels.Length; i++)
        {
            UpgradeModels[i].SetActive(false);
        }
        UpgradeModels[0].SetActive(true);
    }
}
