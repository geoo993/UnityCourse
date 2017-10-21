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
}
