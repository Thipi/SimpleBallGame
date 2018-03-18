using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

    public GameObject particle;
    [SerializeField]
    private float speed;
    bool started;
    Rigidbody ballRB;
    bool gameOver;


    // Use this for initialization
    void Awake()
    {
        ballRB = GetComponent<Rigidbody>();
    }

    void Start () {

        started = false;
        gameOver = false;
        
	}

    
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ballRB.velocity = new Vector3(speed, 0, 0); //assigning values to velocity in Rigidbody
                started = true; //now that true is declared, the game will resume to normal so the mouse down works again.

                GameManager.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red); //Red colored ray will show the ray

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))//Raycast tsekkaa pallon kohdasta, alaspäin, 1 etäisyyden verran(size of ray)
        {
            gameOver = true;
            ballRB.velocity = new Vector3(0, -25f, 0); //when ray detects that there is no platform, velocity on y axis is -25 so it goes down. if it was 25 it would go up

            Camera.main.GetComponent<cameraFollow>().gameOver = true; //when the gameOver is true here --> declare it true in the cameraFollow script
            

            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
	}
    
    void SwitchDirection()
    {
        if(ballRB.velocity.z > 0)
        {
            ballRB.velocity = new Vector3(speed, 0, 0);
        }
        else if(ballRB.velocity.x > 0)
        {
            ballRB.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "diamond")
        {
            // instatiating before destruction makes the spawn of the particle possible. If the instatiating would be after the command that destroys no instatiating will happen.
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject; // instatiating particlesystem, to the position of the diamond(not ball), no rotation.
            //we stored the particle system into a gameobject by using GameObject ---> as GameObject
            Destroy(col.gameObject); //when the ball enters the trigger it destroys the gameobj ball is colliding with
            Destroy(part, 1f); //destroys the particle after 1 second
            

        }
    }
}
