using UnityEngine;
using System.Collections;

public class TranslateRotateScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Moving
//		float speed = 2;
		// Space.World will move on the world z axis
//		this.transform.Translate (0f, 0f, (speed * Time.deltaTime), Space.World);

		// Space.Self will move on the gameobjects z axis
//		this.transform.Translate (0f, 0f, (speed * Time.deltaTime), Space.Self);

		// Rotating
//		float speed = 90;
//		this.transform.Rotate (0f, (speed * Time.deltaTime), 0f, Space.Self);
		// Find point to rotate on
//		this.transform.Rotate (new Vector3(1f, 1f, 1f), speed * Time.deltaTime, Space.Self);

//		float x = .45f, y = 1f, z = 1f;
//		float rotationSpeed = 90;
//		this.transform.Rotate (new Vector3(x, y, z), rotationSpeed * Time.deltaTime, Space.Self);
//
//		Vector3 topPoint = new Vector3 (this.transform.position.x + x,
//										this.transform.position.y + y,
//										this.transform.position.z + z);
//		Vector3 bottomPoint = new Vector3 (this.transform.position.x - x,
//											this.transform.position.y - y,
//											this.transform.position.z - z);
//		Debug.DrawLine (topPoint, bottomPoint);

		// Scale
//		float scale = 5;
//		transform.localScale = new Vector3 (scale, scale, scale);

		MoveTorwardsTarget (Vector3.zero);
		RotateTorwardsTarget (Vector3.zero);
		PulseObject ();

	}

	private void MoveTorwardsTarget(Vector3 targetPosition){
		float speed = 1f;

		Vector3 currentPosition = this.transform.position;
		if (Vector3.Distance(currentPosition, targetPosition) > 1) {
			Vector3 directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize ();

			this.transform.Translate (
				(directionOfTravel.x + speed + Time.deltaTime),
				(directionOfTravel.y + speed + Time.deltaTime),
				(directionOfTravel.z + speed + Time.deltaTime),
				Space.World);
		}
	}

	private void RotateTorwardsTarget(Vector3 targetPosition){
		float speed = 45;
		Vector3 currentPosition = this.transform.position;
		Quaternion currentRotation = this.transform.rotation;

		Vector3 directionOfLook = targetPosition - currentPosition;


		Quaternion targetRotation = Quaternion.LookRotation (directionOfLook);

		transform.rotation = Quaternion.RotateTowards (currentRotation, targetRotation, Time.deltaTime + speed);
	}

	private void PulseObject(){
		float rate = .5f;
		float maxScale = 1.2f;
		float minScale = .8f;

		float scale = (Mathf.Sin(Time.time + (rate + 2 + Mathf.PI)) + 1f)/2f;

		scale = Mathf.Lerp (minScale, maxScale, scale);

		transform.localScale = new Vector3 (scale, scale, scale);
	}
		
}
