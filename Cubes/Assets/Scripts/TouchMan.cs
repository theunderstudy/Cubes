using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint
{
    public TouchPoint(Vector3 pos)
    {
        ScreenPos = pos;
    }
    public Vector3 ScreenPos;
}
public struct Key
{
    public Key(int x, int z)
    {
        X = x;
        Z = z;
    }
    public int X;
    public int Z;
}

public class TouchMan : MonoBehaviour
{
    private TouchPoint touch;
    private Ray _ray;
    private RaycastHit _hit;
    public LayerMask RaycastLayer, GroundCubeLayer;
    private Collider[] colliders;

    public delegate void InteractionFunction();
    public InteractionFunction PlayerAction;


    #region TempActions
    public Tree TreePrefab;
    public CubeUpgrade SelectedUpgrade;
    #endregion
    private void Start()
    {
        PlayerAction = PlaceCube;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerAction = PlaceCube;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerAction = UpgradeTile;
            SelectedUpgrade = TreePrefab;
        }
        touch = GetPointer();
        if (touch != null)
        {
            PlayerAction();
        }
    }
    private void PlaceCube()
    {
        _ray = Camera.main.ScreenPointToRay(touch.ScreenPos);
        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, RaycastLayer))
        {
            //sphere cast to check for nearby cube
            colliders = Physics.OverlapSphere(_hit.point, 1, GroundCubeLayer);
            if (colliders.Length > 0)
            {
                LandMan.Instance.AddCube(new Key(Mathf.RoundToInt(_hit.point.x), Mathf.RoundToInt(_hit.point.z)));
            }
        }
    }
    private void UpgradeTile()
    {
        _ray = Camera.main.ScreenPointToRay(touch.ScreenPos);
        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, GroundCubeLayer))
        {
            _hit.transform.GetComponent<GroundCube>().UpgradeTile(Instantiate(SelectedUpgrade));
        }
    }

    private TouchPoint GetPointer()
    {
        if (Input.touchCount != 0)
        {
            TouchPoint _input = new TouchPoint(Input.GetTouch(0).position);
            return _input;
        }
        if (Input.GetMouseButton(0))
        {
            TouchPoint _input = new TouchPoint(Input.mousePosition);
            return _input;
        }
        return null;
    }
}
