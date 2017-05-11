using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	// Public Variables
	public Vector3 v0 = Vector3.zero;

	// Use this for initialization
	void Start () {
		v0 = GetComponent<Rigidbody>().velocity;
        GetPath(transform.position, GetComponent<Rigidbody>().velocity, new Vector3(0, -9.81f, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
    void GetPath(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity) {
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

            if (this.transform.position.y < 1)
                break;
        }
    }
}
