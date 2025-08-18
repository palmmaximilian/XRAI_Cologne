
using UnityEngine;

public class TomatoController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;
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
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("FanOn");
        }
    }


}

