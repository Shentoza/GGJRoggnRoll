﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    Rigidbody rig;
    float maxSpeed;
    float forwardSpeed;
    float backwardSpeed;
    float strafingSpeed;


	void Start () {
        InputMapper input = FindObjectOfType<InputMapper>();
        rig = GetComponent<Rigidbody>();
        input.AddAxisMapping("Horizontal", Strafe);
        input.AddAxisMapping("Vertical", Walk);
        input.AddActionMapping("Jump", Jump);
    }

    void Strafe(float axisValue)
    {
        float finalSpeed = strafingSpeed * axisValue;
        Vector3 movingSpeed = Vector3.ClampMagnitude(new Vector3(rig.velocity.x, 0.0f, finalSpeed), maxSpeed);
        rig.velocity = new Vector3(movingSpeed.x, rig.velocity.y, movingSpeed.z);
    }

    void Walk(float axisValue)
    {

    }

    void Jump()
    {

    }
}