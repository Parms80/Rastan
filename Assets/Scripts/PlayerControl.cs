using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed;
	public float jumpStrength;
	//	private Rigidbody2D rigidBody;
	private int state;
	private bool grounded;
	private Transform groundCheck;

	// Use this for initialization
	void Start () {
		//		rigidBody = GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find("Ground check");

	}
	
	// Update is called once per frame
	void Update () {
		grounded = isCharacterOnGround();

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.Space) && isCharacterOnGround()) {
			GetComponent<Rigidbody2D> ().AddForce(new Vector2(0f, jumpStrength));
		}
	}

	bool isCharacterOnGround()
	{
		bool isOnGround = Physics2D.Linecast(transform.position, 
			groundCheck.position, 
			1 << LayerMask.NameToLayer("Ground"));
		Debug.Log ("isOnGround = " + isOnGround);
		return isOnGround;
	}
}
