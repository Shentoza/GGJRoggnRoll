﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonOnClick : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    
}
