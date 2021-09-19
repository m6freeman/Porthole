using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBox : MonoBehaviour
{

    public int rotationDirection = -1; // -1 for clockwise
                                       //  1 for anti-clockwise

    public int rotationStep = 10;    // should be less than 90



    private Vector3 currentRotation, targetRotation;

    private void rotateObject()
    {
        currentRotation = gameObject.transform.eulerAngles;
        targetRotation.z = (currentRotation.z + (90 * rotationDirection));

        if (targetRotation.z % 90 != 0)
        {
            targetRotation.z = Mathf.RoundToInt(targetRotation.z / 90) * 90;
        }

        StartCoroutine(objectRotationAnimation());
        
    }

    IEnumerator objectRotationAnimation()
    {
        // add rotation step to current rotation.
        currentRotation.z += (rotationStep * rotationDirection);
        gameObject.transform.eulerAngles = currentRotation;

        yield return new WaitForSeconds(0);

        if (((int)currentRotation.z > (int)targetRotation.z && rotationDirection < 0) // for clockwise
        ||  ((int)currentRotation.z < (int)targetRotation.z && rotationDirection > 0)) // for anti-clockwise
        {
            StartCoroutine(objectRotationAnimation());
        }
        else
        {
            gameObject.transform.eulerAngles = targetRotation;
        }
        
    }
    



    void OnMouseUp()
    {
        if (LevelManager.levelManager.ballIsMoving == false)
        {
            rotateObject();
        }
    }



}
