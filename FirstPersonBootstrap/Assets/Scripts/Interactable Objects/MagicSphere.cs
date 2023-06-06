using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : InteractableObject
{
    // Change the color of the sphere

    public Color color1;
    
    public Color color2;

    private bool toggleColor;

    void Start() {

        toggleColor = false;

    }

    public override void Interact() { // overrides virtual method Interact() in InteractableObject.cs

        var sphereRender = gameObject.GetComponent<Renderer>();

        var switchSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Computer");

        var soundPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        toggleColor = !toggleColor;

        if (!toggleColor) {

            sphereRender.material.SetColor("_Color", color1);

            soundPlayer.PlayOneShot(switchSound);

        }

        else {

            sphereRender.material.SetColor("_Color", color2);

            soundPlayer.PlayOneShot(switchSound);

        }

    }

   /* public override string GetMessage() {

        return $"{_message}";

    } */

}
