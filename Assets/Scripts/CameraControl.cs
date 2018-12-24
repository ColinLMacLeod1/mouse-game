using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class CameraControl : MonoBehaviour {


    [SerializeField] float movementSpeed = 8f;
    [SerializeField] float loadSceneDelay = 2f;

    float xThrow;
    bool dead = false;

    // Use this for initialization
    void Start () {
		
	}

    void Squish()
    {
        print("SQUISHHH");
        dead = true;
        SendMessageUpwards("StopMovement");
        Invoke("reloadScene", loadSceneDelay);

    }

    void reloadScene()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float newLocalX = transform.localPosition.x + xThrow * movementSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Clamp(newLocalX, -3.3f, 3.3f), transform.localPosition.y, transform.localPosition.z);
    }
}
