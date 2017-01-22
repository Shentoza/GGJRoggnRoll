using UnityEngine;
using System.Collections;

public class TestPlayerControl : MonoBehaviour
{
	public BreadControl bread;

	public float ropeOffsetVert = -0.3f;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		float tpf = Time.deltaTime;

		//if ( Input.GetKeyDown( KeyCode.Space ) )
		if ( Input.GetMouseButtonDown( 1 ) )
		{
			if ( bread.IsLaunched() == false )
			{
				Vector3 position = transform.position;
				position -= transform.right * 0.5f;
				position.y = transform.position.y + ropeOffsetVert;

				bread.Launch( position, transform.forward );
			}
		}

		if ( Input.GetMouseButtonDown( 2 ) )
		{
			bread.Pull();
		}

		if ( Input.GetMouseButton( 0 ) )
		{
			Vector3 angles = transform.eulerAngles;
			angles.x += Input.GetAxis( "Mouse Y" ) * -5;
			angles.y += Input.GetAxis( "Mouse X" ) * 5;
			transform.eulerAngles = angles;
		}

		if ( bread.IsLaunched() == false )
		{
			// Dumb Clipping Movement (tm)
			float speed = 5;

			if ( Input.GetKey( KeyCode.W ) )
			{
				Vector3 pos = transform.position;

				float y = pos.y;
				pos += transform.forward * speed * tpf;
				pos.y = y;

				transform.position = pos;
			}

			if ( Input.GetKey( KeyCode.S ) )
			{
				Vector3 pos = transform.position;

				float y = pos.y;
				pos -= transform.forward * speed * tpf;
				pos.y = y;

				transform.position = pos;
			}

			if ( Input.GetKey( KeyCode.A ) )
			{
				Vector3 pos = transform.position;

				float y = pos.y;
				pos -= transform.right * speed * tpf;
				pos.y = y;

				transform.position = pos;
			}

			if ( Input.GetKey( KeyCode.D ) )
			{
				Vector3 pos = transform.position;

				float y = pos.y;
				pos += transform.right * speed * tpf;
				pos.y = y;

				transform.position = pos;
			}
		}
	}
}
