using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//		Distance = Speed * 1;
		this.transform.position = new Vector3 (transform.position.x, transform.position.y + (3 * Time.deltaTime), transform.position.z);
	}
}
