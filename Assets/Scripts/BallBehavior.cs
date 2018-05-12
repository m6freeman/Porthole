using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallBehavior : MonoBehaviour {

    public GameObject EndOfLevelSplashScreen;
    public AudioSource PortalSound;
    public AudioSource BeginSound;
    public AudioSource EndSound;


    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        PortalSound = audios[0];
        BeginSound = audios[1];
        EndSound = audios[2];
    }


    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Portal")
        {
            PortalSound.Play();
        }

        if (col.tag == "Respawn")
        {
            GameManager.gameManager.PlayCollideSound();
            LevelManager.levelManager.pointsEarned = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (col.tag == "Tube")
        {
            gameObject.GetComponentInParent<Animation>().Play("ballUpTube");
            EndSound.Play();
        }

        if (col.tag == "Finish")
        {
            // Compares the points for the level in the save file to the current instance of the levels points earned
            // If save file is lower, save the current level's points earned
            if (GameManager.gameManager.GetPointsEarned(LevelManager.levelManager.currentLevelName) < LevelManager.levelManager.pointsEarned)
            {
                GameManager.gameManager.SavePointsEarned(LevelManager.levelManager.currentLevelName, LevelManager.levelManager.pointsEarned);
            }

            if (GameManager.gameManager.GetCurrentLevelIndex() <= SceneManager.GetActiveScene().buildIndex) 
            {
                GameManager.gameManager.SaveCurrentLevelIndex(SceneManager.GetActiveScene().buildIndex + 1);
            }
            

            EndOfLevelSplashScreen.SetActive(true);
            GameObject.FindGameObjectWithTag("ResetButton").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("LevelSelectButton").GetComponent<Image>().enabled = false;
            gameObject.SetActive(false);
        }

    }

}
