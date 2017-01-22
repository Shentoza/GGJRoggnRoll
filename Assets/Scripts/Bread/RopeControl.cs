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
		if (points != null) {
			bool add = false;
			if (points.Count == 0 || Vector3.Distance (points [points.Count - 1], position) > 0.1f)
				add = true;

			if (add) {
				points.Add (position);

				LineRenderer lines = GetComponent<LineRenderer> ();

				lines.numPositions = points.Count;
				for (int i = 0; i < points.Count; i++) {
					lines.SetPosition (i, points [i]);
				}
			}
		}
	}

	public void ResetAll( Vector3 position )
	{
		if(points != null)
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

	public int GetPointCount()
	{
		return points.Count;
	}

	public Vector3 GetPoint( int i )
	{
		return points[ i ];
	}

	public void SetVisible( bool visible )
	{
		LineRenderer lines = GetComponent<LineRenderer>();
		lines.enabled = visible;
	}
}
