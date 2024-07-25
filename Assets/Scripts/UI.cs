using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public Rigidbody2D target;

    //public TMP_Text speedText;
    //private float speed;
    
    public TMP_Text heightText;
    private float height;

    public GameObject drawALine;

    // Start is called before the first frame update
    void Start()
    {
        drawALine.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //speed = target.velocity.magnitude;
        //speedText.text = ((int)speed).ToString();

        height = target.position.y;
        heightText.text = ((int)height).ToString() + "m";

        if(Input.GetMouseButtonUp(0))
        {
            drawALine.SetActive(false);
        }
    }
}
