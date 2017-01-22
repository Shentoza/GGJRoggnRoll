using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : TriggerTarget
{
	public GameObject target;
	public bool once = false;

	public AudioClip Clip;


	public float intensity = 5;
	public float MaxSoundRange = 4;

	float timer = 0;
	bool isPlaying = false;

	private bool triggered;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isPlaying) {
			timer += Time.deltaTime;
			if (timer >= Clip.length) {
				timer = 0;
				isPlaying = false;
			}
		}
	}

	public void ManageTrigger()
	{
		//if(!isPlaying)
			//AudioSource.PlayClipAtPoint (Clip, target.transform.position);
		isPlaying = true;

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
