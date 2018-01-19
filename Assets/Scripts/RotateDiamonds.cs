using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDiamonds : MonoBehaviour {

	void Update () //called once per frame
	{
		//rotates diamond 45 degrees about z-axis
		transform.Rotate (new Vector3 (0,0,45) * Time.deltaTime);
	}
}

