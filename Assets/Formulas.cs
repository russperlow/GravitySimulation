using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formulas : MonoBehaviour {

	// Public Variables
	public GameObject newestProjectile;

	// Private Variables
	private Vector3 velocity = Vector3.zero;
	private float gravity = 9.81f;
	private float angle;
	private float range;
	private float height;
	private GameObject cannon;
	private GameObject[] gameObjects;

	// Use this for initialization
	void Start () {
		gameObjects = GameObject.FindGameObjectsWithTag ("Projectile");
		cannon = GameObject.FindGameObjectWithTag ("Cannon");
	}
	
	// Update is called once per frame
	void Update () {
		
		// Only use the newest projectile's information
		gameObjects = GameObject.FindGameObjectsWithTag ("Projectile");
		if (gameObjects.Length > 0) {
			newestProjectile = gameObjects [gameObjects.Length - 1];
			// Debug.Log ("Name: " + newestProjectile.name);


			velocity = new Vector3 (0, 0, 30);

			// Calculate the final position
			angle = 90 - cannon.transform.eulerAngles.x;
			//Debug.Log ("Angle: " + angle + " Cannon: " + cannon.transform.eulerAngles.x);
			//Debug.Log ("Sin: " + Mathf.Sin((2 * angle) * (Mathf.PI / 180)));
			range = (30 * 30 * (Mathf.Sin((2 * angle) * (Mathf.PI / 180)))) / gravity;

			// Calculate the max height
			height = (30 * 30 * (Mathf.Sin((angle) * (Mathf.PI / 180))) * Mathf.Sin((angle) * (Mathf.PI / 180))) /  (2 * gravity);
		}
	}

	void OnGUI(){
		GUI.color = Color.cyan;
		GUI.Label (new Rect (0, 0, 400, 200), "Final Horizontal Position: " + range);
		GUI.Label (new Rect (0, 25, 200, 200), "Max Height: " + height);
		// GUI.Label (new Rect (0, 50, 200, 200), "Current Position: ");
	}
}
