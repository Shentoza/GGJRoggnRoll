using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastRandIntervalComments : MonoBehaviour {

    public float minSec;
    public float maxSec;
    public AudioClip[] commentAudioClips;

    AudioSource audioSource;
    int clipArraySize;
    float timePassed = 0;
    float nextCommentTime;

	// Use this for initialization
	void Start () {
        clipArraySize = commentAudioClips.Length;
        nextCommentTime = Random.Range(minSec, maxSec);
        audioSource = GetComponent<AudioSource>();

        if(minSec > maxSec)
        {
            float tmp = minSec;
            minSec = maxSec;
            maxSec = tmp;
        }

        if (commentAudioClips.Length == 0)
            Debug.LogWarning("Toast doesn't have audioclips");
    }
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if(timePassed > nextCommentTime)
        {
            // random select from array ....
            int randIndex = (int)Mathf.Floor(Random.Range(0.0f, 1.0f) * clipArraySize);
            if(randIndex == clipArraySize)
                randIndex--;



            audioSource.PlayOneShot(commentAudioClips[randIndex], 1.0f);
            timePassed = 0.0f;
            nextCommentTime = Random.Range(3f, 10.0f);
        }

    }
}
