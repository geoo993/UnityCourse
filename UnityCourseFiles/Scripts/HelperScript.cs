using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour {

	// Modes:  Q (move), W(transform), E(rotate), R(scale), T(UI)  (for switching between unity editing tool - )
	// click cmd + ' (apostrophe) for unity scripting API of a particular name
	// (Edit -> Project Settings -> Scriptt Exercution Order) for sorting the order in which scripts are called
	// (Edit -> Project Settings -> Physics 2D) for editing physics of the whole project

	// Destroy(this) wont work, 'this' KeyWord refers to the class and not an object
	// Destroy(gameObject) will work because we are destroying the object which the script is attached to
	// Vector3.Left and Vector3.Right are unit vectors that point to a direction, use a scalar with them to move in their direction

	/*
	// use distance between camera and player to calculate ViewportToWorldPoint of an object relative to camera
	float distance = this.transform.position.z - Camera.main.transform.position.z;

	// to caluclate the relative distance on left of the camera in x is 0.0f which gets the minimum width or left most value
	Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, distance));

	// relative distance on right of the camera in x is 1.0f which gets the maximum width or right most value
	Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, distance));

	they both give you the camera size relative to object on scene regardless of how big or small it is
	*/

	// Random.value is between 0.0 and 1.0 inclusive
	// OnLevelWasLoaded() will signal or tell you when the level or scene is loaded
}
