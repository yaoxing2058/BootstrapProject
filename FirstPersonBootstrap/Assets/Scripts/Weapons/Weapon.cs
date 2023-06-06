using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform _projectile;
    public Transform gunPoint;
    public float _bulletSpeed;
    public AudioClip[] _sounds;
    public AudioSource _audio;
    public Vector3 _recoilRotation;
    public Vector3 _cameraRecoil;
    public Animator anim;
    public GameObject pointer;
    private Vector3 originalRotation;
    private float _originalFov;

    void Fire() {

        if(Input.GetMouseButtonDown(0)) {

            Rigidbody instantiateProjectile = Instantiate(_projectile.gameObject.GetComponent<Rigidbody>(), gunPoint.position, gunPoint.rotation) as Rigidbody;

            instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, _bulletSpeed));

            Recoil();

            PlaySound("Shoot");

        }
        if (Input.GetMouseButtonUp(0)) {

            CancelRecoil();

        }
    }

    void PlaySound(string clipName) {

        foreach (AudioClip clip in _sounds) {

            if (clip.name == clipName) {

                _audio.PlayOneShot(clip);

            }
        }
        
    }

    void Aim() {

        if (Input.GetMouseButtonDown(1)) {

            anim.SetBool("ADS On", true);

            pointer.SetActive(false);

            Camera.main.fieldOfView = 60.0f;

        }
        if (Input.GetMouseButtonUp(1)) {

            anim.SetBool("ADS On", false);

            pointer.SetActive(true);

            Camera.main.fieldOfView = _originalFov;
        }

    }

    void Recoil() {

        transform.localEulerAngles += _recoilRotation;

    }

    void CancelRecoil() {

        transform.localEulerAngles = originalRotation;

    }


    // Start is called before the first frame update
    void Start()
    {

        originalRotation = transform.localEulerAngles;

        _originalFov = Camera.main.fieldOfView;

    }

    // Update is called once per frame
    void Update()
    {
        Fire();

        Aim();

    }
}
