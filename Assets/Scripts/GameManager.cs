using UnityEngine;
using Meta.XR.MRUtilityKit;


public class GameManager : MonoBehaviour
{
    public GameObject[] challenge;
    public OVRPassthroughLayer passthroughLayer; // assign in Inspector
    public Texture2D[] luts;
    public FindSpawnPositions spawnFinder;  // assign in Inspector
    int challengeIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        passthroughLayer.SetColorLut(new OVRPassthroughColorLut(luts[challengeIndex]));
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
                
                NextChallenge();
            }
            
        }

    }

    public void NextChallenge()
    {
        Destroy(challenge[challengeIndex]);
        challengeIndex++;
        spawnFinder.SpawnObject = challenge[challengeIndex];
        spawnFinder.StartSpawn();
        passthroughLayer.SetColorLut(new OVRPassthroughColorLut(luts[challengeIndex]));
        Debug.Log("Snap event triggered!");
        
    }




}
