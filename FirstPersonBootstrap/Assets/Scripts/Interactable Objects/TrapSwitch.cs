using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch : InteractableObject
{
    public GameObject trap;

    private Animator anim;

    private bool activated;

    private Color _originalColor;

    public Color _activatedColor;

    // Start is called before the first frame update
    void Start()
    {

        anim = trap.GetComponent<Animator>();

        activated = true;

        _originalColor = GetComponent<Renderer>().material.GetColor("_Color");

    }

    public override void Interact() {

        var renderer = GetComponent<Renderer>();

        var switchSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Magic");

        var soundPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        Material buttonMat = renderer.material;

        if (activated) {

            anim.enabled = false;

            activated = !activated;

            buttonMat.SetColor("_Color", _activatedColor);

            soundPlayer.PlayOneShot(switchSound);

        }

        else {

            anim.enabled = true;

            activated = !activated;

            buttonMat.SetColor("_Color", _originalColor);

            soundPlayer.PlayOneShot(switchSound);

        }

    }

}
