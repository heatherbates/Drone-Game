using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDiamonds : MonoBehaviour {

	public int DiamondPoolSize = 5; 	// size of array
	public GameObject DiamondPrefab; 	// reference to prefab I will be instantiating
	public float time = 3.1f; 			// allocated time between spawns
	public float ymin = -3.5f; 			// minimum y position of diamond
	public float ymax = 6.5f; 			// maximum position of diamond

	private GameObject[] DiamondPool; // defines array
	private Vector2 PoolPosition = new Vector2(-50,-100); // offscreen position to store prefabs
	private float clock; // variable to store how much time has passed since last spawn
	private float xpos = 28f; // x position where diamonds will be repositioned to 
	private int CurrentDiamond = 0; // counter to track which object from the pool is in use
	private SpriteRenderer diamond; // variable to store reference to diamond SpriteRenderer
	private CircleCollider2D diamondcollider; // variable to store reference to diamond Collider

	void Start () // called when initialised
	{
		DiamondPool = new GameObject[DiamondPoolSize]; // creates new array of size 4
		for (int i = 0; i < DiamondPoolSize; i++) // loops through array
		{
			// instantiates each diamond prefab
			DiamondPool[i] = (GameObject) Instantiate (DiamondPrefab, PoolPosition, Quaternion.identity);
		}
	}

	void Update () // Called once per frame
	{
		clock += Time.deltaTime; // increments clock
		// checks drone hasn't crashed
		// checks if it is time to position the next diamond
		if (DroneController.instance.hasCrashed == false && clock >= time) 
		{
			clock = 0f; // resets the clock to zero
			// generates random y-position for the diamond within a range
			float ypos = Random.Range (ymin, ymax);
			// repositions diamond to positon (x,y)
			DiamondPool [CurrentDiamond].transform.position = new Vector2 (xpos, ypos);
			//reference to spriterenderer component attached to diamond
			diamond = DiamondPool[CurrentDiamond].gameObject.GetComponent<SpriteRenderer> ();
			diamond.sortingOrder = 2; //sets sorting order to 2, so diamond is now visible
			//reference to collider component attached to diamond
			diamondcollider = DiamondPool[CurrentDiamond].gameObject.GetComponent<CircleCollider2D> ();
			diamondcollider.enabled = true; //enables collider
			// increments counter by one to loop through pool
			CurrentDiamond++;
			//checks if the last diamond in the pool has been reached
			if (CurrentDiamond >= DiamondPoolSize) 
			{
				// resets the counter to zero, so the first diamond will be moved next
				CurrentDiamond = 0;
			}
		}
	}
}


