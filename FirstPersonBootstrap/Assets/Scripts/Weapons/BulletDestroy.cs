using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    private AudioSource sound; // Plays bullet impact sound

    // Start is called before the first frame update
    void Start()
    {

       sound = GetComponent<AudioSource>();

       Destroy(this.gameObject, 5.0f);
       
    }

    void OnCollisionEnter(Collision other) {

        sound.PlayOneShot(sound.clip);

    }

}
