using UnityEngine;
using System.Collections;

public class SmoothFollow2 : MonoBehaviour {
	
	public Transform target;
	public float distance = 3.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public float rotationDamping = 10.0f;
	public bool lockRotation;
	public bool follow;
	public bool lockHeight;

	// Use this for initialization
	void Start () {
		follow = true;	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 wantedPosition = target.TransformPoint(0, height, -distance);

		if (!follow)
		{
			// Only stop the horizontal scrolling
			wantedPosition.x = transform.position.x;
		}

		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

//		if (lockHeight)
//		{
//			transform.position.y = height;
//		}

		if (smoothRotation) {
			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else
		{
			transform.LookAt (target, target.up);
		}


		if (lockRotation)
		{
			transform.localRotation = Quaternion.EulerAngles(0,0,0);
		}	
	}

	void SetFollow(bool flag)
	{
		follow = flag;
	}
}
