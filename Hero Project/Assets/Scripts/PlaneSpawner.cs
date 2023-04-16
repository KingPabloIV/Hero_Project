using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{

    public GameObject[] planes;
    private Vector3 spawnBoundsSize;
    private Bounds spawnBounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnBounds = new Bounds(); 
        updateSpawnBounds();
        Debug.Log(spawnBounds.size.ToString());
        for(int i = 0; i < planes.Length; i++)
        {
            generatePlane(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateSpawnBounds();
    }

    void generatePlane(int index)
    {
        updateSpawnBounds();
        Vector3 pos = new Vector3(UnityEngine.Random.Range(spawnBounds.min.x, spawnBounds.max.x), UnityEngine.Random.Range(spawnBounds.min.y, spawnBounds.max.y), 0);
        Instantiate(planes[index], pos, new Quaternion(0, 0, 0, 1));
        // Instantiate(planes[index], transform.position, transform.rotation);
        planes[index].transform.Rotate(0, 0, UnityEngine.Random.Range(0, 360));
    }

    private void updateSpawnBounds()
    {
        spawnBoundsSize = WorldBounds.getWorldBounds.size;
        spawnBoundsSize.x *= 0.9f;
        spawnBoundsSize.y *= 0.9f;
        spawnBounds = new Bounds(WorldBounds.getWorldBounds.center, spawnBoundsSize);
        
    }
}
