using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

	public float rotation;
	public float minSpeed, maxSpeed; 

	public GameObject asteroidExplosion;
	public GameObject playerExplosion;

    // Start is called before the first frame update
    void Start()
    {

    	Rigidbody Asteroid = GetComponent<Rigidbody>();
    	Asteroid.angularVelocity = Random.insideUnitSphere * rotation; 
        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed); 
    }
 
    private void OnTriggerEnter(Collider other){

   		if (other.gameObject.tag == "GameBoundary" || other.gameObject.tag == "Asteroid"){
   			return;
   		}

   		if (other.gameObject.tag == "PLayer"){
   			Instantiate(playerExplosion, other.gameObject.transform.position, Quaternion.identity);
   		}

   		Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

   		Destroy(other.gameObject);
   		Destroy(gameObject);

   		
    }
}
