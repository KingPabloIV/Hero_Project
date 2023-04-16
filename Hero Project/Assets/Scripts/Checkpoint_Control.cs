using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Control : MonoBehaviour
{

    public int health;

    public SpriteRenderer render;




    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(health <= 0)
        {
            ResetCheckpoint();
        }
    }

    private void ResetCheckpoint()
    {
        health = 4;
        //transform.position = new Vector3(UnityEngine.Random.Range(spawnBounds.min.x, spawnBounds.max.x), UnityEngine.Random.Range(spawnBounds.min.y, spawnBounds.max.y), 0);
        transform.position = new Vector3(UnityEngine.Random.Range(transform.position.x - 15f, transform.position.x + 15f), UnityEngine.Random.Range(transform.position.y - 15f, transform.position.y + 15f), 0);
        //transform.Rotate(0, 0, UnityEngine.Random.Range(0, 360));
        render.color = new Color(1, 1, 1, 1);
    }
}
