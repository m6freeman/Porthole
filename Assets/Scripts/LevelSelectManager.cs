using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;


public class LevelSelectManager : MonoBehaviour
{

    [System.Serializable]
    public class Level
    {

        public string LevelText;
        public string ScoreText;
        public bool IsInteractable;
        public Button.ButtonClickedEvent OnClickEvent;
    }

    public List<Level> ListOfLevels;
    public GameObject LevelButton;
    public Transform ButtonPanel;
    public Color32 Color = new Color32();

    // Use this for initialization
    void Start()
    {
        FillList();
    }



    void FillList()
    {

        List<Level> ResortedList = new List<Level>();
        foreach (var level in ListOfLevels)
        {
            if (GameManager.gameManager.GetCurrentLevelIndex() >= Int32.Parse(level.LevelText))
            {
                ResortedList.Insert(0, level);
            }
            else
            {
                ResortedList.Add(level);
            }
        }

        foreach (var level in ResortedList)
        {
            GameObject newButton = Instantiate(LevelButton) as GameObject;
            LevelButtonScript button = newButton.GetComponent<LevelButtonScript>();

            // All button numbers greater than CurrentLevelIndex remain uninteractable
            if (GameManager.gameManager.GetCurrentLevelIndex() >= Int32.Parse(level.LevelText))
            {
                level.IsInteractable = true;
                button.GetComponent<Button>().interactable = level.IsInteractable;
                button.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(level.LevelText));
                button.leveltext.text = level.LevelText;
                button.scoretext.text = GameManager.gameManager.GetPointsEarned(level.LevelText).ToString() + "/" +
                                        GameManager.gameManager.GetMaxPoints(level.LevelText).ToString();

            }
            else
            {
                button.lockimage.SetActive(true);
            }

            // Insert created Button into ButtonPanel
            newButton.GetComponent<Image>().color = Color;
            newButton.transform.SetParent(ButtonPanel, false);
        }
    }
}
