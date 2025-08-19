using UnityEngine;

public class GameManagerMessenger : MonoBehaviour
{
    public void GoNextLevel()
    {
        GameObject gameManagerObj = GameObject.Find("GameManagerObj");
        GameManager gameManagerScript = gameManagerObj.GetComponent<GameManager>();
        if (gameManagerScript != null)
        {
            gameManagerScript.NextChallenge();
        }
    }
}