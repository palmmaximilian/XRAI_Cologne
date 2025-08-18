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
            if(challenge[challengeIndex].activeSelf == true)
            {
                
                NextChallenge();
            }
            
        }

    }
    
    void NextChallenge()
    {
            challenge[challengeIndex].SetActive(false);
            challengeIndex++;
            spawnFinder.SpawnObject = challenge[challengeIndex];
            spawnFinder.StartSpawn();
        
    }




}
