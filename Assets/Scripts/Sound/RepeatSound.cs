using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatSound : MonoBehaviour
{
	public float interval = 1.0f;

	private float timer;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float tpf = Time.deltaTime;

		timer += tpf;

		if ( timer >= interval )
		{
			GetComponent<SoundSource>().Emit( transform.position );

			timer = 0.0f;
		}
	}
}
