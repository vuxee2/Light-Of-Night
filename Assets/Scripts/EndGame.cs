using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public float time;

    public Transform target;

    public GameObject EndScreenUI;
    public GameObject DeathScreenUI;

    public GameObject timeTxt;
    public GameObject newHighScore;

    private bool isMainMenuCalled;
    public GameObject whiteFadeIn;
    // Start is called before the first frame update
    void Start()
    {
        EndScreenUI.SetActive(false);
        DeathScreenUI.SetActive(false);
        whiteFadeIn.SetActive(false);

        time = 0f;
        isMainMenuCalled = false;
        //PlayerPrefs.SetFloat("highScoreTime", 1323);
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y >= 5000)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.deltaTime;

            EndScreenUI.SetActive(true);
            if((int)time / 60 >= 1)
                timeTxt.GetComponent<TMP_Text>().text = ((int)time / 60).ToString() + "min " + ((int)time % 60).ToString() + "sec";
            else timeTxt.GetComponent<TMP_Text>().text = ((int)time % 60).ToString() + "sec";

            if((time < PlayerPrefs.GetFloat("highScoreTime") && PlayerPrefs.HasKey("highScoreTime")) || !PlayerPrefs.HasKey("highScoreTime"))
            {
                PlayerPrefs.SetFloat("highScoreTime", time);
                newHighScore.SetActive(true);
            }
        }
        else if(!EndScreenUI.activeSelf)
        {
            time += Time.deltaTime;
            //Debug.Log(time);
        }
        if(Srca.health <= 0 || target.position.y <= -1000)
        {
            if(!EndScreenUI.activeSelf)
                DeathScreenUI.SetActive(true);
        }

        if(EndScreenUI.activeSelf || DeathScreenUI.activeSelf)
        {
            if (Input.anyKey && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0) && !Input.GetMouseButton(0) && !isMainMenuCalled)
            {
                StartCoroutine("callMainMenu");
            }
        }
    }

    private IEnumerator callMainMenu()
    {
        whiteFadeIn.SetActive(true);
        isMainMenuCalled = true;
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("MainMenu");
    }
}
