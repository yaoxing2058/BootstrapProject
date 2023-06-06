using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCoolHurt : ShootableObject
{
    public AudioClip hurtSound;

    public override void TriggerEvent() {

        var audio = GetComponent<AudioSource>();

        audio.PlayOneShot(hurtSound);

    }

}
