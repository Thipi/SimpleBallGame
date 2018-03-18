using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform; //object we want to spawn

    public GameObject diamond;

    Vector3 lastPosition; // we need the last position to calculate the new position
    float size; //we need the size of the platform to determine the position where to spawn the new one
    public bool gameOver;



	// Use this for initialization
	void Start () {

        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x; //only x needed cause it is the same size to z

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

        
	}

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 2f, 0.2f); //repeats spawnPlatforms every 0.2 seconds in every 2 seconds.
    }

    public void Update()
    {

        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms"); //Opposite of Invoke so it cancels it
        }
    }

    void SpawnPlatforms()
    {
        if (gameOver) {
            return;
        }
        int randomNumber = Random.Range(0, 6); //valuates between random range of 0 and 5
        if(randomNumber < 3)
        {
            spawnX();
        }

        else if(randomNumber >= 3)
        {
            spawnZ();
        }
    }
	



    void spawnX()
    {
        Vector3 position = lastPosition;
        position.x += size; //size is added to x.position so the new platform will be created in new position based on the size.
        lastPosition = position; //last position is the current position and the new platform will get its values where to instatiate.
        Instantiate(platform, position, Quaternion.identity); //there will be  no rotation, it is instantiated we have calculated, and platform is instatiated <>

        //Checking if int is in certain range to spawn diamonds

        int rand = Random.Range(0, 4);

        if(rand < 1) //only if number is 0, spawn diamond.
        {
            // Instantiate(diamond, position, Quaternion.identity); //this line would spawn them in the same rotation that the platforms.

            Instantiate(diamond, new Vector3(position.x, position.y + 1, position.z), diamond.transform.rotation); //instatiating to same x axis. bit higher and the default rotation.

            //else don't spawn diamonds. So spawning diamonds is more rare.
        }


    }

    void spawnZ()
    {
        Vector3 position = lastPosition;
        position.z += size; //size is added to x.position so the new platform will be created in new position based on the size.
        lastPosition = position; //last position is the current position and the new platform will get its values where to instatiate.
        Instantiate(platform, position, Quaternion.identity); //there will be  no rotation, it is instantiated we have calculated, and platform is instatiated <>

        //diamondspawn in z  axis
        int rand = Random.Range(0, 4);

        if (rand < 1) //only if number is 0, spawn diamond.
        {
            Instantiate(diamond, new Vector3(position.x, position.y + 1, position.z), diamond.transform.rotation);
        }
    }
}
