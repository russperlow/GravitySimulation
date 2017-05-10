using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	// Public Variables
	public Material mat;

	// Private Variables
	private float y;	// Vertical position
	private float y0;	// Initial vertical position
	private float x;	// Horizontal position
	private float x0;	// Initial horizontal position
	private Vector3 v0;	// Initial velocity
	private Vector3 velocity;	// Velocity used for calculations
	private float g = 9.81f; // Acceleration due to gravity
	private float angle;	// Angle of object
	private int t = 0;	// Time used for calculations

	// Use this for initialization
	void Start () {
		y = this.transform.position.y;
		x = this.transform.position.x;
		v0 = this.GetComponent<Rigidbody>().velocity; 
		angle = this.transform.rotation.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnRenderObject()
	{
		mat.SetPass (0);

		// Reset all variables to initial points
		velocity = v0;
		y = y0;
		x = x0;

		// Open the line drawer
		GL.Begin(GL.LINES);


		do 
		{

			Debug.Log("X: " + " Y: " + y + " Angle: " + angle);
			// Calculate the current velocity
			Vector3 tempV = velocity;
			velocity.x = tempV.magnitude * Mathf.Cos (angle);
			velocity.y = (tempV.magnitude * Mathf.Sin (0)) - (g * t);

			// Calculate the x location
			x = velocity.magnitude * t * Mathf.Cos(angle);

			// Calculate the y location
			y = Mathf.Tan (angle) * x - ((g / (2 * (Mathf.Cos (angle) * Mathf.Cos (angle)))) * (x * x));

			// Draw this position
			GL.Vertex(new Vector2(x, y));
				
			// Increase the time
			t++;
		} while (y >= 0);

		// Close the line drawer
		GL.End ();
	}
}
