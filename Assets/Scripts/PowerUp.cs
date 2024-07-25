using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject player;

    private bool shouldFollow = false;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = .1f;

    public GameObject particleGreen;
    public GameObject particleRed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(shouldFollow)
        {
            Vector3 targetPosition = player.transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        if(Vector3.Distance(transform.position, player.transform.position) > 150f)
        {
            Destroy(gameObject);
        }
    }

    public enum types {SpeedUp, Boost, Enemy, BoostBig, SpeedUpSmall};
    public types type;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if(type == types.SpeedUp)
            {
                player.GetComponent<Movement>().forceAmount += 3;
                SoundManager.PlaySound("speedUpCollect", 1f);
            }
            else if(type == types.SpeedUpSmall)
            {
                player.GetComponent<Movement>().forceAmount += .5f;
                SoundManager.PlaySound("speedUpCollect", 2f);
            }
            else if(type == types.Boost)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 40f, ForceMode2D.Impulse);
                SoundManager.PlaySound("boostUpCollect", 1f);
                Instantiate(particleGreen, player.transform.position, Quaternion.identity);
            }
            else if(type == types.BoostBig)
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80f, ForceMode2D.Impulse);
                SoundManager.PlaySound("boostUpCollect", 1.5f);
                Instantiate(particleGreen, player.transform.position, Quaternion.identity);
            }
            else if(type == types.Enemy)
            {
                player.GetComponent<Rigidbody2D>().gravityScale += .5f;
                Srca.health --;
                Srca.trigger = true;
                SoundManager.PlaySound("damage", 1.5f);
                Instantiate(particleRed, player.transform.position, Quaternion.identity);
                CamShake.shake = true;
            }

            Destroy(gameObject);
        }
        else if(coll.gameObject.tag == "PlayerMagnet")
        {
            if(type == types.SpeedUpSmall)
            {
                shouldFollow = true;
            }
        }
    }
}
