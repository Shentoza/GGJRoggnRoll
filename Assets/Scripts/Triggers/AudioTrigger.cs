using System.Collections	;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
	public AudioClip audioClip;
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

	public void Trigger()
	{
		if ( once )
		{
			if ( !triggered ) Play();
		}
		else
		{
			Play();
		}

		triggered = true;
	}

	void OnTriggerEnter( Collider collider )
	{
		if ( collider.tag == "Player" )
			Play();
	}

	void Play()
	{
		if ( audioClip )
			AudioSource.PlayClipAtPoint( audioClip, transform.position );
	}
}
