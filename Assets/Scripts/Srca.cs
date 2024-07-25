using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Srca : MonoBehaviour
{
    public Image[] srca;

    public static bool trigger;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;

        srca[0].color = new Color(srca[0].color.r, srca[0].color.g, srca[0].color.b, 1f);
        srca[1].color = new Color(srca[1].color.r, srca[1].color.g, srca[1].color.b, 1f);
        srca[2].color = new Color(srca[2].color.r, srca[2].color.g, srca[2].color.b, 1f);

        StartCoroutine(ChangeTransp());
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            TriggerSrca();
            trigger = false;
        }
    }

    private IEnumerator ChangeTransp()
    {
        yield return new WaitForSeconds(3);
        for(int i=0;i<health;i++)
        {
            srca[i].color = new Color(srca[i].color.r, srca[i].color.g, srca[i].color.b, .05f);
        }
        for(int i=health;i<3;i++)
        {
            srca[i].color = new Color(srca[i].color.r, srca[i].color.g, srca[i].color.b, 0f);
        }
    }

    public void TriggerSrca()
    {
        for(int i=0;i<health;i++)
        {
            srca[i].color = new Color(srca[i].color.r, srca[i].color.g, srca[i].color.b, 1f);
        }
        for(int i=health;i<3;i++)
        {
            srca[i].color = new Color(255, 0, 0, 0.1f); //crveno??
        }

        StartCoroutine(ChangeTransp());
    }
}
