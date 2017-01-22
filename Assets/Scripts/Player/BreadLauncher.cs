using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadLauncher : MonoBehaviour
{
	public BreadControl bread;

	public float ropeOffsetVert = -0.3f;

	// Use this for initialization
	void Start()
	{
		InputMapper.Instance.AddActionMapping( "Fire", Fire );
	}

	// Update is called once per frame
	void Update()
	{
		PlayerControl player = GetComponent<PlayerControl>();

		if ( player && bread )
			player.setBreadThrown( bread.IsLaunched() );
		else
			Debug.Log( "Player / Bread Not Set: " + player + ", " + bread );
	}

	public void Fire()
	{
		if ( bread.IsLaunched() == false )
		{
			Vector3 position = transform.position;
			position -= transform.right * 0.5f;
			position.y = transform.position.y + ropeOffsetVert;

			Vector3 direction = GameObject.FindObjectOfType<Camera>().transform.forward; //transform.forward

			bread.Launch( position, direction );
		}
	}
}
