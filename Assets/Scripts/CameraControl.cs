using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraControl : MonoBehaviour {


    [Tooltip("In m/s")] [SerializeField] float movementSpeed = 8f;

    float xThrow;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float newLocalX = transform.localPosition.x + xThrow * movementSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Clamp(newLocalX, -3.3f, 3.3f), transform.localPosition.y, transform.localPosition.z);
    }
}
