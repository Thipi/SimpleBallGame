using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //This script will call all the functions created in UI manager and ScoreManager
    public static GameManager instance;

    public bool gameOver;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void StartGame()
    {
        UImanager.instance.GameStart(); //This is why the singleton instance is used
        ScoreManager.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawning();
    }

   public void GameOver()
    {
        gameOver = true;
        UImanager.instance.GameOver();
        ScoreManager.instance.StopScore();
    }
}
