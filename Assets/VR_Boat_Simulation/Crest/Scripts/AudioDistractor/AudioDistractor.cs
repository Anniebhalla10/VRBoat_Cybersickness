using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDistractor : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        if (source != null && clip != null)
        {
            source.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Source or clip is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
