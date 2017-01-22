#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Prefab("Prefabs/Singletons/EchoMaterialManager", true)]
public class EchoMaterialManager : Singleton<EchoMaterialManager> 
{
	List<MeshRenderer> Meshes;
	public GameObject SonicSpherePrefab;

	int z = 0;

	float PackVector2(Vector2 Vec)
	{
		return Vec.x * 10000 + Vec.y;
	}

	//Vector2 UnpackFloat(float x)
	//{
	//	int a = (int)(x / 10000);
	//	int b = (int)(x - (a * 10000));
	//
	//	return new Vector2 (a, b);
	//}

	// Use this for initialization
	void Start () {
		InputMapper Mapper = InputMapper.Instance;

		Meshes = new List<MeshRenderer> ();

		GameObject[] GameObjects = GameObject.FindGameObjectsWithTag ("GameController");

		foreach (GameObject GameObject in GameObjects) 
		{
			MeshRenderer Mesh = GameObject.GetComponent<MeshRenderer> ();

			List<Color> LightPropertiesArray = new List<Color> ();
			for (int i = 0; i < 100; i++)
				LightPropertiesArray.Add (new Color (-10000, -10000, -10000, -10000));
			Mesh.material.SetColorArray (Shader.PropertyToID ("SoundSourceProperties"), LightPropertiesArray);
			Meshes.Add (Mesh);
		}
	}

	float timer = 0;

	// Update is called once per frame
	void Update () {
		List<Color> LightPropertiesArray = new List<Color> ();
		
		GameObject[] GameObjects = GameObject.FindGameObjectsWithTag ("SoundSource");

		int NumberOfGameObject = GameObjects.Length;
		foreach(GameObject GameObject in GameObjects)
		{
			SonicSphereScript light = GameObject.GetComponent<SonicSphereScript> ();
		
			Vector3 LightPosition = light.transform.position;
			Debug.Log (LightPosition);
			float range = light.range;
			range *= 100;
			Vector2 IntensityAndRange = new Vector2((int) light.intensity, (int) range);

			Color LightProperties = new Color (LightPosition.x, LightPosition.y, LightPosition.z, PackVector2(IntensityAndRange));
			LightPropertiesArray.Add (LightProperties);
		}

		foreach (MeshRenderer Mesh in Meshes) 
		{
			Mesh.material.SetInt (Shader.PropertyToID ("SoundsCount"), NumberOfGameObject);

			if (NumberOfGameObject == 0) 
			{
				LightPropertiesArray.Add(new Color(-10000,-10000,-10000,-10000));
				Mesh.material.SetColorArray (Shader.PropertyToID ("SoundSourceProperties"), LightPropertiesArray);
			}
			else
			{
				Mesh.material.SetColorArray (Shader.PropertyToID ("SoundSourceProperties"), LightPropertiesArray);
			}
		}
	}

	public void SpawnEcho(Vector3 Location, float intensity = 10)
	{
		GameObject NewEcho = Instantiate (SonicSpherePrefab, Location, Quaternion.identity);
		NewEcho.tag = "SoundSource";

		SonicSphereScript SonicSphere = NewEcho.GetComponent<SonicSphereScript> ();
		SonicSphere.intensity = intensity;
	}

}
