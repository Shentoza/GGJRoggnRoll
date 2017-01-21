using UnityEngine;
using System.Collections;

public class BreadControl : MonoBehaviour
{
	public SoundSource sound;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter( Collision collision )
	{
		sound.Emit( transform.position );
	}

	public void Launch( Vector3 position, Vector3 direction )
	{
		transform.position = position;
		transform.LookAt( position + direction );
		transform.Rotate( Vector3.up, 90 );

		GetComponent<Rigidbody>().AddForce( direction * 1000 );

		Vector3 ropeOrigin = new Vector3( position.x, position.y, position.z );

		GetComponent<RopeControl>().ResetAll( ropeOrigin );
		GetComponent<RopeControl>().AddPoint( ropeOrigin );
	}
}
