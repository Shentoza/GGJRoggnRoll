using UnityEngine;
using System.Collections;

public class BreadControl : MonoBehaviour
{
	public SoundSource sound;
	public RopeControl rope;

	public float pullSpeed = 50.0f;

	private int pullPoint;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		float tpf = Time.deltaTime;

		if ( pullPoint > 0 )
		{
			Vector3 b = rope.GetPoint( pullPoint - 1 );

			Vector3 position = Vector3.Lerp( transform.position, b, pullSpeed * tpf );

			transform.position = position;

			if ( Vector3.Distance( position, b ) < 0.5f )
			{
				transform.position = b;
				pullPoint--;
			}
		}
	}

	void OnCollisionEnter( Collision collision )
	{
		sound.Emit( transform.position );
	}

	public void Launch( Vector3 position, Vector3 direction )
	{
		SetPhysicsActive( true );

		transform.position = position;
		transform.LookAt( position + direction );
		transform.Rotate( Vector3.up, 90 );

		GetComponent<Rigidbody>().AddForce( direction * 1000 );
		
		rope.ResetAll( position );
		rope.AddPoint( position );

		pullPoint = 0;
	}

	public void Pull()
	{
		pullPoint = GetComponent<RopeControl>().GetPointCount() - 1;

		SetPhysicsActive( false );
	}

	public void SetPhysicsActive( bool active )
	{
		GetComponent<Rigidbody>().isKinematic = !active;
		GetComponent<Rigidbody>().detectCollisions = active;

		rope.SetVisible( active );
	}
}
