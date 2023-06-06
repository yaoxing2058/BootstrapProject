using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTree : InteractableObject
{
    private float elapsedTime;
    private Animator anim;
    private bool grown;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        grown = false;
    }

    public override void Interact() {

        var switchSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Grow");

        var soundPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        if (!grown) {

            anim.SetBool("Grow", true);

            grown = !grown;

            soundPlayer.PlayOneShot(switchSound);

        }

        else {

            anim.SetBool("Grow", false);

            grown = !grown;

            soundPlayer.PlayOneShot(switchSound);

        }
       
    }

}
