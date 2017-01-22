using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour {


    public GameObject gameOverCanvas;
    public GameObject healthbar;
    public Image img;
    //-------------
    public Sprite[] mySprites;

    void Start()
    {
        img.overrideSprite = mySprites[0]; 
        gameOverCanvas.SetActive(false);

    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) // If the space bar is pushed down
        //{
        //    ChangeSprite(1);        // call method to change sprite
        //}
    }

    public void ChangeSprite(int health)
    {

       switch(health)
        {
            case 3:
                img.overrideSprite = mySprites[1];
                break;
            case 2:
                img.overrideSprite = mySprites[2];
                break;
            case 1:
                img.overrideSprite = mySprites[3];
                break;
            case 0:
                img.overrideSprite = mySprites[4];
                break;
        }
        //TODO: Testen!   
            
        }
            
    }


