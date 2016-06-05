using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class KeyboardInput : MonoBehaviour {
	Dictionary<KeyCode, Vector3> directions = new Dictionary<KeyCode, Vector3>();
	private float speed = 5f;
	// Use this for initialization
	void Start () {
		directions = new Dictionary<KeyCode, Vector3> () {
			{KeyCode.W, Vector3.forward},
			{KeyCode.S, Vector3.back},
			{KeyCode.A, Vector3.left},
			{KeyCode.D, Vector3.right},
		};
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Fire1") != 0) {
			this.transform.Rotate (Vector3.up, 45 * Time.deltaTime);
		}


		// pressed
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.transform.Translate (5f, 0f, 0f, Space.World);
		}
		// holding
		if (Input.GetKey(KeyCode.Space)) {
			this.transform.Rotate (Vector3.up, 45 * Time.deltaTime);
		}
		// was released
		if (Input.GetKeyUp(KeyCode.Space)) {
			this.transform.Translate (-5f, 0f, 0f, Space.World);
		}

		foreach (KeyCode direction in directions.Keys) {
			if (Input.GetKey (direction)) {
				this.transform.Translate (directions [direction] * speed * Time.deltaTime, Space.Self);
			}
		}
	}
}
