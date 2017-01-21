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
    float jumpingHeight = 7.0f;

    bool canJump = false;

    bool horizontalSet = false;
    float horizontalValue;

    bool verticalSet = false;
    float verticalValue;

    Vector3 oldForwardDirection;

    void FixedUpdate()
    {
       // aus irgendeinem Grund ist der RightStickVertical negativ(ganz nach oben ausgelenkt: -1), also input *-1
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float yawValue = Mathf.Abs(mouseX) > Mathf.Abs(Input.GetAxis("RightStickHorizontal") * turningSpeed) ? mouseX : Input.GetAxis("RightStickHorizontal") * turningSpeed;
        float pitchValue = Mathf.Abs(mouseY) > Mathf.Abs(-Input.GetAxis("RightStickVertical")) ? mouseY : -Input.GetAxis("RightStickVertical");
        Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 stickMovement = new Vector2(Mathf.Abs(Input.GetAxis("RightStickHorizontal") * turningSpeed), Mathf.Abs(-Input.GetAxis("RightStickVertical")));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayInfo;
        Physics.Raycast(ray, out rayInfo);
        transform.LookAt(new Vector3(rayInfo.point.x, transform.position.y, rayInfo.point.z));

        if (Mathf.Abs(yawValue) > 0.2f)
            transform.Rotate(Vector3.up, yawValue);
    }


    void OnCollisionEnter(Collision other)
    {
        foreach(ContactPoint cp in other.contacts)
        {
            if (Mathf.Abs(transform.position.y - cp.point.y) < 1.1 && rig.velocity.y <= 0.1f)
                canJump = true;
        }
    }


	void Start () {
        rig = GetComponent<Rigidbody>();
        InputMapper.Instance.AddActionMapping("Jump", Jump);
        InputMapper.Instance.AddAxisMapping("Left", StrafeInput);
        InputMapper.Instance.AddAxisMapping("Up", WalkInput);
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
        Debug.Log("Movee");
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
        if(canJump)
        { 
            canJump = false;
            rig.velocity = new Vector3(rig.velocity.x, jumpingHeight, rig.velocity.z);
        }
    }
}
