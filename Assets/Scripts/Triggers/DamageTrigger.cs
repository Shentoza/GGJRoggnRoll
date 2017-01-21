using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
	public HealthControl healthControl;

	public int damage = 1;

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
		//TODO: put damage effect here!

		healthControl.Damage( damage );
	}
}
