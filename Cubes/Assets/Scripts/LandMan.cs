using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
public class LandMan : Singleton<LandMan>
{
    public Dictionary<Key, GroundCube> CurrentCubes = new Dictionary<Key, GroundCube>();
    private List<CubeUpgrade> ResourceList = new List<CubeUpgrade>();
    public GroundCube CubePrefab;
    public NavMeshSurface NavMesh;
    protected override void Awake()
    {
        base.Awake();
        //get any cubes
        GroundCube[] _array = FindObjectsOfType<GroundCube>();
        for (int i = 0; i < _array.Length; i++)
        {
            Key _key = new Key(Mathf.RoundToInt(_array[i].transform.position.x), Mathf.RoundToInt(_array[i].transform.position.z));
            _array[i].InitializeCube(_key);
            _array[i].transform.parent = transform;
            CurrentCubes.Add(_key, _array[i]);
        }

        NavMesh.BuildNavMesh();
    }
    public bool AddCube(Key key)
    {
        if (!CurrentCubes.ContainsKey(key))
        {
            CurrentCubes.Add(key,InstantiateCube(key));
            NavMesh.BuildNavMesh();
            return true;
        }
        return false;
    }

    private GroundCube InstantiateCube(Key pos)
    {
        GroundCube _temp = Instantiate(CubePrefab,transform);
        _temp.InitializeCube(pos);
        return _temp;
    }

    public CubeUpgrade GetNearbyUpgrade(Worker worker,CubeUpgradeTypes resourceRequested)
    {
        ResourceList.Clear();
        foreach (var item in CurrentCubes)
        {
            if (item.Value.CurrentUpgradeType == resourceRequested)
            {
                ResourceList.Add(item.Value.CurrentUpgrade);
            }
        }
        if (ResourceList.Count >0)
        {
            //get nearest upgrade
            float _dist = Mathf.Abs(Vector3.Distance(worker.transform.position , ResourceList[0].transform.position));
            CubeUpgrade _temp = ResourceList[0]; 
            for (int i = 0; i < ResourceList.Count; i++)
            {
                if (Mathf.Abs(Vector3.Distance(worker.transform.position , ResourceList[i].transform.position)) < _dist)
                {
                    _temp = ResourceList[i];
                    _dist = Mathf.Abs(Vector3.Distance(worker.transform.position, ResourceList[i].transform.position));
                }
            }
            return _temp;
        }

        return null;
    }
    
}
