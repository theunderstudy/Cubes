using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
public class LandMan : Singleton<LandMan>
{
    public Dictionary<Key, GroundCube> CurrentCubes = new Dictionary<Key, GroundCube>();
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

    
}
