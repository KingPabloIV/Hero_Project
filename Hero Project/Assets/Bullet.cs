using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int bulletSpeed = 40;
    private GameObject player;
    private Vector3 boundsSize;
    private Bounds worldBounds;

    void Start()
    {
        player = GameObject.Find("Player");
        transform.rotation = player.transform.rotation;
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        updateWorldBounds();
        if(!worldBounds.Contains(transform.position))
        {
            Destroy(transform.parent.gameObject);
            TextEditor.numOfBullets--;
        }
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //Debug.Log("Enemy hit");
        }
    }

    private void updateWorldBounds()
    {
        boundsSize = WorldBounds.getWorldBounds.size;
        boundsSize.x *= 1.2f;
        boundsSize.y *= 1.2f;
        worldBounds = new Bounds(worldBounds.center, boundsSize);
    }
}
