using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : BuildingMaterial
{
    private void Awake()
    {
        MaterialType = MaterialTypes.Wood;
    }
}
