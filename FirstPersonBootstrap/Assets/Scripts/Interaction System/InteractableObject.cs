using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Interaction Message")]
    public string _interactText = "";

    public virtual void Interact() { // virtual method allows method overriding in derived classes

    }

    public virtual string GetMessage() {

        return _interactText;

    }

}
