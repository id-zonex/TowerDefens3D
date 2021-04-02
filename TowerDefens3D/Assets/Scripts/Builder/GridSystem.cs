using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int XScale = 19;
    [SerializeField] private int ZScale = 11;

    private static  int _xScale;
    private static int _zScale;

    private static Vector3[,] _grid;

    private void Start()
    {
        _xScale = XScale;
        _zScale = ZScale;

        transform.position = new Vector3(-XScale, 0, -ZScale);

        _grid = new Vector3[XScale * 2, ZScale * 2];

        GenerateGrid();
    }

    public static Vector3 GetPointOnGrid(Vector3 worldPosition)
    {
        var x = Mathf.RoundToInt((worldPosition.x + _xScale));
        var z = Mathf.RoundToInt((worldPosition.z + _zScale));

        Vector3 result;

        try
        {
            result = _grid[x, z];
        }
        catch (System.IndexOutOfRangeException)
        {
            return new Vector3();
        }

        return result;
    }

    private void GenerateGrid()
    {
        for(int x = 0; x < _grid.GetLength(0); x++)
        {
            for (int z = 0; z < _grid.GetLength(1); z++)
            {
                _grid[x, z] = new Vector3(transform.position.x + x, 0, transform.position.z + z);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(_grid != null)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                for (int z = 0; z < _grid.GetLength(1); z++)
                {
                    Gizmos.color = new Color(0, 0, 0);

                    //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), new Vector3(transform.position.x + x, 0, transform.position.z + z), Quaternion.identity);
                    Gizmos.DrawWireSphere(new Vector3(transform.position.x + x, 0, transform.position.z + z), 0.2f);
                }
            }
        }
    }
}
