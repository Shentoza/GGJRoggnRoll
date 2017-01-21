using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSound : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Trigger()
	{
		GetComponent<SoundSource>().Emit( transform.position );
	}
}
