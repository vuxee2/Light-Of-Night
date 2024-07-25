using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRollAudio : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject rollAudio;
    // Start is called before the first frame update
    void Start()
    {
        rollAudio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rollAudio.GetComponent<AudioSource>().pitch = 1f + rb.velocity.magnitude / 30f;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Ground")
        {
            rollAudio.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Ground")
        {
            rollAudio.SetActive(false);
            SoundManager.PlaySound("ballRollOff", 1f + rb.velocity.magnitude / 30f);
        }
    }
}
