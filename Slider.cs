using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slider : MonoBehaviour {
	public float timer;
	float time;
	public int image;
	int img = 1;
	bool End = false;

	// Use this for initialization
	void Start () {
		time = timer;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
			SceneManager.LoadScene ("setka");
		if (!End) {
			if (timer > 0)
				timer -= Time.deltaTime;
			else {
				if (img == image)
					SceneManager.LoadScene ("setka");
				GameObject.Find (img.ToString ()).SetActive (false);
				img++;
				timer = time;
			}
		}
	}
}