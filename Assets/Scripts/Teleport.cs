using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    public GameObject otherPortal;
    bool hasPoint = false;
    float zValue;



    void OnTriggerEnter(Collider ball)
    {
        if (ball.tag == "Ball")
        {
            zValue = otherPortal.transform.parent.eulerAngles.z;

            ScorePoint();

            switch ((int)zValue)
            {
                case 0:     // UP
                    ball.transform.position = otherPortal.transform.position;
                    ball.GetComponent<Rigidbody>().velocity = new Vector2(0, GameManager.gameManager.ballSpeed);
                    break;

                case 90:    // LEFT
                    ball.transform.position = otherPortal.transform.position;
                    ball.GetComponent<Rigidbody>().velocity = new Vector2(-GameManager.gameManager.ballSpeed, 0);
                    break;

                case 180:   // DOWN
                    ball.transform.position = otherPortal.transform.position;
                    ball.GetComponent<Rigidbody>().velocity = new Vector2(0, -GameManager.gameManager.ballSpeed);
                    break;

                case 270:   // RIGHT
                    ball.transform.position = otherPortal.transform.position;
                    ball.GetComponent<Rigidbody>().velocity = new Vector2(GameManager.gameManager.ballSpeed, 0);
                    break;

                default:
                    Debug.Log(zValue);
                    break;
            }

        }
    }

    void ScorePoint()
    {
        if (hasPoint == false)
        {
            hasPoint = true;

            //Ensures that the maximum number of points isn't exceeded before adding to the score
            if (LevelManager.levelManager.maxPoints > LevelManager.levelManager.pointsEarned)
            {
                LevelManager.levelManager.pointsEarned++;
            }
        }
    }

}
