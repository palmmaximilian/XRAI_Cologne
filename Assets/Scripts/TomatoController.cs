
using UnityEngine;

public class TomatoController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject AnimatedGameObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRace()
    {
        // Assuming you have an Animator component attached to the same GameObject
        Animator animator = AnimatedGameObject.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("FanOn");
        }
    }


}

