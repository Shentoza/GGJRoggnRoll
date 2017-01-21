using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter( Collision collision )
	{
		if ( collision.transform.name != "Bread" )
			GetComponent<SoundSource>().Emit( transform.position );
	}
}
