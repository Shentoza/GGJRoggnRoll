using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
	public HealthControl healthControl;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter( Collider collider )
	{
		if ( collider.tag == "Player" )
			Damage();
	}

	void Damage()
	{
		Debug.Log( "Damage..." );
		healthControl.Damage();
	}
}
