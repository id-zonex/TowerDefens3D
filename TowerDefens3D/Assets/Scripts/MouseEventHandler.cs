using UnityEngine;
using UnityEngine.Events;

public class MouseEventHandler : MonoBehaviour
{
    public static UnityAction LeftMouseButtonDown;
    public static UnityAction LeftMouseButtonUp;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            LeftMouseButtonDown?.Invoke();

        if (Input.GetMouseButtonUp(0))
            LeftMouseButtonUp?.Invoke();
    }
}
