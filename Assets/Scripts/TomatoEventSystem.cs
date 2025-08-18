using UnityEngine;
using UnityEngine.Events;

public class EventSystem : MonoBehaviour
{
    public UnityEvent OnComplition;

    void Update()
    {
        // Example condition: prefab goes below y = -5
        if (transform.position.y < -5f)
        {
            OnComplition.Invoke();
        }
    }
}