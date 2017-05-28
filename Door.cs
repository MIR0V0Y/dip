using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
			if (GameObject.Find ("Block" + (gameObject.GetComponent<Block> ().coordinats.x + -1) + "|" + (gameObject.GetComponent<Block> ().coordinats.y)).tag == "First") {
			transform.Find("Cube").transform.rotation = Quaternion.Euler (0, 90, 0);
			}
			if (GameObject.Find ("Block" + (gameObject.GetComponent<Block> ().coordinats.x + 1) + "|" + (gameObject.GetComponent<Block> ().coordinats.y)).tag == "First") {
			transform.Find("Cube").transform.rotation = Quaternion.Euler (0, 90, 0);
			}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
