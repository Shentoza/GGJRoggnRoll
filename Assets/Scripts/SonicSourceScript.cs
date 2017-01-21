using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicSourceScript : MonoBehaviour {

    private float intensity = 1.0f;
    private ArrayList sphereList = new ArrayList();
    private ArrayList intersectedObjects = new ArrayList();

    public GameObject sonicSpherePrefab;

	// Use this for initialization
	void Start () {
        //sphere = new SonicSphere(intensity, this);
        Debug.Log("Sonic Waves emitted");
        createNewSphere(gameObject.transform.position, null);

        foreach(Transform child in transform)
        {
            var childObject = child.gameObject;
            if(childObject.GetComponent<SonicSphereScript>())
            {
                sphereList.Add(childObject);
            }
        }

	}

    // Update is called once per frame
    void Update()
    {
        intensity -= 0.005f;
        if (intensity <= 0.0f)
        {
            foreach (GameObject sphere in sphereList)
            {
                Destroy(sphere);
            }
            Destroy(gameObject);
            Debug.Log("Sonic Waves deleted");
        }
        else
        {
            foreach (GameObject sphere in sphereList)
            {
                SonicSphereScript script = sphere.GetComponent<SonicSphereScript>();
                script.intensity = intensity;
            }
        }
    }

    public void createNewSphere(Vector3 position, Collider collider)
    {
        if ((sphereList.Count > 10) || (intersectedObjects.Contains(collider)))
            return;

        GameObject sphere = Instantiate(sonicSpherePrefab);
        sphere.transform.SetParent(transform);
        sphere.transform.position = position;
        SonicSphereScript script = sphere.GetComponent<SonicSphereScript>();
        script.intensity = intensity;
        script.owner = this;
        sphereList.Add(sphere);
        intersectedObjects.Add(collider);

        if (collider != null)
            script.intersectedObjects.Add(collider);
    }
}
