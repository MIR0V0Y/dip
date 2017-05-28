// При закрытии двери нужно нажать два раза, из за того, что переменная activ должна быть в скрипте с дверью!

using UnityEngine;
using System.Collections;

public class Open : MonoBehaviour {

	public bool activ = false;
	public Vector2 OpenCoord;
	public Vector3 OpenPos;
	public GameObject open;
	public GameObject close;
	public Quaternion rotate = new Quaternion();


	// Use this for initialization
	void Start () {

		if (GameObject.Find ("Block" + (gameObject.GetComponent<Block> ().coordinats.x + 1) + "|" + (gameObject.GetComponent<Block> ().coordinats.y )).tag == "Door")
			OpenCoord = new Vector2 (gameObject.GetComponent<Block> ().coordinats.x +1, gameObject.GetComponent<Block> ().coordinats.y);
		if (GameObject.Find ("Block" + (gameObject.GetComponent<Block> ().coordinats.x + -1) + "|" + (gameObject.GetComponent<Block> ().coordinats.y )).tag == "Door")
			OpenCoord = new Vector2 (gameObject.GetComponent<Block> ().coordinats.x -1, gameObject.GetComponent<Block> ().coordinats.y);
		if (GameObject.Find ("Block" + (gameObject.GetComponent<Block> ().coordinats.x ) + "|" + (gameObject.GetComponent<Block> ().coordinats.y +1)).tag == "Door")
			OpenCoord = new Vector2 (gameObject.GetComponent<Block> ().coordinats.x, gameObject.GetComponent<Block> ().coordinats.y+1);
		if (GameObject.Find ("Block" + (gameObject.GetComponent<Block> ().coordinats.x ) + "|" + (gameObject.GetComponent<Block> ().coordinats.y -1)).tag == "Door")
			OpenCoord = new Vector2 (gameObject.GetComponent<Block> ().coordinats.x, gameObject.GetComponent<Block> ().coordinats.y-1);

	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.F)) {

			if (GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer.GetComponent<Warrior>().MovePoint >0)
			if (gameObject.GetComponent<Block> ().StoreObject == GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer) {
				OpenPos = GameObject.Find ("Block" + OpenCoord.x + "|" + OpenCoord.y).transform.position;
				if (activ) {
					rotate = GameObject.Find ("Block" + OpenCoord.x + "|" + OpenCoord.y).transform.rotation;
					Destroy (GameObject.Find ("Block" + OpenCoord.x + "|" + OpenCoord.y));
					GameObject block = (GameObject)Instantiate (close, OpenPos, rotate);
					block.name = "Block" + OpenCoord.x + "|" + OpenCoord.y;
					block.GetComponent<Block> ().coordinats = OpenCoord;
					block.transform.parent = GameObject.Find ("Setka").transform;	
					activ = false;
				} else {
					rotate = GameObject.Find ("Block" + OpenCoord.x + "|" + OpenCoord.y).transform.rotation;
					Destroy (GameObject.Find ("Block" + OpenCoord.x + "|" + OpenCoord.y));
					GameObject block = (GameObject)Instantiate (open, OpenPos, rotate);
					block.name = "Block" + OpenCoord.x + "|" + OpenCoord.y;
					block.GetComponent<Block> ().coordinats = OpenCoord;
					block.transform.parent = GameObject.Find ("Setka").transform;	
					activ = true;
				}
				GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer.GetComponent<Warrior> ().MovePoint--;

			}

		}


	}



}
