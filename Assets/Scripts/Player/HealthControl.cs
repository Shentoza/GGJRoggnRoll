using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
	public int health = 4;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Damage( int damage )
	{
		health -= damage;

		//TODO: put damage effect here!

		if ( health <= 0 ) Death();
	}

	public void Death()
	{
		//TODO: put death logic here!
		
		Debug.Log( "DEATH!" );
	}
}
