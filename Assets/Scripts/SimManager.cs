using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimManager : MonoBehaviour {

    // Public Variables
    public Camera mainCamera;
    public Camera sideCamera;

    // Private Variables
    private GameObject cannon;

	// Use this for initialization
	void Start () {
        cannon = GameObject.FindGameObjectWithTag("Cannon");
        mainCamera.enabled = true;
        sideCamera.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 150, 250, 50), "Increase Angle"))
        {
            cannon.transform.eulerAngles = new Vector3(cannon.transform.eulerAngles.x - 1, cannon.transform.eulerAngles.y, cannon.transform.eulerAngles.z);
        }
        GUI.Button(new Rect(0, 200, 250, 50), "Angle: " + cannon.transform.eulerAngles.x.ToString().Substring(0, 2) + "°");
        if (GUI.Button(new Rect(0, 250, 250, 50), "Decrease Angle"))
        {
            cannon.transform.eulerAngles = new Vector3(cannon.transform.eulerAngles.x + 1, cannon.transform.eulerAngles.y, cannon.transform.eulerAngles.z);
        }
        if(GUI.Button(new Rect(0, 300, 250, 50), "Switch Perspective"))
        {
            if (mainCamera.enabled)
            {
                mainCamera.enabled = false;
                sideCamera.enabled = true;
            }
            else
            {
                mainCamera.enabled = true;
                sideCamera.enabled = false;
            }
        }
    }
}
