using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {

	public int LaserPoolSize = 3; // size of array
	public GameObject LaserPrefab; // reference to prefab I will be instantiating
	public float time = 6f; // allocated time between spawns
	public float ymin = -1f; // minimum y position of laser
	public float ymax = 3f; // maximum position of laser

	private GameObject[] LaserObstacle; // defines array
	private Vector2 PoolPosition = new Vector2(-100,-100); // offscreen position to store prefabs
	private float clock; // variable to store how much time has passed since last spawn
	private float xpos = 28f; // x position where lasers will be repositioned to 
	private int CurrentLaser = 0; // counter to track which object from the pool is in use

	void Start () // Called when initialised
	{
		LaserObstacle = new GameObject[LaserPoolSize]; // creates new array of size 3
		for (int i = 0; i < LaserPoolSize; i++) // loops through array
		{
			// instantiates each laser object prefab
			LaserObstacle[i] = (GameObject) Instantiate (LaserPrefab, PoolPosition, Quaternion.identity);
		}
	}
	

	void Update () // Called once per frame
	{
		clock += Time.deltaTime; // increments clock
		// checks drone hasn't crashed
		// checks if it is time to position a new laser object
		if (DroneController.instance.hasCrashed == false && clock >= time)
		{
			clock = 0f; // resets the clock to zero
			// generates random y-position for obstacle within a range
			float ypos = Random.Range (ymin, ymax);
			// repositions laser object to positon (x,y)
			LaserObstacle [CurrentLaser].transform.position = new Vector2 (xpos, ypos);
			xpos = xpos + 20f; // distance between obstacles
			// increments counter by one to loop through pool
			CurrentLaser ++;
			//checks if the last laserobject in the pool has been reached
			if (CurrentLaser >= LaserPoolSize)
			{
				// resets the counter to zero, so the first laser object will be moved next
				CurrentLaser = 0;
			}
		}
	}
}

