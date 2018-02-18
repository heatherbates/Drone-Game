using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroneController : MonoBehaviour {

	public static DroneController instance; // reference to drone created by unity
	public bool hasCrashed = false;         // boolean variable determines if drone has crashed
	private Rigidbody2D rb2d;               // private variable to store the physics component
	public float thrust = 1000f;            // public variable to set the force applied per click
	public AudioClip crash;					// public variable to store soundfile
	private AudioSource source;				// private variable to store reference to soundfile
	private SpriteRenderer diamond;         // variable to store reference to diamond SpriteRenderer
	private CircleCollider2D collider;      // variable to store reference to diamond Collider
	private int score = 0;					// private variable to store the score 
	public Text scoretext;					// vaiable to store the text to display onscreen

	void Awake() // Called before Start ()
	{
		if (instance == null) 	// checks to see if instance has been assigned a value
			instance = this; 	// sets the variable to equal the current instance
	}

	void Start () // Called when initialised
	{
		rb2d = GetComponent<Rigidbody2D>(); //gets the physics component for the drone and
											//stores it in the variable rb2d
		source = GetComponent<AudioSource>();
	}

	void Update () // Called once per frame
	{
		if (hasCrashed == false) //checks that drone has not crashed
		{
			if (Input.GetMouseButtonDown(0)) // detects a mouse click
			{
				rb2d.velocity = Vector2.zero; 			// sets velocity to zero
				rb2d.AddForce(new Vector2(0, thrust)); 	// results in upward force on drone
			}
		}
			
	}

	void OnCollisionEnter2D(Collision2D other) // Called when a collision is detected
	{
		rb2d.velocity = Vector2.zero; 	// sets the velocity of the drone to zero
		hasCrashed = true; 				// changes the state of the drone to crashed
		source.PlayOneShot(crash, 2f); 	//plays sound file
	}
		
	void OnTriggerEnter2D(Collider2D diamondcollider) // Called when a trigger collision detected
	{
		if (diamondcollider.gameObject.CompareTag ("diamond")) // checks to see if object is a diamond
		{
			//reference to the gameObject of the diamond that has been collided with
			diamond = diamondcollider.gameObject.GetComponent<SpriteRenderer> ();
			diamond.sortingOrder = -1; // sets sorting order to 0, so diamond is not visible
			//reference to the collider of the diamond that has been collided with
			collider = diamondcollider.gameObject.GetComponent<CircleCollider2D> ();
			collider.enabled = false; //disables the collider attached to the diamond
			score++; //increments score by one
			scoretext.text = "SCORE: " + score.ToString(); //updates the text on the screen to the new score
		}
	}
}
