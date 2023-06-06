using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObject : MonoBehaviour
{
    public GameObject influencedObject;

    [Header("Trigger-type Object Only")]
    public Vector3 influenceValue;

    private Interaction interaction;

    public enum ObjectType {
        Trigger,
        Score
    }

    public ObjectType objType;

    public int incrementScore;

    // Start is called before the first frame update
    void Start()
    {
        interaction = GameObject.FindWithTag("Player").GetComponent<Interaction>();
    }

    void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "Bullet") {

            if (objType == ObjectType.Trigger) {

                TriggerEvent();

            }

            if (objType == ObjectType.Score) {

                interaction.score += incrementScore;

            }

        }

    }

    public virtual void TriggerEvent() {

        influencedObject.transform.position += influenceValue;

        Destroy(gameObject, 1.5f);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
