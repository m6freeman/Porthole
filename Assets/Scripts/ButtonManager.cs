using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{

    void Start()
    {
        if (GameManager.gameManager.GetAudioSetting() == 0)
        {
            UnMuteSound();
        }
        else
        {
            MuteSound();
        }
    }

    public void LoadNewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelectButton()
    {
        SceneManager.LoadScene("LS");
    }

    public void OptionsMenuButton()
    {
        SceneManager.LoadScene("O");
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        GameManager.gameManager.SaveAudioSetting(0);
        Back();
    }

    public void Back()
    {
        SceneManager.LoadScene("MM");
    }

    public void Credits()
    {
        SceneManager.LoadScene("C");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayLevel(GameObject levelText)
    {
        SceneManager.LoadScene(levelText.GetComponent<Text>().text);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MM");
    }

    public void LaunchBall(GameObject ball)
    {

        if (LevelManager.levelManager.ballIsMoving == false)
        {
            ball.GetComponent<Rigidbody>().velocity = new Vector3(GameManager.gameManager.ballSpeed, 0);
            ball.GetComponent<BallBehavior>().BeginSound.Play();

            GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("ResetButton").GetComponent<Image>().enabled = true;

            LevelManager.levelManager.ballIsMoving = true;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(LevelManager.levelManager.currentLevelName);
    }

    private void MuteSound()
    {
        AudioListener.pause = true;
        GameObject.FindGameObjectWithTag("UnMutedAudio").GetComponent<Image>().enabled = false;
        GameObject.FindGameObjectWithTag("MutedAudio").GetComponent<Image>().enabled = true;
        GameManager.gameManager.SaveAudioSetting(1);
    }

    private void UnMuteSound()
    {
        AudioListener.pause = false;
        GameObject.FindGameObjectWithTag("MutedAudio").GetComponent<Image>().enabled = false;
        GameObject.FindGameObjectWithTag("UnMutedAudio").GetComponent<Image>().enabled = true;
        GameManager.gameManager.SaveAudioSetting(0);
    }
    public void AudioToggle()
    {
        if (GameManager.gameManager.GetAudioSetting() == 0)
        {
            MuteSound();
        }
        else
        {
            UnMuteSound();
        }
    }

}
