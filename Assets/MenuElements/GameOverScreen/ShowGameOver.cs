using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOver : MonoBehaviour {

    public GameObject canvas;
    

	// Use this for initialization
	void Start () {
        canvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown("escape"))
        //{
        //    isShowing = !isShowing;
        //    canvas.SetActive(isShowing);
        //}
    }

    public void showGameOverScreen()
    {
        canvas.SetActive(true);
    }

   
}
