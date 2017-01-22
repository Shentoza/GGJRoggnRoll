using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSourceOnClick : MonoBehaviour {

    public GameObject sonicSourcePrefab;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");

            Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
			if (hitInfo.collider != null) {
				EchoMaterialManager.Instance.SpawnEcho (hitInfo.point);
			} else
			{
				Debug.Log ("No hit");
			}
        }
    }
}
