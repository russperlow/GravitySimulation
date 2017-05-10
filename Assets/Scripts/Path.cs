using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	// Public Variables
	public Material mat;
    public GameObject cannon;

	// Private Variables
	private float y;	// Vertical position
	private float y0;	// Initial vertical position
	private float x;	// Horizontal position
	private float x0;	// Initial horizontal position
	private float v0;	// Initial velocity
	private float velocity;	// Velocity used for calculations
	// private float gravity = -9.81f; // Acceleration due to gravity
	private float angle;	// Angle of object
	private float t = .01f;	// Time used for calculations
    private float duration; // How long the flight is
    private float distance; // Final distance of this projectile
    private List<Vector2> pathLines;

	// Use this for initialization
	void Start () {
        /*
        cannon = GameObject.FindGameObjectWithTag("Cannon");
		y0 = gameObject.transform.position.y;
		x0 = gameObject.transform.position.z;
        Launch launch = (Launch)cannon.GetComponentInChildren(typeof(Launch));
        v0 = launch.force; 
		angle = cannon.transform.rotation.x;
        angle = angle * 180 / Mathf.PI;

        distance = (v0 * Mathf.Cos(angle) / g) * ((v0 * Mathf.Sin(angle)) + Mathf.Sqrt((v0 * v0 * Mathf.Sin(angle)) + 2 * g * y0));
        duration = (2 * v0 * Mathf.Sin(angle)) / g;
        Debug.Log("Duration: " + duration);
        // Debug.Break();
        // t = duration / 100;

        pathLines = new List<Vector2>();
        */
        GetPath(transform.position, GetComponent<Rigidbody>().velocity, new Vector3(0, -9.81f, 0));

        // Debug.Log("Angle: " + angle + " Rotation: " + cannon.transform.rotation.x);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
    void GetPath(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        int numSteps = 1000; // for example
        float timeDelta = 1.0f / initialVelocity.magnitude; // for example

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.numPositions = numSteps;

        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; i++)
        {
            lineRenderer.SetPosition(i, position);

            position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
            velocity += gravity * timeDelta;

            if (position.y < 0)
                break;
        }

        /*
        Debug.Log("Distance: " + distance);
		do 
		{
            Debug.Log("X: " + x + " Y: " + y + " Angle: " + angle + " Time: " + t + " V0: " + v0);
            
            x = v0 * t;
            y = Mathf.Tan(angle) * x - ((g / (2 * v0 * v0 * (Mathf.Cos(angle) * Mathf.Cos(angle)))) * (x * x));

            // Add this position to the path
            pathLines.Add(new Vector2(x, y));

			// Increase the time
			t += duration / 100;
        } while (y >= 0);
        */
    }

	void OnRenderObject()
	{
        /*
        mat.SetPass(0);
        GL.Begin(GL.LINES);

        for(int i = 0; i < pathLines.Count; i++)
        {
            GL.Vertex(pathLines[i]);
        }

        GL.End();
        */
	}
}
