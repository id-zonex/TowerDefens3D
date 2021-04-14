using UnityEngine;

public abstract class PlayerMover : MonoBehaviour
{
    public void ControleOnlyInUpdate()
    {
        if (!Time.inFixedTimeStep)
            ControleUpdate();
        else
            throw new System.Exception("please calling this function in \"Update\" ");
    }

    public void ControleOnlyInFixedUpdate()
    {
        if (Time.inFixedTimeStep)
            ControleFixedUpdate();
        else
            throw new System.Exception("please calling this function in \"FixedUpdate\" ");
    }

    protected abstract void ControleUpdate();
    protected abstract void ControleFixedUpdate();
}
