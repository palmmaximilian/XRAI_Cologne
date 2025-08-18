using UnityEngine;
using Meta.XR.MRUtilityKit;


public class GameManager : MonoBehaviour
{
    public GameObject[] challenge;
    public FindSpawnPositions spawnFinder;  // assign in Inspector
    int challengeIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnFinder.SpawnObject = challenge[challengeIndex];
        spawnFinder.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (challengeIndex > challenge.Length)
        {
            return;
        }
        else

        {
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                challenge[challengeIndex].SetActive(false);
                NextChallenge();
            }
            
        }

    }
    
    void NextChallenge()
    {
            
            challengeIndex++;
            spawnFinder.SpawnObject = challenge[challengeIndex];
            spawnFinder.StartSpawn();
        
    }




}
