using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {
	public bool PlayerStep = true;
	public GameObject Player;		
	public Vector2 CoordPlayer;
	public GameObject PlayerPref;

	public GameObject Player2;			
	public Vector2 CoordPlayer2;
	public GameObject PlayerPref2;

	public GameObject NowPlayer;
	GameObject start;

	// Расстановка игроков
	void Start () {
		start = GameObject.Find ("Block" + CoordPlayer.x + "|" + CoordPlayer.y);		
		Player = (GameObject)Instantiate (PlayerPref, start.transform.position + Vector3.up * 1.1F, Quaternion.identity);
		Player.name = "Жак";
		Player.GetComponent<Player> ().coordinats = CoordPlayer;

		start = GameObject.Find ("Block" + CoordPlayer2.x + "|" + CoordPlayer2.y);		
		Player2 = (GameObject)Instantiate (PlayerPref2, start.transform.position + Vector3.up * 1.1F, Quaternion.identity);
		Player2.GetComponent<Player> ().coordinats = CoordPlayer2;
		Player2.name = "Пьер";
	}

	void Update () {
		if ( GameObject.Find("Жак").GetComponent<Warrior>().HP == 0
			&& GameObject.Find("Пьер").GetComponent<Warrior>().HP == 0
		){
			GameObject.Find ("Panel (2)").GetComponent<Image>().enabled = true;
			GameObject.Find ("Win/Fail").GetComponent<Text> ().text = "Поражение!";
		}

		if (GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy.Count == 0) {
			GameObject.Find ("Panel (2)").GetComponent<Image>().enabled = true;
			GameObject.Find ("Win/Fail").GetComponent<Text> ().text = "Победа!";
		}
		if (PlayerStep)
			GameObject.Find ("Step").GetComponent<Text> ().text = "Ваш ход";
		else
			GameObject.Find ("Step").GetComponent<Text> ().text = "Ход противника";
		
		if (NowPlayer.gameObject != null) {
			GameObject.Find ("Name").GetComponent<Text> ().text = System.Convert.ToString(NowPlayer.name);
			GameObject.Find ("HP").GetComponent<Text> ().text = System.Convert.ToString(NowPlayer.GetComponent<Warrior>().HP);
			GameObject.Find ("MovePoint").GetComponent<Text> ().text = System.Convert.ToString(NowPlayer.GetComponent<Warrior>().MovePoint);
		}

		if (Input.GetKeyDown (KeyCode.Return)) 
			PlayerStep = false;

		if (Input.GetKeyUp (KeyCode.Return)) 
			PlayerStep = true;

		if (Input.GetKey (KeyCode.Escape)) 
			Application.Quit();
		
	}
}