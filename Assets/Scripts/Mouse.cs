using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Mouse : MonoBehaviour {

    [SerializeField] float playerBaseHeight = 0.6f;
    [SerializeField] float localZPosition = 1f;
    [SerializeField] float rotationSpeed = 500f;
    [SerializeField] float rotationLimit = 5f;
    [SerializeField] float squishHeight = 1f;

    float xThrow;
    float jump;
    Animation anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animation>();

    }

    private void HandleSquish()
    {
        anim.Stop();
        transform.localScale += new Vector3(0f, squishHeight - transform.localScale.y,0f);
    }

    // Update is called once per frame
    void Update ()
    {
        ResetPosition();
        //ProccessRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        SendMessageUpwards("Squish");
        HandleSquish();
    }

    private void ProccessRotation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float newYRotation = transform.localRotation.y + xThrow * rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, Mathf.Clamp(newYRotation, -rotationLimit, rotationLimit), 0);
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, playerBaseHeight, transform.position.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, localZPosition);
    }


}
