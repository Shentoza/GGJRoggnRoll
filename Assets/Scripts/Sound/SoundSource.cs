using UnityEngine;
using System.Collections;

public class SoundSource : MonoBehaviour
{
	public int maxLights = 1;

	private GameObject[] lights;
	private int lightIndex;

	public float initialIntensity = 0.001f;
	public float initialRange = 0.001f;

	public float maxRange = 10.0f;
	public float speed = 30.0f;

	// Use this for initialization
	void Start()
	{
		lights = new GameObject[ maxLights ];

		for ( int i = 0; i < maxLights; i++ )
		{
			GameObject light = new GameObject( "SoundLight" );
			light.tag = "SoundSource";

			Light lightComp = light.AddComponent<Light>();

			lightComp.type = LightType.Point;
			lightComp.range = 0;
			lightComp.intensity = 0;

			lights[ i ] = light;
		}

		lightIndex = 0;
	}

	// Update is called once per frame
	void Update()
	{
		float tpf = Time.deltaTime;

		UpdateLights( tpf );
	}

	public void Emit( Vector3 worldPosition )
	{
		GameObject light = lights[ lightIndex ];
		Light lightComp = light.GetComponent<Light>();

		light.transform.position = worldPosition;
		lightComp.intensity = initialIntensity;
		lightComp.range = initialRange;

		lightIndex++;

		if ( lightIndex >= maxLights ) lightIndex = 0;
	}

	public void UpdateLights( float tpf )
	{
		for ( int i = 0; i < maxLights; i++ )
		{
			GameObject light = lights[ i ];
			Light lightComp = light.GetComponent<Light>();

			if ( lightComp.range >= initialRange )
			{
				float inc = speed * tpf;

				lightComp.intensity += inc;
				lightComp.range += inc;
			}

			if ( lightComp.range > maxRange )
			{
				lightComp.intensity = 0;
				lightComp.range = 0;
			}
		}
	}
}
