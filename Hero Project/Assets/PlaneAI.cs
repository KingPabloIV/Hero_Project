using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAI : MonoBehaviour
{

    public int health;
    private Vector3 spawnBoundsSize;
    private Bounds spawnBounds;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        updateSpawnBounds();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
            render.color = new Color(1, 1, 1, Mathf.Pow(0.8f, 4f-health));
            Debug.Log("Health = " + health);
            Destroy(collision.gameObject.transform.parent.gameObject);
            TextEditor.numOfBullets--;
        }
        else if(collision.gameObject.tag == "Player")
        {
            TextEditor.crashes++;
            ResetPlane();
        }
        if(health <= 0)
        {
            ResetPlane();
        }
    }

    private void ResetPlane()
    {
        health = 4;
        transform.position = new Vector3(UnityEngine.Random.Range(spawnBounds.min.x, spawnBounds.max.x), UnityEngine.Random.Range(spawnBounds.min.y, spawnBounds.max.y), 0);
        transform.Rotate(0, 0, UnityEngine.Random.Range(0, 360));
        render.color = new Color(1, 1, 1, 1);
    }

    private void updateSpawnBounds()
    {
        spawnBoundsSize = WorldBounds.getWorldBounds.size;
        spawnBoundsSize.x *= 0.9f;
        spawnBoundsSize.y *= 0.9f;
        spawnBounds = new Bounds(WorldBounds.getWorldBounds.center, spawnBoundsSize);
        
    }
}
