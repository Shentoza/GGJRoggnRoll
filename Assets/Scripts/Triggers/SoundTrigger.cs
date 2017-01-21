using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : TriggerTarget
{
	public TriggerTarget target;
	public bool once = false;

	private bool triggered;

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
		if ( once )
		{
			if ( ! triggered ) target.Trigger();
		}
		else
		{
			target.Trigger();
		}

		triggered = true;
	}

	void OnTriggerEnter( Collider collider )
	{
		if ( collider.tag == "Player" )
			Trigger();
	}
}
