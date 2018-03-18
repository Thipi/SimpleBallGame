using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //THIS IS HOW TO LOAD SCENES!

public class UImanager : MonoBehaviour {

    public static UImanager instance; //if I want to access this script elsewhere this is imperal! This is made singleton. 

    //references to UI objects
    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text BestScore1;
    public Text BestScore2;

    void Awake()
    {
        if(instance == null) //if the instance is null we want to make this UI the instance. And there can be  only one. ks. rivi 8
        {
            instance = this; 
        }
    }

	// Use this for initialization
	void Start () {
        BestScore2.text = "Hich Score:" + PlayerPrefs.GetInt("bestScore"); //string given before playerprefs so ToString not needed

    }

    public void GameStart()
    {
        BestScore1.text = PlayerPrefs.GetInt("bestScore").ToString(); //Changes the int-value to String-value temporarely! IMPORTANT!
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("UpPanel");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        BestScore2.text = PlayerPrefs.GetInt("bestScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void reset()
    {
        //reload the scene
        SceneManager.LoadScene(0); //To get rid of all the blabla use this command to load scenes.
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
