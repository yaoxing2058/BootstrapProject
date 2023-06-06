using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerReset : MonoBehaviour
{
    public Transform spawnPoint;

    private AudioSource soundPlayer;

    private AudioClip deadSound;

    private AudioClip reviveSound;

    public int life = 3;

    private int maxLife;

    public TextMeshProUGUI gameOver;

    public TextMeshProUGUI restartGameText;

    public GameObject[] playerFunctions;

    public GameObject canvas; // The GameObject that contains UI texts

    public bool gameIsOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetPlayer(other.gameObject);
        }
        else
        {
            other.gameObject.SetActive(false);
        }
    }

    public void ResetPlayer(GameObject other)
    {

        soundPlayer = GameObject.Find("SoundEffect").GetComponent<AudioSource>();

        deadSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Die");

        soundPlayer.PlayOneShot(deadSound);

        other.transform.position = spawnPoint.position;

        life--;
        
    }

    public void GameOver() {

        GameObject player = GameObject.FindWithTag("Player");

        MonoBehaviour[] comps = player.GetComponents<MonoBehaviour>();

        if(life <= 0) {

            foreach (MonoBehaviour c in comps)
            {
                c.enabled = false;
            }

            foreach (GameObject obj in playerFunctions) 
            {

                obj.SetActive(false);

            }

            gameOver.enabled = true;

            gameIsOver = true;

            Time.timeScale = 0;

        }

    }

    public void RestartGame() {

        TimerScript timer = canvas.GetComponent<TimerScript>();

        restartGameText.enabled = false;

        life = maxLife;

        reviveSound = GameObject.Find("SoundEffect").GetComponent<SoundEffects>().GetSoundEffect("Revive");

        GameObject player = GameObject.FindWithTag("Player");

        MonoBehaviour[] comps = player.GetComponents<MonoBehaviour>();

         foreach (MonoBehaviour c in comps)
        {

            c.enabled = true;

        }

        foreach (GameObject obj in playerFunctions) 
        {

            obj.SetActive(true);

        }

        Interaction _interaction = player.GetComponent<Interaction>();

        _interaction.score = 0; // Reset score

        gameOver.enabled = false;

        gameIsOver = false;

        Time.timeScale = 1;

        timer.ResetTimer();

        player.transform.position = spawnPoint.position;

        soundPlayer.PlayOneShot(reviveSound);


    }

    void Start() {

        gameOver.enabled = false;

        gameIsOver = false;

        maxLife = life;

        restartGameText.enabled = false;

    }

    void Update() {

        GameOver(); // Check if the game is over

        if(gameIsOver) {

            restartGameText.enabled = true;

            if(Input.GetKeyDown(KeyCode.Return)) {

                RestartGame();

            }

        }

    }
}
