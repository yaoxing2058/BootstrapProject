using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTrapSwitch : InteractableObject
{

    public GameObject trap;

    public Color _activatedColor;

    public enum SpecialTrapTypes {

        CarTrap,
        Other

    }
    
    public SpecialTrapTypes trapType; 

    public override void Interact() {

        AudioSource soundPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        AudioClip warningSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Siren");

        Material switchMaterial = GetComponent<Renderer>().material;

        if(trapType == SpecialTrapTypes.CarTrap) {

            soundPlayer.PlayOneShot(warningSound);

            var _carTrap = trap.GetComponent<CarTrap>();

            _carTrap.ActivateTrap();

        }

        switchMaterial.SetColor("_Color", _activatedColor);

        gameObject.tag = "Untagged"; // Untag the switch, making it no longer interactable

    }

}
