using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Handler : MonoBehaviour
{

    public GameObject[] checkpoints;
    private Vector3 spawnBoundsSize;
    private Bounds spawnBounds;

    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        spawnBounds = new Bounds();
        updateSpawnBounds();       
        for(int i = 0; i < checkpoints.Length; i++)
        {
            generateCheckpoint();
            checkpoints[i].GetComponent<SpriteRenderer>().sprite = spriteArray[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            
            for(int i = 0; i < checkpoints.Length; i++)
            {
                checkpoints[i].SetActive(true);
            }
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
}
