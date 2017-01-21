using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeControl : MonoBehaviour
{
	public float pointInterval = 0.05f;
	
	private List<Vector3> points;
	private float pointTimer;

	// Use this for initialization
	void Start()
	{
		points = new List<Vector3>();
	}

	// Update is called once per frame
	void Update()
	{
		float tpf = Time.deltaTime;

		pointTimer += tpf;

		if ( pointTimer >= pointInterval )
		{
			AddPoint( transform.position );

			pointTimer = 0.0f;
		}

		DrawPoints();
	}

	public void AddPoint( Vector3 position )
	{
		points.Add( position );

		LineRenderer lines = GetComponent<LineRenderer>();

		lines.numPositions = points.Count;
		for ( int i = 0; i < points.Count; i++ )
		{
			lines.SetPosition( i, points[ i ] );
		}
	}

	public void ResetAll( Vector3 position )
	{
		points.Clear();
	}

	void DrawPoints()
	{
		/*for ( int i = 1; i < points.Count; i++ )
		{
			Vector3 a = points[ i - 1 ];
			Vector3 b = points[ i ];

			Debug.DrawLine( a, b, Color.red, 0, false );

			//Debug.Log( "Line: " + a + ", " + b );
		}*/
	}
}
