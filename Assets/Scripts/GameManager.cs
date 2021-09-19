using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public int ballSpeed = 2;
    public AudioSource CollideSound;

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        CollideSound = audios[1];
    }

    // Use this for initialization
    void Awake()
    {
        if (gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
    }

    

    void Update() // Does this need to be in Update? Can it be moved to Start? ***************
    {

        if (GetCurrentLevelIndex() < 1)
        {
            SaveCurrentLevelIndex(1);
        }

    }


    // Run this method at the Start of every new level to assign CurrentlyOnLevel being played
    public void SaveCurrentLevelIndex(int currentLevelIndex)
    {
        PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex);
    }
    public int GetCurrentLevelIndex()
    {
        if (PlayerPrefs.GetInt("CurrentLevelIndex") > 1)
        {
            return PlayerPrefs.GetInt("CurrentLevelIndex");
        }
        else
        {
            return 1;
        }

    }



    // Run this method at the Start of every new level via LevelManager
    public void SaveMaxPoints(string currentLevelName, int maxPoints)
    {
        PlayerPrefs.SetInt(currentLevelName + "MaxPoints", maxPoints);
    }
    public int GetMaxPoints(string currentLevelName)
    {
        return PlayerPrefs.GetInt(currentLevelName + "MaxPoints");
    }

    public void PlayCollideSound()
    {
        CollideSound.Play();
    }


    // Run this method at Finish of every level (if value is higher than saved value) via BallBehavior
    public void SavePointsEarned(string currentLevelName, int pointsEarned)
    {
        PlayerPrefs.SetInt(currentLevelName + "PointsEarned", pointsEarned);
    }
    public int GetPointsEarned(string currentLevelName)
    {
        return PlayerPrefs.GetInt(currentLevelName + "PointsEarned");
    }



    public void SaveAudioSetting(int set)
    {
        PlayerPrefs.SetInt("AudioSetting", set);
    }

    public int GetAudioSetting()
    {
        return PlayerPrefs.GetInt("AudioSetting");
    }


}
