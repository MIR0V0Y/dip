using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//public int SpeedMoved;
	//Vector3 SpMove = new Vector3(0.01F * SpeedMoved, 0.01F * SpeedMoved, 0.01F * SpeedMoved);
	public bool ItsEnemy;
	public Vector2 coordinats;
	public Vector3 position;

	public bool moved;
	public float speedmoved = 5F;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown() {
		if (!ItsEnemy)
		GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer = gameObject;
	}

	// Update is called once per frame
	void Update () {



		if (moved) {

			transform.position = Vector3.MoveTowards(transform.position, position + Vector3.up * 1.1F, Time.deltaTime * speedmoved);


			if (transform.position == position) 
				moved = false;
			
		
		}


	}


}
