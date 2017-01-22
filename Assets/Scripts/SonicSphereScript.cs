using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicSphereScript : MonoBehaviour {

	protected int TreeDepth;
	private int MaxDepth = 1;

	public GameObject SonicSpherePrefab;

    public SonicSourceScript owner;

    public float intensity;
	public float range;

	public float MaxRange = 10.0f;

	public float velocity = 1.0f;

	public ArrayList intersectedObjects = new ArrayList();
    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = gameObject.GetComponent<Renderer>();

		EchoMaterialManager g = EchoMaterialManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
		//if (TreeDepth <= MaxDepth) {
		//	Collider[] hitColliders = Physics.OverlapSphere (gameObject.transform.position, range*0.5f);
		//	foreach (Collider collider in hitColliders) {
		//		if (!intersectedObjects.Contains (collider)) {
		//			Vector3 pointOfImpact = collider.ClosestPointOnBounds (gameObject.transform.position);
		//			Debug.Log (pointOfImpact);
		//			GameObject NewSphere = Instantiate (SonicSpherePrefab);
		//
		//			NewSphere.transform.position = new Vector3(30,0,10);
		//			NewSphere.tag = "SoundSource";
		//
		//			SonicSphereScript ChildSphere = NewSphere.GetComponent<SonicSphereScript> ();
		//			ChildSphere.intensity = intensity * 0.5f;
		//			ChildSphere.TreeDepth = TreeDepth + 1;
		//			ChildSphere.MaxDepth = MaxDepth;
		//			ChildSphere.velocity = 0.5f;
		//			ChildSphere.SonicSpherePrefab = SonicSpherePrefab;
		//
		//			intersectedObjects.Add (collider);
		//			//Destroy(gameObject);
		//		}
		//	}
		//}

		range += Time.deltaTime * velocity;

		if (range >= MaxRange)
			Destroy (gameObject);
    }


}
