using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicSphereScript : MonoBehaviour {

    public SonicSourceScript owner;
    public float intensity;
    public ArrayList intersectedObjects = new ArrayList();
    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentScale = gameObject.transform.lossyScale;

        gameObject.transform.localScale = gameObject.transform.localScale + Vector3.one * 0.1f;

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, rend.bounds.extents.magnitude);

        foreach (Collider collider in hitColliders)
        {
            if (!intersectedObjects.Contains(collider))
            {
                Vector3 pointOfImpact = collider.ClosestPointOnBounds(gameObject.transform.position);
                owner.createNewSphere(pointOfImpact, collider);
                intersectedObjects.Add(collider);
                //Destroy(gameObject);
            }
        }
    }


}
