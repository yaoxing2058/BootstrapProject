using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(AudioSource))]
public class Jump : MonoBehaviour
{
    public float jumpStrength = 5;
    public KeyCode jumpKey = KeyCode.Space;

    private Rigidbody rb;
    [SerializeField]
    public bool isGrounded = true;
    private AudioSource soundPlayer;
    public AudioClip jumpSound;
    public AudioClip landSound;
    private bool jumpEnabled = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        soundPlayer = GetComponent<AudioSource>();

        StartCoroutine(JumpingAndLandingSound());

    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {

            rb.AddForce(rb.transform.up * jumpStrength, ForceMode.Impulse);

        }
    }

    IEnumerator JumpingAndLandingSound() {

       while(jumpEnabled) {

            yield return new WaitUntil(() => Input.GetKeyDown(jumpKey) && isGrounded == true);

            soundPlayer.PlayOneShot(jumpSound);

            yield return new WaitUntil(() => (!Input.GetKeyDown(jumpKey)) && isGrounded == true);

            soundPlayer.PlayOneShot(landSound);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;

            soundPlayer.PlayOneShot(landSound);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
