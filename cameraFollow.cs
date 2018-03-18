using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    public GameObject target; //ball/player etc. Assign wich gameobject the camera will follow
    Vector3 offset; //distance between the camera and the target (var 1.)
    public float lerpRate; //the rate of the camera. 
    public bool gameOver;

	// Use this for initialization
	void Start () {

        offset = target.transform.position - transform.position; //pallon sijainti miinus kameran sijainti = pallon ja kameran etäisyys. Pitää etäisyyden samana.
        gameOver = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!gameOver)
        {
            Follow();
        }

	}

    void Follow() //storing the position of the camera in the temporary value. This cannot be done in start function.
    {
        Vector3 position = transform.position;
        Vector3 targetPosition = target.transform.position - offset;
        position = Vector3.Lerp(position, targetPosition, lerpRate * Time.deltaTime); //current position, targetPosition, the rate the camera moves multiplied by Time.deltaTime
        transform.position = position; 
    }
}
