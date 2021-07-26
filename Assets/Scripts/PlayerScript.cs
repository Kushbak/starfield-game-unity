using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

	public float speed;
	public float tilt;
	public float xMin, xMax, zMin, zMax;

	public GameObject LazerShot;
	public Transform LazerGun;

	public float shotDelay;
	private float nextShot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");

      Rigidbody Player = GetComponent<Rigidbody>();

      Player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
   		
   		Player.rotation = Quaternion.Euler(Player.velocity.z * tilt, 0, -Player.velocity.x * tilt);
    
   		float xPosition = Mathf.Clamp(Player.position.x, xMin, xMax);
   		float zPosition = Mathf.Clamp(Player.position.z, zMin, zMax);
    
   		Player.position = new Vector3(xPosition, 0, zPosition);


   		// Выстрелы 
   		if (Time.time > nextShot && Input.GetButton("Fire1")){
   			Instantiate(LazerShot, LazerGun.position, Quaternion.identity);
   			nextShot = Time.time + shotDelay;
   		}


    }	

}
