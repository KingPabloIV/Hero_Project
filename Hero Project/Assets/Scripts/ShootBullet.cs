using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{

    public GameObject eggBullet;
    public float maxCooldown;
    private static float currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = maxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && currentCooldown <= 0)
        {
            Instantiate(eggBullet, transform.position, transform.rotation);
            currentCooldown = maxCooldown;
            TextEditor.numOfBullets++;
        }
        if(currentCooldown > 0)
            currentCooldown -= Time.deltaTime;
        if(currentCooldown < 0)
            currentCooldown = 0;
    }

    public static float getCurrentCooldown()
    {
        return currentCooldown;
    }
}
