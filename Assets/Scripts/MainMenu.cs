using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private bool isStarted;

    public GameObject startCircle;

    public TMP_Text bestTime;

    public GameObject musicX;
    public GameObject soundX;

    private void Start()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.deltaTime;

        isStarted = false;

        if(PlayerPrefs.HasKey("highScoreTime"))
        {
            float time = PlayerPrefs.GetFloat("highScoreTime");
            string timeTxt;
            if((int)time / 60 >= 1)
                timeTxt = ((int)time / 60).ToString() + "min " + ((int)time % 60).ToString() + "sec";
            else timeTxt = ((int)time % 60).ToString() + "sec";

            bestTime.text = "Best time:" + "\n" + timeTxt;
        }
        else
        {
            bestTime.text = "Play to get" + "\n" + "the best time";
        }

        musicX.SetActive(PlayerPrefs.GetInt("isMusicOn") > 0 ? false : true);
        soundX.SetActive(PlayerPrefs.GetInt("isSoundOn") > 0 ? false : true);
    }

    private void Update()
    {
        if (Input.anyKey && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0) && !Input.GetMouseButton(0) && !isStarted)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void StartGame()
    {
        isStarted = true;
        startCircle.SetActive(true);
        StartCoroutine(StartGameDelay());
    }
    private IEnumerator StartGameDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }

    public void MusicOnOff()
    {
        musicX.SetActive(!musicX.activeSelf);
        PlayerPrefs.SetInt("isMusicOn", musicX.activeSelf ? 0 : 1);
    }
    public void SFXOnOff()
    {
        soundX.SetActive(!soundX.activeSelf);
        PlayerPrefs.SetInt("isSoundOn", soundX.activeSelf ? 0 : 1);
    }
}
