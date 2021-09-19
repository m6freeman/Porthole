using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfLevelSpashScreen : MonoBehaviour
{

    public Text FinishedText;
    public Text LevelName;
    public Text LevelScore;
 

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
        LevelName.text = "Level " + SceneManager.GetActiveScene().name + " Complete";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            LevelScore.text = GameManager.gameManager.GetPointsEarned(LevelManager.levelManager.currentLevelName).ToString() + " out of " + GameManager.gameManager.GetMaxPoints(LevelManager.levelManager.currentLevelName).ToString();

            if (GameManager.gameManager.GetPointsEarned(LevelManager.levelManager.currentLevelName) % GameManager.gameManager.GetMaxPoints(LevelManager.levelManager.currentLevelName) == 0)
            {
                FinishedText.text = "Perfect!";
            }
            else
            {
                FinishedText.text = "Well Done";
            }

        }
    }

    

    

}
