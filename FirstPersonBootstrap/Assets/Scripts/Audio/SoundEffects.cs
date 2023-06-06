using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    public AudioClip GetSoundEffect(string clipName) { // Get non-Character sounds

        foreach (AudioClip clip in sounds) {

            if (clip.name == clipName) {

                return clip;

            }
        }

        return null;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
