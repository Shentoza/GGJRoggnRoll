using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour {


    public Sprite health4, health3, health2, health1, health0;
    private SpriteRenderer spriteRenderer;
    public int health = 4;

    public GameObject gameOverCanvas;
    

    void Start()
    {
        gameOverCanvas.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = health4; // set the sprite to sprite1
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If the space bar is pushed down
        {
            ChangeTheDamnSprite(); // call method to change sprite
        }
    }

    void ChangeTheDamnSprite()
    {
        
        if(spriteRenderer.sprite == health4)
        {
            health = 3;
            spriteRenderer.sprite = health3;
        } else if(spriteRenderer.sprite == health3)
        {
            health = 2;
            spriteRenderer.sprite = health2;
        } else if(spriteRenderer.sprite == health2)
        {
            health = 1;
            spriteRenderer.sprite = health1;
        } else if(spriteRenderer.sprite == health1)
        {
            gameOverCanvas.SetActive(true);
            
            
        }
            
    }

    public int getHealth()
    {
        return health;
    }

    public void setGameOver()
    {
        //Neue Scene mit GameOverDialog
    }
}
