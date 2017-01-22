using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    Rigidbody rig;
    float maxSpeed = 5.0f;
    float forwardSpeed = 2.5f;
    float backwardSpeed = 1.5f;
    float strafingSpeed = 2.0f;
    float turningSpeed = 2.0f;
    float jumpingHeight = 4.0f;

    bool isGrounded = false;

    bool horizontalSet = false;
    float horizontalValue;

    bool verticalSet = false;
    float verticalValue;
    public OrbitCamera cam;
    public LayerMask mask;

    void Update()
    {

    }

    
    void OnCollisionEnter(Collision other)
    {
        foreach(ContactPoint cp in other.contacts)
        {
            Debug.Log(cp.point.y);
            if (Mathf.Abs(transform.position.y - cp.point.y) < 1.1 && rig.velocity.y <= 0.1f)
                isGrounded = true;
        }
    }


	void Start () {
        rig = GetComponent<Rigidbody>();
        InputMapper.Instance.AddActionMapping("Jump", Jump);
        InputMapper.Instance.AddAxisMapping("Left", StrafeInput);
        InputMapper.Instance.AddAxisMapping("Up", WalkInput);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void StrafeInput(float axisValue)
    {
        horizontalSet = true;
        horizontalValue = axisValue;
        if (verticalSet && horizontalSet)
            Move();

    }
    
    void WalkInput(float axisValue)
    {
        verticalSet = true;
        verticalValue = axisValue;
        if (verticalSet && horizontalSet)
            Move();
    }

    void Move()
    {
        horizontalSet = false;
        verticalSet = false;

        Vector3 forwardSpeedVector = transform.forward * verticalValue * forwardSpeed;
        Vector3 strafeSpeedVector = transform.right * horizontalValue * strafingSpeed;
        Vector3 speedSum = Vector3.ClampMagnitude(forwardSpeedVector + strafeSpeedVector, maxSpeed);
        speedSum.y = rig.velocity.y;
        rig.velocity = speedSum;
    }

    void Jump()
    {
        if(isGrounded)
        { 
            isGrounded = false;
            rig.velocity = new Vector3(rig.velocity.x, jumpingHeight, rig.velocity.z);
        }
    }
}
