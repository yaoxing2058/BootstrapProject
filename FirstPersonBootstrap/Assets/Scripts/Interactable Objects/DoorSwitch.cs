using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : InteractableObject
{

    private bool isOpen;

    public GameObject door;

    public Vector3 openDoorValue;

    private Vector3 originalPosition;

    private Color originalColor;

    public Color openDoorColor;

    private AudioClip activateSound;

    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<Renderer>().material.GetColor("_Color");

        isOpen = false;

        originalPosition = door.transform.position;

        sound = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        activateSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Ding");
    }

    public override void Interact() {

        Material switchMaterial = GetComponent<Renderer>().material;

        sound.PlayOneShot(activateSound);

        if (!isOpen) {

            door.transform.position = Vector3.Lerp(door.transform.position, door.transform.position + openDoorValue, 1.0f);
            isOpen = true;
            switchMaterial.SetColor("_Color", openDoorColor);

        }

        else {

            door.transform.position = originalPosition;
            isOpen = false;
            switchMaterial.SetColor("_Color", originalColor);

        }
    }

   
}
