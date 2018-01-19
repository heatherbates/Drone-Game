using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour {

	public GameObject playagain; // playagain button


	void Start ()   // Called when initialised
	{
		Button play_again = playagain.GetComponent<Button>(); // gets button component
		play_again.onClick.AddListener (resetscene); // adds a listener to detect a click
		playagain.SetActive(false); // hides the button from view
	}

	void Update () // Called once per frame
	{
		if (DroneController.instance.hasCrashed == true) // checks to see if drone has crashed
		{
			playagain.SetActive (true); // makes the button visible
		}
	}

	void resetscene () // Called when the playagain button is clicked
	{
		//reloads whichever scene is currently active
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}
}

