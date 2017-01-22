using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEmitter : MonoBehaviour {

	float timer = 0;
	bool CanStartCollision = false;

	EchoMaterialManager Manager;

	// Use this for initialization
	void Start () {
		Manager = EchoMaterialManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.1f)
			CanStartCollision = true;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (!(collision.gameObject.tag == "Player")) {
			if (CanStartCollision) {
				foreach (ContactPoint Point in collision.contacts) {
					Manager.SpawnEcho (Point.point, Mathf.Clamp (collision.impulse.magnitude, 1.0f, 10.0f), collision.impulse.magnitude * 0.4f);
				}
			}
		}
	}
}
