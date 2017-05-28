using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {

	public bool PlayerStep = true;
	public GameObject Player;			// Сделать через массивы gameobject
	public Vector2 CoordPlayer;
	public GameObject PlayerPref;

	public GameObject Player2;			// Сделать через массивы gameobject
	public Vector2 CoordPlayer2;
	public GameObject PlayerPref2;

	public GameObject NowPlayer;



	GameObject start;

	// Use this for initialization
	void Start () {

		start = GameObject.Find ("Block" + CoordPlayer.x + "|" + CoordPlayer.y);		// Сделать переменные для координат через Vector 2
		Player = (GameObject)Instantiate (PlayerPref, start.transform.position + Vector3.up * 1.1F, Quaternion.identity);
		Player.name = "Prim";
		Player.GetComponent<Player> ().coordinats = CoordPlayer;


		start = GameObject.Find ("Block" + CoordPlayer2.x + "|" + CoordPlayer2.y);		// Сделать переменные для координат через Vector 2
		Player2 = (GameObject)Instantiate (PlayerPref2, start.transform.position + Vector3.up * 1.1F, Quaternion.identity);
		Player2.GetComponent<Player> ().coordinats = CoordPlayer2;
		Player2.name = "Sec";

	}






	// Update is called once per frame
	void Update () {

		if (GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy.Count == 0) {
			GameObject.Find ("Panel (2)").GetComponent<Image>().enabled = true;
			GameObject.Find ("Win/Fail").GetComponent<Text> ().text = "Победа!";
		}

		
		if (PlayerStep)
		GameObject.Find ("Step").GetComponent<Text> ().text = "Ваш ход";
		else
		GameObject.Find ("Step").GetComponent<Text> ().text = "Ход противника";
		if (NowPlayer.gameObject != null) {
			GameObject.Find ("Name").GetComponent<Text> ().text = NowPlayer.name;
			GameObject.Find ("HP").GetComponent<Text> ().text = System.Convert.ToString(NowPlayer.GetComponent<Warrior>().HP);
			GameObject.Find ("MovePoint").GetComponent<Text> ().text = System.Convert.ToString(NowPlayer.GetComponent<Warrior>().MovePoint);
		}


		if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			PlayerStep = false;
			//if (PlayerStep) {PlayerStep = false;} 
			//else {PlayerStep = true;}
		}
		if (Input.GetKeyUp (KeyCode.KeypadEnter)) {
			PlayerStep = true;
			//if (PlayerStep) {PlayerStep = false;} 
			//else {PlayerStep = true;}
		}


	}
}
