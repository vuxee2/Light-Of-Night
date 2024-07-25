using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    public static ThemeMusic instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    void Update()
    {
        gameObject.GetComponent<AudioSource>().pitch = Time.timeScale > 0.5f ? 1 : 0.5f;

        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("isMusicOn") > 0 ? 0.2f : 0f;
    }
}
