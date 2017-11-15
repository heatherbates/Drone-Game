using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {

	public static DroneController instance; // reference to drone created by unity
	public bool hasCrashed = false; // boolean variable determines if drone has crashed
	private Rigidbody2D rb2d;        // private variable to store the physics component
	public float thrust = 1000f;     // public variable to set the force applied per click

	void Awake() // Called before Start ()
	{
		if (instance == null) // checks to see if instance has been assigned a value
			instance = this; // sets the variable to equal the current instance
	}

	void Start () // Called when initialised
	{
		rb2d = GetComponent<Rigidbody2D>(); //gets the physics component for the drone and
											//stores it in the variable rb2d
	}

	void Update () // Called once per frame
	{
		if (hasCrashed == false) //checks that drone has not crashed
		{
			if (Input.GetMouseButtonDown(0)) // detects a mouse click
			{
				rb2d.velocity = Vector2.zero; // sets velocity to zero
				rb2d.AddForce(new Vector2(0, thrust)); // results in upward force on drone
			}
		}
			
	}

	void OnCollisionEnter2D(Collision2D other) // Called when a collision is detected
	{
		rb2d.velocity = Vector2.zero; // sets the velocity of the drone to zero
		hasCrashed = true; // changes the state of the drone to crashed
	}
}