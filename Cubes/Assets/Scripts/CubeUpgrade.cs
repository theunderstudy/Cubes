﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeUpgradeTypes
{
    Nil=0,
    //resources
    Tree=100,
    //Buildings
    StoreHouse = 200

}
public abstract class CubeUpgrade : MonoBehaviour
{
    public CubeUpgradeTypes UpgradeType;
}
