using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Handler : MonoBehaviour
{

    public GameObject[] checkpoints;
    private Vector3 spawnBoundsSize;
    private Bounds spawnBounds;
    private GameObject[] activeStatus;
    private static bool isRandom;

    private bool isShowing;

    //public Transform checkpointpos;

    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        isRandom = false;
        isShowing = true;
        spawnBounds = new Bounds();
        updateSpawnBounds();
        for (int i = 0; i < checkpoints.Length; i++)
        {
            generateCheckpoint();
            checkpoints[i].GetComponent<SpriteRenderer>().sprite = spriteArray[i];
        }
        activeStatus = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isShowing = !isShowing;
            
            for (int i = 0; i < activeStatus.Length; i++)
            {
                activeStatus[i].SetActive(isShowing);
                //checkpoints[i].SetActive(isShowing);
                
                Debug.Log("isShowing = " + isShowing);
            }


        }



        if (Input.GetKeyDown(KeyCode.J))
        {
            isRandom = !isRandom;
        }
        //checkpointpos.position = checkpoints[0].transform.position;
        //Debug.Log("checkpointpos = " + checkpointpos.position);
        if(Input.GetKey("escape"))
        {
            Application.Quit();   
        }
    }

    void generateCheckpoint()
    {
        updateSpawnBounds();
        Vector3 pos = new Vector3(UnityEngine.Random.Range(spawnBounds.min.x, spawnBounds.max.x), UnityEngine.Random.Range(spawnBounds.min.y, spawnBounds.max.y), 0);
        Instantiate(checkpoints[0], pos, new Quaternion(0, 0, 0, 1));
        // Instantiate(planes[index], transform.position, transform.rotation);
        checkpoints[0].transform.Rotate(0, 0, UnityEngine.Random.Range(0, 360));
    }

    private void updateSpawnBounds()
    {
        spawnBoundsSize = WorldBounds.getWorldBounds.size;
        spawnBoundsSize.x *= 0.9f;
        spawnBoundsSize.y *= 0.9f;
        spawnBounds = new Bounds(WorldBounds.getWorldBounds.center, spawnBoundsSize);

    }

    public static bool getIsRandom()
    {
        return isRandom;
    }


}
