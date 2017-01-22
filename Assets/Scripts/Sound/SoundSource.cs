using UnityEngine;
using System.Collections;

public class SoundSource : MonoBehaviour
{
	public int maxSonicSources = 5;

	private GameObject[] SonicSources;
	private int SonicSourceIndex;

	public GameObject SonicSourcePrefab;

	public float initialIntensity = 0.001f;
	public float initialRange = 0.001f;

	public float maxRange = 10.0f;
	public float speed = 30.0f;

	// Use this for initialization
	void Start()
	{
		SonicSources = new GameObject[ maxSonicSources ];

		for ( int i = 0; i < maxSonicSources; i++ )
		{
			GameObject SonicSource = Instantiate (SonicSourcePrefab);

			SonicSourceScript SonicSourceComp = SonicSource.AddComponent<SonicSourceScript>();
			SonicSources[ i ] = SonicSource;
		}

		SonicSourceIndex = 0;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void Emit( Vector3 worldPosition )
	{
		GameObject SonicSource = SonicSources[ SonicSourceIndex ];
		
		SonicSourceScript SonicSourceComp = SonicSource.GetComponent<SonicSourceScript>();

		SonicSource.transform.position = worldPosition;
		SonicSource.SetActive( true );

		SonicSourceIndex++;

		if ( SonicSourceIndex >= maxSonicSources ) SonicSourceIndex = 0;
	}

	void OnCollisionEnter( Collision collision )
	{
		Emit( transform.position );
	}
}
