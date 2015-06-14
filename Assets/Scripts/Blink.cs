using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {

	public float repeatTime;
	public float blinkPercentMin;
	public float blinkPercentMax;

	private float currTime = 0f;
	private float blinkTime;
	private bool on = true;

	// Use this for initialization
	void Start () {

		blinkTime = Random.Range(blinkPercentMin, blinkPercentMax) / 100 * repeatTime;

		currTime = Random.Range (0, repeatTime);

		if (currTime >= blinkTime) {

			on = false;

			var mat = GetComponent<Renderer> ();
			mat.material.SetColor ("_Color", Color.clear);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
		currTime+= Time.deltaTime;

		if (on && currTime >= blinkTime) {

			on = false;
			
			var mat = GetComponent<Renderer> ();
			mat.material.SetColor ("_Color", Color.clear);

		} else if (currTime >= repeatTime) {

			on = true;
			
			var mat = GetComponent<Renderer> ();
			mat.material.SetColor ("_Color", Color.white);

			currTime = 0;
		}

	}

	public float getCurrTime() {
		return currTime;
	}

	public float getBlinkTime() {
		return blinkTime;
	}

	public void change(float newCurrTime, float newBlinkTime) {

		currTime = newCurrTime;
		blinkTime = newBlinkTime;

	}
}
