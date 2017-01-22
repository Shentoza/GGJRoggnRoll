using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandomMove : MonoBehaviour {

	float timer = 0;

	float counter = 0;

	// Use this for initialization
	void Start () {
		EchoMaterialManager Manager = EchoMaterialManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		//if (timer >= 2) {
		//	float x = Random.Range (0.0f, 100.0f);
		//	float y = Random.Range (0.0f, 100.0f);
		//	float z = Random.Range (0.0f, 100.0f);
		//
		//	transform.position = new Vector3 (x, y, z);
		//
		//	timer = 0.0f;
		//}

		Light light = GetComponent<Light> ();

		counter += Time.deltaTime;

		//float NewRange = Mathf.Sin (counter) + 1;
		light.range += Time.deltaTime;
	}
}
