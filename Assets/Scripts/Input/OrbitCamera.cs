using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour
{

    public GameObject viewTarget;
    public float elevation = Mathf.PI / 4.0f;
    public float azimuth = 0.0f;

    public float distance = 15.0f;
    public float minDistance = 5.0f;
    public float maxDistance = 30.0f;

    public float distSpringConstant = 10.0f;
    public float mass = 1.0f;

    Vector3 actualCamPos;
    Vector3 velocity;
    float x, y, z;
    float dampingForce;
    Vector3 oldMousePos;


    // Use this for initialization
    void Start()
    {
        dampingForce = -2 * Mathf.Sqrt(distSpringConstant);
        if (!viewTarget)
            Debug.LogError("viewTarget not set! SpringFollowCamera will not work!");


    }

    // Update is called once per frame
    void Update()
    {
        moveCam();
        zoom();
        karthesisch();


    }

    void karthesisch()
    {
        Vector3 acceleration = new Vector3(0, 0, 0);
        x = distance * Mathf.Sin(elevation) * Mathf.Sin(azimuth);
        y = distance * Mathf.Cos(elevation);
        z = -distance * Mathf.Sin(elevation) * Mathf.Cos(azimuth);

        actualCamPos = new Vector3(x, y, z);
        if (!Input.GetMouseButton(1))
        {
            Debug.Log("follow");
            acceleration += distSpringConstant * (viewTarget.transform.localToWorldMatrix.MultiplyPoint(actualCamPos) - this.transform.position) / mass;
            acceleration += dampingForce * velocity;
            this.transform.position = this.transform.position + Time.deltaTime * velocity;
            velocity = velocity + Time.deltaTime * acceleration;
        }
        else
        {
            this.transform.position = viewTarget.transform.localToWorldMatrix.MultiplyPoint(actualCamPos);
            Debug.Log("Ziehen");
        }
        this.transform.LookAt(viewTarget.transform);
    }


    void moveCam()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 temp = Input.mousePosition - oldMousePos;

            elevation += temp.y / 250;
            elevation = Mathf.Clamp(elevation, 0.025f, Mathf.PI / 2);
            azimuth += -temp.x / 250;
        }
        oldMousePos = Input.mousePosition;
    }

    void zoom()
    {
        float temp = Input.GetAxis("Mouse ScrollWheel") * 5;
        distance = Mathf.Clamp(distance - temp, minDistance, maxDistance);
    }


}

