using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
	public AudioClip audioClip;

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
			Play();
	}

	void Play()
	{
		AudioSource.PlayClipAtPoint( audioClip, transform.position );
	}
}
