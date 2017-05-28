using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class EnemyStay : MonoBehaviour {

	public GameObject EnemyPref;

	public int ColEnemy;

	public GameObject start;

	public List<GameObject> Enemy = new List<GameObject> ();



	// Use this for initialization
	void Awake () {

		//-------------------------------------------------------------------------Считывание--------------------------------------------------------------------------
		string[] lines = System.IO.File.ReadAllLines(@"WriteEnemy.txt");
		ColEnemy = Int32.Parse(lines [0]);
		Vector2[] CoordEnemy = new Vector2[ColEnemy];
		GameObject[] enemy = new GameObject[ColEnemy];
		for (int i = 0; i < ColEnemy; i++) {
			CoordEnemy [i].x = Int32.Parse (lines [i + 1]);
			CoordEnemy [i].y = Int32.Parse (lines [i + 1 + ColEnemy]);
		}


		//---------------------------------------------------------------------------------------------------------------------------------------------------------------

		for (int i = 0; i < ColEnemy; i++) {
			start = (GameObject)GameObject.Find ("Block" + CoordEnemy [i].x + "|" + CoordEnemy[i].y);		// Сделать переменные для координат через Vector 2


			enemy[i] = (GameObject)Instantiate (EnemyPref, start.transform.position + Vector3.up * 1.1F, Quaternion.identity);

			enemy[i].GetComponent<Player> ().coordinats = CoordEnemy[i];
			enemy [i].name = "Enemy" + i;
			Enemy.Add (enemy [i]);

		}
	}

	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
