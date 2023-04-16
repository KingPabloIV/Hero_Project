using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBounds : MonoBehaviour
{

    private static Vector2 worldMin, worldMax;
    private static Bounds worldBounds;
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        worldBounds = new Bounds(Vector3.zero, Vector3.one);
        updateWorldBounds();
        // wolrdMin = 
    }

    // Update is called once per frame
    void Update()
    {
        updateWorldBounds();
    }

    public static Vector2 getWorldMin
    {    get { return worldMin; }    }
    public static Vector2 getWorldMax
    {    get { return worldMax; }    }

    public static Bounds getWorldBounds
    {    get { return worldBounds; } }


    private void updateWorldBounds()
    {
        float maxY = cam.orthographicSize;
        float maxX = cam.orthographicSize * cam.aspect;
        float sizeX = maxX * 2;
        float sizeY = maxY * 2;
        float sizeZ = Math.Abs(cam.farClipPlane - cam.nearClipPlane);


        Vector3 center = cam.transform.position;
        center.z = 0.0f;

        worldBounds.center = center;
        worldBounds.size = new Vector3(sizeX, sizeY, sizeZ);
        worldMin = new Vector2(worldBounds.min.x, worldBounds.min.y);
        worldMax = new Vector2(worldBounds.max.x, worldBounds.max.y);
    }
}
