using UnityEngine;
using Meta.XR.MRUtilityKit;


public class GameManager : MonoBehaviour
{
    public FindSpawnPositions spawnFinder; // assign in Inspector
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {   
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            spawnFinder.StartSpawn();
        }

        // Left controller "X" button
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            spawnFinder.StartSpawn();        }
        
    }



}
