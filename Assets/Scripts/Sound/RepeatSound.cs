using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatSound : TriggerTarget
{
	public float interval = 1.0f;
	public bool on = true;

	private float timer;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		float tpf = Time.deltaTime;

		if ( on ) timer += tpf;

		if ( timer >= interval )
		{
			GetComponent<SoundSource>().Emit( transform.position );

			timer = 0.0f;
		}
	}

	public override void Trigger()
	{
		Debug.Log( "TRIGGER" );

		on = !on;
	}
}
