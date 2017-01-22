using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    Rigidbody rig;
    public float maxSpeed = 5.0f;
    public float forwardSpeed = 2.5f;
    public float backwardSpeed = 1.5f;
    public float strafingSpeed = 2.0f;
    public float jumpingHeight = 4.0f;

    bool isGrounded = false;

    bool horizontalSet = false;
    float horizontalValue;

    bool verticalSet = false;
    float verticalValue;

    bool breadThrown = false;

    float collisionOffset;

    void OnCollisionEnter(Collision other)
    {
        foreach(ContactPoint cp in other.contacts)
        {
            float absDiff = Mathf.Abs(transform.position.y - cp.point.y);
            absDiff -= collisionOffset;
            if (absDiff <= 0.1f)
                isGrounded = true;
        }
    }

    public void setBreadThrown(bool value)
    {
        breadThrown = value;
    }

	void Start () {
        rig = GetComponent<Rigidbody>();
        Collider coll = GetComponent<CapsuleCollider>();
        collisionOffset = coll.bounds.extents.y;
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


        if(breadThrown)
        {
            rig.velocity = new Vector3(0.0f, rig.velocity.y, 0.0f);
            return;
        }
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
