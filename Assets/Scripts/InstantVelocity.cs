using UnityEngine;
using System.Collections;

public class InstantVelocity : MonoBehaviour {

	public int max;
	public int min;
	public float speedMax;

	private Vector3 velocity;
	// Use this for initialization
	void Start () {

		velocity = new Vector3 (Random.Range(-speedMax, speedMax), Random.Range(-speedMax, speedMax), Random.Range(-speedMax, speedMax));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		var pos = GetComponent<Transform> ().position;

		if (pos.x > max || pos.x < min) {
			velocity.x = - velocity.x;
		}
		if (pos.y > max || pos.y < min) {
			velocity.y = - velocity.y;
		}
		if (pos.z > 0 || pos.z < min) {
			velocity.z = - velocity.z;
		}

		Rigidbody body3D = GetComponent<Rigidbody> ();

		body3D.velocity = velocity;

	}
}
