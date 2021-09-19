using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevel1 : MonoBehaviour {

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Portal;

    private Quaternion OriginalRotation;

	// Use this for initialization
	void Start ()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        OriginalRotation = Portal.GetComponent<Transform>().rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Portal.GetComponent<Transform>().rotation != OriginalRotation )
        {
            Panel1.SetActive(false);
            Panel2.SetActive(true);
        }

        if (LevelManager.levelManager.ballIsMoving)
        {
            Panel2.SetActive(false);
        }
	}
}
