#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Prefab("Prefabs/Singletons/EchoMaterialManager", true)]
public class EchoMaterialManager : Singleton<EchoMaterialManager> 
{
	List<MeshRenderer> Meshes;

	float PackVector2(Vector2 Vec)
	{
		return Vec.x * 1000 + Vec.y;
	}

	Vector2 UnpackFloat(float x)
	{
		int a = (int)(x / 1000);
		int b = (int)(x - (a * 1000));

		return new Vector2 (a, b);
	}

	// Use this for initialization
	void Start () {
		InputMapper Mapper = InputMapper.Instance;

		Meshes = new List<MeshRenderer> ();

		GameObject[] GameObjects = GameObject.FindGameObjectsWithTag ("GameController");

		foreach(GameObject GameObject in GameObjects)
			Meshes.Add (GameObject.GetComponent<MeshRenderer> ());
	}

	// Update is called once per frame
	void Update () {
		List<Color> LightPropertiesArray = new List<Color> ();
		
		GameObject[] GameObjects = GameObject.FindGameObjectsWithTag ("SoundSource");

		foreach(GameObject GameObject in GameObjects)
		{
			Light light = GameObject.GetComponent<Light> ();
		
			Vector3 LightPosition = light.transform.position;
			Debug.Log ("LightPosition: " + LightPosition);
			Vector2 IntensityAndRange = new Vector2((int) light.intensity, (int) light.range);

			Color LightProperties = new Color (LightPosition.x, LightPosition.y, LightPosition.z, PackVector2(IntensityAndRange));
			LightPropertiesArray.Add (LightProperties);
		}

		foreach (MeshRenderer Mesh in Meshes) 
		{
			Mesh.material.SetColorArray (Shader.PropertyToID ("SoundSourceProperties"), LightPropertiesArray);
		}
	}

}
