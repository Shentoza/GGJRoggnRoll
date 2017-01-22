using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
	public int health = 4;
    private HealthBarBehaviour hbBehaviour;

	// Use this for initialization
	void Start()
	{
        hbBehaviour = new HealthBarBehaviour();
	}

	// Update is called once per frame
	void Update()
	{
        
    }

	public void Damage( int damage )
	{
		health -= damage;

        hbBehaviour.ChangeSprite(health);

		if ( health <= 0 ) Death();
	}

	public void Death()
	{
		//TODO: put death logic here!
		
		Debug.Log( "DEATH!" );
	}
}
