using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private Vector3 _startScale;

    public void ReturnToPool()
    {
        print("return");
        gameObject.SetActive(false);
    }

    protected virtual void SetInitialProperties()
    {
        _startScale = transform.localScale;
    }

    protected virtual void Reset()
    {
        transform.localScale = _startScale;
    }
}
