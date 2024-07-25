using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public GameObject smallSpeedUp;

    private Rigidbody2D rb;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 1f, .25f);   
        rb = target.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnPowerUp()
    {
        Vector2 direction = rb.velocity.normalized;
        Vector2 spawnPos = new Vector2(direction.x * (50f + target.position.x), Random.Range(-10f, 50f) + target.position.y);
        Instantiate(smallSpeedUp, spawnPos, Quaternion.identity);

        spawnPos = new Vector2(direction.x * (50f + target.position.x), Random.Range(-10f, 50f) + target.position.y);
        Instantiate(powerUps[Random.Range(0,15)], spawnPos, Quaternion.identity);
    }
}
