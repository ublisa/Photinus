using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] prefabs;
	public int number;
	public bool active = true;
	public int min;
	public int max;
	public float speed;

	private GameObject[] blinkers;
	
	// Use this for initialization
	void Start () {

		blinkers = new GameObject[number];

		for (int i = 0; i < number; i++) {
			
			GameObject it = Instantiate (prefabs [Random.Range (0, prefabs.Length)], new Vector3 (Random.Range (min, max),
			                                                                              Random.Range (min, max), Random.Range (-max, 0)),
			                       Quaternion.identity) as GameObject;

			blinkers[i] = it;
		}
	}

	void Update() {

		float[,] changes = new float[number, 2];

		float[,] distances = new float[number, number];

		for (int i = 0; i < number; i++)
			for (int j = i + 1; j < number; j++)
				distances[i,j] = Vector3.Distance(blinkers[i].transform.position, blinkers[j].transform.position);
			

		for (int num = 0; num < number; num++) {

			float least = float.MaxValue;
			int index = 0;

			for (int i = 0; i < num; i++) {

				float tempDist = distances[i,num];

				if (tempDist < least) {
					least = tempDist;
					index = i;
				}
			}

			for (int j = num + 1; j < number; j++) {
				
				float tempDist = distances[num,j];
				
				if (tempDist < least) {
					least = tempDist;
					index = j;
				}
			}

			var blinkTimes = blinkers[index].GetComponent<Blink> ();

			if (blinkTimes != null) {

				changes[num,0] = blinkTimes.getCurrTime();
				changes[num,1] = blinkTimes.getBlinkTime();
			}
		}

		for (int i = 0; i < number; i++) {

			var blink = blinkers[i].GetComponent<Blink>();

			if (blink != null) {

				float newCurrTime = blink.getCurrTime();
				newCurrTime = newCurrTime + (changes[i,0] - newCurrTime) * Time.deltaTime * speed;
				float newBlinkTime = blink.getBlinkTime();
				newBlinkTime = newBlinkTime + (changes[i,1] - newBlinkTime) * Time.deltaTime * speed;

				blink.change(newCurrTime, newBlinkTime);
			}

		}

	}
	
}
