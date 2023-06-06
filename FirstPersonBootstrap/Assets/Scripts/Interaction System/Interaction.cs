using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    // This script implements the Raycast system in Unity. DetectInteractable() is called every frame under Update(). 
    // A ray of the length of "interactRange" goes outwards from the position of the main camera
    // If the ray hits an object that implements the IInteractable interface, the Interact() is called when we press _interactKey on Keyboard
    
   
    public float _interactRange = 3f;

    public KeyCode _interactKey = KeyCode.E;
    
    // Display Interaction Message
    public TextMeshProUGUI _interactionDisplay;

    // Display Dialogue
    public TextMeshProUGUI _dialogue;

    // Interaction Message
    private string _interactionMessage;

    // Score Display
    public TextMeshProUGUI scoreText;

    // Player Score
    public int score = 0;

    void DetectInteractable() {
        
        RaycastHit hitObject = new RaycastHit();

        bool detected = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitObject, _interactRange);

        if (detected) {

            GameObject detectedObject = hitObject.transform.gameObject;

            if (detectedObject.tag == "Interactable") {

                _interactionMessage = $"Press {_interactKey} to interact with {detectedObject.name}";

                DisplayInteractionMessage(); // If detected interactable object, display interaction message

                if (Input.GetKeyDown(_interactKey)) {

                    detectedObject.GetComponent<IInteractable>().Interact();

                    _dialogue.SetText(detectedObject.GetComponent<IInteractable>().GetMessage());

                    ActivateDialogue();
                }

            }
        }

        else {

            HideInteractionMessage();

        }
    }

    void DisplayInteractionMessage() {

        _interactionDisplay.SetText(_interactionMessage);

        _interactionDisplay.enabled = true;

    }

    void HideInteractionMessage() {

        _interactionDisplay.enabled = false;

    }

    public void ActivateDialogue() {

        _dialogue.enabled = true;
        Invoke("DeactivateDialogue", 3.0f); // Automatically deactivate dialogue after 3 seconds

    }

    void DeactivateDialogue() {

        _dialogue.enabled = false;

    }

    void Start() {

        _interactionMessage = $"Press {_interactKey} to interact with object"; // Tell the player which key to press for interaction

        _dialogue.enabled = false;

    }

    void UpdateScore() {

        scoreText.SetText($"Score: {score}");

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        DetectInteractable();
    }
}
