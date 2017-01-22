using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : TriggerTarget
{
	public TriggerTarget target;
	public bool once = false;

	public AudioClip Clip;


	public float intensity = 5;
	public float MaxSoundRange = 4;

	private bool triggered;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}

	public void ManageTrigger()
	{
		AudioSource.PlayClipAtPoint (Clip, target.transform.position);
		target.Trigger ();
		EchoMaterialManager.Instance.SpawnEcho (target.transform.position, intensity, MaxSoundRange);
	}

	public override void Trigger()
	{
		if ( once )
		{
			if (!triggered) {
				ManageTrigger ();
			} 
		}
		else
		{
			ManageTrigger ();
		}

		triggered = true;
	}

	void OnTriggerEnter( Collider collider )
	{
		if ( collider.tag == "Player" )
			Trigger();
	}
}
