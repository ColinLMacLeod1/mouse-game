using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoe : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(0, 5, 0);
    float period;

    //TODO remove from inspector later
    [Range(0, 1)] [SerializeField] float movementFactor; //0 for not moved 1 for fully moved

    Vector3 startingPos;

    // Use this for initialization
    void Start()
    {
        period = Random.value * 3f + 0.75f;
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(2 * Mathf.PI * cycles);
        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
