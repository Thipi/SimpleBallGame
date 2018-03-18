using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public int score;
    public int bestScore;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
	// Use this for initialization
	void Start () {

        score = 0;
        PlayerPrefs.SetInt("score", score); //score will be stored as score-key with the value of the score(it is 0 in the start)

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void incrementScore() //Adds 1 score
    {
        score += 1;
    }

    public void startScore() //Calls the function that adds the score with the InvokeRepeating.
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    public void StopScore() //Saves all the data and stops giving score
    {
        CancelInvoke("incrementScore");

        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("bestScore"))
        {
            if(score > PlayerPrefs.GetInt("bestScore")) //if the current score is greater than previous highscore, set the best score as the current score
            {
                PlayerPrefs.SetInt("bestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
    }
}
