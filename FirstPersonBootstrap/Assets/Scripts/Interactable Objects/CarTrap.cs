using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrap : MonoBehaviour
{
    private float elapsedTime;
    public float duration;
    private bool isActivated;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private Animator anim;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        isActivated = false;

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;

        startPosition = transform.position;

    }

    public void ActivateTrap() {

        AudioSource soundPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        AudioClip warningSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Horn");

        soundPlayer.PlayOneShot(warningSound);

        isActivated = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated) {

            anim.Play("CarTrapWheels");

            elapsedTime += Time.deltaTime;

            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);

        }

        if(transform.position == endPosition) {

            rb.useGravity = true;

            rb.AddForce(Physics.gravity, ForceMode.Acceleration);

            Destroy(gameObject, 3);

        }
        
    }
}
