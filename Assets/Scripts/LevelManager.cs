using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager levelManager;
    public int currentLevelIndex;
    public string currentLevelName;
    public int maxPoints;
    public int pointsEarned;
    public bool ballIsMoving = false;


	// Use this for initialization
	void Awake ()
    {
        levelManager = this;
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        currentLevelName = SceneManager.GetActiveScene().name;
	}

    void Start()
    {
        // Counts all gameobjects tagged with Portal and divides by 2 (maxPoints = number of portal pairs)
        GameObject[] numberOfPortals = new GameObject[GameObject.FindGameObjectsWithTag("Portal").Length];
        maxPoints =  (numberOfPortals.Length) / 2;

        // Save the max points (in relation to the levels name)
        GameManager.gameManager.SaveMaxPoints(currentLevelName, maxPoints);
         
    }

    
}
