using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSwitch : InteractableObject
{

    public GameObject elevator;

    public Color _activateColor;

    private Color _originalColor;

    private Animator anim;

    private bool activated;

    private bool initialized;

    private Material buttonMaterial;

    // Start is called before the first frame update
    void Start()
    {

        buttonMaterial = GetComponent<Renderer>().material;

        _originalColor = buttonMaterial.GetColor("_Color");

        anim = elevator.GetComponent<Animator>();

        activated = false;

        initialized = false;

    }

    public void Initialized() {

        anim.SetBool("Enabled", true);

        initialized = true;

    }

    public override void Interact() {

        var elevatorSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Elevator");

        var soundPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        if (!initialized) {

            var initializedSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Enabled");

            soundPlayer.PlayOneShot(initializedSound);

            Initialized();

            return;

        }

        if (initialized) {

            if (!activated) {

                anim.SetBool("Activated", true);

                activated = !activated;

                buttonMaterial.SetColor("_Color", _activateColor);

                soundPlayer.PlayOneShot(elevatorSound);

            }

            else {

                anim.SetBool("Activated", false);

                activated = !activated;

                buttonMaterial.SetColor("_Color", _originalColor);

                soundPlayer.PlayOneShot(elevatorSound);

            }

        }

    }

}
