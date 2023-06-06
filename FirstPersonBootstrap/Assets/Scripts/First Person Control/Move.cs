using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody), typeof(AudioSource))]
public class Move : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode runKey = KeyCode.LeftShift;
    public AudioClip[] walkSounds;
    public AudioClip[] runSounds;
    private AudioClip walkSound, runSound;
    private AudioSource soundPlayer;
    private float walkTime;
    private float walkTimeDelay = 0.5f;
    private float runTime;
    private float runTimeDelay = 0.3f;
    private bool grounded;

    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        soundPlayer = GetComponent<AudioSource>();

    }

    private AudioClip AudioRandomizer(AudioClip[] clips) {

        return clips[Random.Range(0, clips.Length)];

    }

    private void WalkSound(bool walking) {

        walkTime += 1f * Time.deltaTime;

        if(walking && grounded) {

            if (walkTime >= walkTimeDelay) {

                walkTime = 0f;
                
                walkSound = AudioRandomizer(walkSounds);

                soundPlayer.PlayOneShot(walkSound);

            }

        }

    }

    private void RunSound(bool running) {

        runTime += 1f * Time.deltaTime;

        if(running && grounded) {

            if (runTime >= runTimeDelay) {

                runTime = 0f;
                
                runSound = AudioRandomizer(runSounds);

                soundPlayer.PlayOneShot(runSound);

            }

        }

    }

    void Update()
    {

        grounded = GetComponent<Jump>().isGrounded;

        float speed = Input.GetKey(runKey) ? runSpeed : walkSpeed;

        float inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float inputZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        WalkSound(speed == walkSpeed && (inputX != 0f || inputZ != 0f));

        RunSound(speed == runSpeed && (inputX != 0f || inputZ != 0f));

        rb.transform.Translate(inputX, 0, inputZ);

    }
}
