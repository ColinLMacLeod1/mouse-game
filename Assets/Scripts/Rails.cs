using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rails : MonoBehaviour {

    [SerializeField] float railSpeed = 10f;
    [SerializeField] float railRotationSpeed = 50f;
    [SerializeField] float lapSpeed = 1f;
 
    [SerializeField] int section = 0;
    [SerializeField] int corner = 0;

    float lap = 0f;
    bool rotating = false;
    bool stopped = false;

	// Use this for initialization
	void Start () {
        railRotationSpeed = 12 * railSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //print(transform.position.x);
        if (stopped) return;
        if(rotating) {
            Rotate();
        }

        Move();


    }

    void StopMovement()
    {
        stopped = true;
    }

    private void Rotate()
    {
        float currentYRotation = transform.rotation.ToEuler()[1] * 180 / Mathf.PI;
        float newYRotation = currentYRotation + railRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, newYRotation, 0);

        switch (corner)
        {
            case 0:
                if (currentYRotation > 89)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    rotating = false;
                }
                break;
            case 1:
                if (currentYRotation > 179 || currentYRotation < -178)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    rotating = false;
                }
                break;
            case 2:
                if (currentYRotation  > -89)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    rotating = false;
                }
                break;
            case 3:
                if (currentYRotation > -1)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    lap++;
                    railSpeed += lapSpeed;
                    print(lap);
                    rotating = false;
                }
                break;
            default:
                break;
        }
    }

    private void Move()
    {
        switch (section)
        {
            case 0:
                MoveInSection0();
                break;
            case 1:
               MoveInSection1();
                break;
            case 2:
                MoveInSection2();
                break;
            case 3:
                MoveInSection3();
                break;
            default:
                break;
        }

    }

    private void MoveInSection0()
    {
        if(transform.position.z > 63.85)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 64);
            section = 1;
            return;
        }
        if(transform.position.z > 56 && !rotating && corner == 0)
        {
            rotating = true;
        }
        if (transform.position.z > 0)
        {
            corner = 0;
        }

        float newZ = transform.position.z + railSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }

    private void MoveInSection1()
    {
        if (transform.position.x > 79.85)
        {
            transform.position = new Vector3(80, transform.position.y, transform.position.z);
            rotating = true;
            section = 2;
            return;
        }
        if (transform.position.x > 72 && !rotating && corner == 1)
        {
            rotating = true;
        }
        if (transform.position.x > 24)
        {
            corner = 1;
        }
        float newX = transform.position.x + railSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void MoveInSection2()
    {
        if (transform.position.z < -31.85)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -32);
            rotating = true;
            section = 3;
            return;
        }
        if (transform.position.z < -26 && !rotating && corner == 2)
        {
            rotating = true;
        }
        if (transform.position.z < 16)
        {
            corner = 2;
        }
        float newZ = transform.position.z - railSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }

    private void MoveInSection3()
    {
        if (transform.position.x < 0.15)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            rotating = true;
            section = 0;
            return;
        }
        if (transform.position.x < 8 && !rotating && corner == 3)
        {
            rotating = true;
        }
        if (transform.position.x < 24)
        {
            corner = 3;
        }
        float newX = transform.position.x - railSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }


}
