using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousBackground : MonoBehaviour {

	private float length; // variable to store the length of the background

	void Start () // Called when initialised
	{
		length = 59.94f; // length of background assigned to variable
	}

	void Update () // Called once per frame
	{
		if (transform.position.x <- length) // compares postion of 
		{
			LeapFrog(); // calls funtion if leftmost background out of view
		}
	}

	private void LeapFrog() // function to reposition backgrond object

	{
		Vector2 jump = new Vector2 (2 * length, 0); // distance to jump
		transform.position = (Vector2)transform.position + jump; // jumps object
	}
}
