using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InputMapper input = FindObjectOfType<InputMapper>();
        input.AddAxisMapping("Horizontal", Strafe);
        input.AddAxisMapping("Vertical", Walk);
	}

    void Strafe(float axisValue)
    {

    }

    void Walk(float axisValue)
    {
    }

	
	
}
