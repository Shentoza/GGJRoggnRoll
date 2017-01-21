using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSound : TriggerTarget
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public override void Trigger()
	{
		GetComponent<SoundSource>().Emit( transform.position );
	}
}
