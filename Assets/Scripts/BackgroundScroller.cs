using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	public float scrollvelocity = 2.0f; // variable to determine background speed
	private Rigidbody2D rb2d; // private variable to store physics component


	void Start ()  // Called when initialised
	{
		rb2d = GetComponent<Rigidbody2D> (); // reference to physics component
		rb2d.velocity = new Vector2 (-scrollvelocity,0); // makes backgound move at
														// set speed in x direction
	}

	void Update () // Called once per frame
	{
		if (DroneController.instance.hasCrashed == true) // checks to see if drone has crashed
		{
			rb2d.velocity = Vector2.zero; // sets the velocity of the background to zero if crashed
		}
	}
}