using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldController : MonoBehaviour
{
    // Start is called before the first frame update
    float currentCooldown;
    bool hasShield;
    ParticleSystem particles;
    void Start()
    {
        currentCooldown = Random.Range(2f, 12f);
        particles = gameObject.GetComponent<ParticleSystem>();
        hasShield = false;
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown <= 0)
        {
            hasShield = !hasShield;
            if (hasShield)
                particles.Play();
            else
                particles.Stop();
            currentCooldown = Random.Range(6f, 12f);
        }

        currentCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasShield)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Destroy(collision.gameObject.transform.parent.gameObject);
                TextEditor.numOfBullets--;
                Debug.Log("Bullet Destroyed");
            }
        }
    }
}
