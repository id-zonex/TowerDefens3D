using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlug : MonoBehaviour
{
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _redMaterial;

    public void SetRedMaterial()
    {
        SetMaterial(_redMaterial);
    }

    public void SetGreenMaterial()
    {
        SetMaterial(_greenMaterial);
    }

    private void SetMaterial(Material material)
    {
        SetMaterialInChinds(gameObject.GetComponentsInChildren<MeshRenderer>(), material);
    }

    private void SetMaterialInChinds(MeshRenderer[] childs, Material material)
    {
        foreach (MeshRenderer child in childs)
        {
            if(child != null)
            {
                child.material = material;
            }
        }
    }
}
