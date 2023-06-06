using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChallenge : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float duration = 3.0f;
    private float elapsedTime;
    // [SerializeField]
    // private AnimationCurve curve;

    void MoveObject(Vector3 start, Vector3 end) {

            elapsedTime += Time.deltaTime;

            float fractionTime = elapsedTime / duration;

            // transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0, 1, fractionTime));

            // transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(fractionTime)); // Using Animation Curve to control linear interpolation

            // transform.position = Vector3.Lerp(start, end, fractionTime);

            transform.position = Vector3.Lerp(start, end, fractionTime);
        
    }

    IEnumerator StartMove() {

            MoveObject(startPosition, endPosition);
            yield return new WaitUntil(() => transform.position == endPosition);
            elapsedTime = 0f;
            Vector3 newStart = endPosition;
            Vector3 newEnd = startPosition;
            MoveObject(newStart, newEnd);
            yield return new WaitUntil(() => transform.position == newEnd);
            elapsedTime = 0f;
            StartCoroutine(StartMove());

    }


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0f, 0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(StartMove());
    }
}
