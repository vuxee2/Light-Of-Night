using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    public float forceAmount;

    private Rigidbody2D rb;

    private bool grounded;
    private bool isSlowed;

    public CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        forceAmount = 15f;

        isSlowed = true;

        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(grounded);
        if(rb.velocity != Vector2.zero && grounded)
        {
            Vector2 direction = rb.velocity.normalized;
            
            rb.AddForce(direction * forceAmount);
        }

        if(Input.GetMouseButtonDown(0) && Srca.health > 0)
        {
            isSlowed = true;
            SoundManager.PlaySound("slowMotion", 1.5f);
        } 
        else if(Input.GetMouseButtonUp(0))
        {
            SoundManager.PlaySound("slowMoOut", 1.5f);
            isSlowed = false;
        } 

        if(!isSlowed)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0.02f;
            Time.fixedDeltaTime = Time.deltaTime * 0.02f;
        }

        if(vcam.m_Lens.OrthographicSize + 5 > rb.velocity.magnitude)
            vcam.m_Lens.OrthographicSize = Mathf.Min(15f, Mathf.Max(7f, vcam.m_Lens.OrthographicSize - Time.deltaTime * 3));
        else if(vcam.m_Lens.OrthographicSize < rb.velocity.magnitude)
            vcam.m_Lens.OrthographicSize = Mathf.Min(15f, Mathf.Max(7f, vcam.m_Lens.OrthographicSize + Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Ground")
        {
            grounded = false;
            //StartCoroutine(WaitForSlowMotion());
        }
    }

    private IEnumerator WaitForSlowMotion()
    {
        yield return new WaitForSeconds(2);
        isSlowed = true;
        yield return new WaitForSeconds(5f * 0.02f);
        isSlowed = false;
    }
}
