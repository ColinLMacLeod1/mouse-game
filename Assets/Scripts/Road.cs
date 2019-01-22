using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    [SerializeField] GameObject[] northRoads;
    [SerializeField] GameObject[] eastRoads;
    [SerializeField] GameObject[] southRoads;
    [SerializeField] GameObject[] westRoads;

    [SerializeField] float northDelayTime = 15f;
    [SerializeField] float eastDelayTime = 30f;
    [SerializeField] float southDelayTime = 45f;
    [SerializeField] float westDelayTime = 60f;
    [SerializeField] float lapTime = 15f;

    GameObject northRoad;
    GameObject eastRoad;
    GameObject southRoad;
    GameObject westRoad;

    // Use this for initialization
    void Start () {
        northRoad = Instantiate(northRoads[0], transform.position, Quaternion.identity);
        eastRoad = Instantiate(eastRoads[0], transform.position, Quaternion.identity);
        southRoad = Instantiate(southRoads[0], transform.position, Quaternion.identity);
        westRoad = Instantiate(westRoads[0], transform.position, Quaternion.identity);
        Invoke("newNorthRoad", northDelayTime);
        Invoke("newEastRoad", eastDelayTime);
        Invoke("newSouthRoad", southDelayTime);
        Invoke("newWestRoad", westDelayTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void newNorthRoad()
    {
        Destroy(northRoad); 
        northRoad = Instantiate(northRoads[1], transform.position, Quaternion.identity);
        Invoke("newNorthRoad", lapTime);
    }

    void newEastRoad()
    {
        Destroy(eastRoad);
        eastRoad = Instantiate(eastRoads[1], transform.position, Quaternion.identity);
        Invoke("newEastRoad", lapTime);
    }

    void newSouthRoad()
    {
        Destroy(southRoad);
        southRoad = Instantiate(southRoads[1], transform.position, Quaternion.identity);
        Invoke("newSouthRoad", lapTime);
    }

    void newWestRoad()
    {
        Destroy(westRoad);
        westRoad = Instantiate(westRoads[1], transform.position, Quaternion.identity);
        Invoke("newWestRoad", lapTime);
    }
}
