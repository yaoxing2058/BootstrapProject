using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrap : MonoBehaviour
{
    private PlayerReset playerReset;

    // Start is called before the first frame update
    void Start()
    {

        GameObject playerResetArea = GameObject.Find("Game Reset Area");

        playerReset = playerResetArea.GetComponent<PlayerReset>();

    }

    void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Player")) {

            playerReset.ResetPlayer(other.gameObject);

        }
    }

    void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.CompareTag("Player")) {

            playerReset.ResetPlayer(other.gameObject);

        }

    }

}
