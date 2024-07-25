using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrcSFX;

    public static AudioClip ballRollOff;
    //Collectibles
    public static AudioClip boostUpCollect;
    public static AudioClip speedUpCollect;
    public static AudioClip damage;

    public static AudioClip slowMotion;
    public static AudioClip slowMoOut;
    // Start is called before the first frame update
    void Start()
    {
        audioSrcSFX = gameObject.GetComponent<AudioSource>();

        ballRollOff  = Resources.Load<AudioClip>("ballRollOff");
        
        boostUpCollect = Resources.Load<AudioClip>("boostUpCollect");
        speedUpCollect = Resources.Load<AudioClip>("speedUpCollect");
        damage = Resources.Load<AudioClip>("damage");

        slowMotion = Resources.Load<AudioClip>("slowMotion");
        slowMoOut = Resources.Load<AudioClip>("slowMoOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip, float pitch)
    {
        switch(clip)
        {
            case "ballRollOff":
                audioSrcSFX.GetComponent<AudioSource>().pitch = pitch;
                audioSrcSFX.PlayOneShot(ballRollOff);
                break;
            case "boostUpCollect":
                audioSrcSFX.GetComponent<AudioSource>().pitch = pitch;
                audioSrcSFX.PlayOneShot(boostUpCollect);
                break;
            case "speedUpCollect":
                audioSrcSFX.GetComponent<AudioSource>().pitch = pitch;
                audioSrcSFX.PlayOneShot(speedUpCollect);
                break;
            case "damage":
                audioSrcSFX.GetComponent<AudioSource>().pitch = pitch;
                audioSrcSFX.PlayOneShot(damage);
                break;
            case "slowMotion":
                audioSrcSFX.GetComponent<AudioSource>().pitch = pitch;
                audioSrcSFX.PlayOneShot(slowMotion);
                break;
            case "slowMoOut":
                audioSrcSFX.GetComponent<AudioSource>().pitch = pitch;
                audioSrcSFX.PlayOneShot(slowMoOut);
                break;
        }

    }

}
