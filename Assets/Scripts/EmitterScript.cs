using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{

	public GameObject asteroid;

	public float minDelay, maxDelay;

	private float nextLaunch;

    // Update is called once per frame
    void Update()
    {

    	if (Time.time > nextLaunch){

    		float xPos = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
    		float yPos = transform.position.y;
    		float zPos = transform.position.z;
    		
    		Instantiate(asteroid, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    		nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
    	}
        
    }
}
