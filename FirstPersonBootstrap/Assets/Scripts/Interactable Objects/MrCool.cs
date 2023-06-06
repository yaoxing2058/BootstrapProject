using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCool : InteractableObject
{

    public AudioClip MrCoolSpeech;

    public override void Interact() {

        var audio = GetComponent<AudioSource>();

        audio.PlayOneShot(MrCoolSpeech);

    }

}
