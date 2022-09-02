using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private int objectIndex;
    

    private float spawnDelay = 1;
    private float spawnInterval = 1.5f;


    private PlayerControllerX playerControllerScript;
    
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
             Vector3 spawnLocation = new Vector3(3, Random.Range(8, 14), 0);


        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {


            int objectIndex = Random.Range(0, objectPrefabs.Length);

            Instantiate(objectPrefabs[objectIndex], spawnLocation, objectPrefabs[objectIndex].transform.rotation);


        }

    }
}
