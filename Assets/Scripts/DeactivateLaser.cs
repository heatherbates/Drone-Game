using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeactivateLaser : MonoBehaviour {

	private SpriteRenderer laserswitch;
	private GameObject[] beams; //creates an array to store each instance of the laserbeams
	public AudioClip laser;
	private AudioSource audiosource;

	void Start () //Called when initialised
	{
		laserswitch = GetComponent<SpriteRenderer> ();
		//searchs for objects with the tag 'beam' and stores them in the array
		beams = GameObject.FindGameObjectsWithTag ("beam");
		//refence to audio file
		audiosource = GetComponent<AudioSource>();
	}

	void OnMouseDown () // Called when click detected
	{
		laserswitch.sortingOrder = 0; //sets sorting order to zero
		foreach (GameObject beam in beams) //iterates through array
		{
			//compares the parent of each beam with the parent of the switch that has been clicked
			if (beam.transform.parent == laserswitch.transform.parent) 
			//if the parents match, then that beam is hidden
			{
				// gets component
				SpriteRenderer laserbeam = beam.GetComponent (typeof(SpriteRenderer)) as SpriteRenderer;
				laserbeam.sortingOrder = 0; //sets sorting order to zero
				BoxCollider2D laserbeamcollider = beam.GetComponent (typeof(BoxCollider2D)) as BoxCollider2D;
				laserbeamcollider.enabled = false; //disables collider to prevent drone crashing
				//plays sound file
				audiosource.PlayOneShot(laser,2f);
			}
			
		}
		StartCoroutine (reactivate());
	}

	IEnumerator reactivate()
	{
		yield return new WaitForSecondsRealtime(20);
		laserswitch.sortingOrder = 3;
		foreach (GameObject beam in beams) 
		{ //iterates through array
			//compares the parent of each beam with the parent of the switch that has been clicked
			if (beam.transform.parent == laserswitch.transform.parent) 
 			{	//if the parents match, then that beam is hidden
				// gets component
				SpriteRenderer laserbeam = beam.GetComponent (typeof(SpriteRenderer)) as SpriteRenderer;
				laserbeam.sortingOrder = 1; //sets sorting order to one, so laserbeam is now visible
				BoxCollider2D laserbeamcollider = beam.GetComponent (typeof(BoxCollider2D)) as BoxCollider2D;
				laserbeamcollider.enabled = true; //enables collider
			}
		}
	}
}

