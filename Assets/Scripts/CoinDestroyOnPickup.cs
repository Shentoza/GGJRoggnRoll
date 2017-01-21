using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroyOnPickup : MonoBehaviour {

    public AudioClip soundFile;

    private void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(soundFile, gameObject.transform.position);
        //Destroy(gameObject);
    }
}
