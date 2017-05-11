using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

	// Public variables
	public GameObject cannonBall;
	public float force = 30;
	public float mass = 1;

	// Private variables
	private float initialVelocity;
	private Vector3 velocity;
	private Vector3 position;
	private float acceleration;
	private float time;
	private bool moving;

	// Use this for initialization
	void Start () {
		position = this.transform.position;
		moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.color = Color.red;
        if (GUI.Button(new Rect(0, 100, 250, 50), "Fire"))
        {
            GameObject go = (GameObject)GameObject.Instantiate(cannonBall);
            go.transform.position = this.transform.position;
            go.transform.rotation = this.transform.rotation;
            Rigidbody rigidbody = go.GetComponent<Rigidbody>();
            rigidbody.velocity = rigidbody.transform.forward * force;
            rigidbody.useGravity = true;
            // Debug.Log ("Name: " + go.name + " Position: " + cannonBall.transform.position);
        }
    }
}
