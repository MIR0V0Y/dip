using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public GameObject StoreObject;
	public Vector2 coordinats;
	bool Activ = false;
	public Material Black;
	public Material Main;
	public Material Texture;

	// Use this for initialization
	void Start () {
	
	}

	bool PlayerReadyGo () {
		if (GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer != null) {
			StoreObject = GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer;
			if (Vector3.Distance(StoreObject.transform.position, transform.position) < StoreObject.GetComponent<Warrior>().MaxDistanse)	{
				if ((gameObject.tag != "Zero") && (gameObject.tag != "First") && (gameObject.tag != "Second")) {
					bool raycast = Physics.Raycast (StoreObject.transform.position, (transform.position - StoreObject.transform.position) + Vector3.up * 0.5F, Vector3.Distance (StoreObject.transform.position, transform.position));
					if (raycast) {
						StoreObject = null;
						return false;
					}
					else {
						
						return true;}
					
				} 
				return false;
			}
			return false;
		} 
		return false;
	}

	void PlayerGo () {
		GameObject.Find ("Block" + StoreObject.GetComponent<Player> ().coordinats.x + "|" + StoreObject.GetComponent<Player> ().coordinats.y).GetComponent<Block>().StoreObject = null;
		StoreObject.GetComponent<Player> ().coordinats = coordinats;
		StoreObject.GetComponent<Player> ().position = transform.position;
		StoreObject.GetComponent<Player> ().moved = true;
		StoreObject.GetComponent<Warrior> ().MovePoint--;
	}

	void OnMouseDown() {		// нажали на объект
		if (GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep)
		if ((GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer!= null) && (GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer.GetComponent<Warrior> ().MovePoint > 0))
			if (PlayerReadyGo ())
				PlayerGo ();
		
	}


	void OnMouseEnter() {
		if (!Activ) {
		if (transform.Find ("Sphere") != null) {
			transform.Find ("Sphere").GetComponent<Renderer> ().material = Main;
			transform.Find ("Sphere").transform.position += Vector3.up * 0.1F;
			}}
	}



	void OnMouseExit() {
		if (!Activ) {
			if (transform.Find ("Sphere") != null) {
				transform.Find ("Sphere").GetComponent<Renderer> ().material = Black;
				transform.Find ("Sphere").transform.position -= Vector3.up * 0.1F;
			}}
	}

	// Update is called once per frame
	void Update () {





		if (Input.GetKey (KeyCode.Space)) {
			Cursor.visible = false;
			if (transform.Find ("Sphere") != null){
				if (!Activ) {
					transform.Find ("Sphere").transform.position += Vector3.up * 0.1F;
					transform.Find ("Sphere").GetComponent<Renderer> ().material = Main;
					Activ = true;
				}
		}
			if (transform.Find ("Cube") != null) {
				transform.Find ("Cube").GetComponent<Renderer> ().material = Texture;
			}
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			Cursor.visible = true;
			if (transform.Find ("Sphere") != null) {
				transform.Find ("Sphere").transform.position -= Vector3.up*0.1F;
				transform.Find ("Sphere").GetComponent<Renderer> ().material = Black;
			}
			if (transform.Find ("Cube") != null) {
				transform.Find ("Cube").GetComponent<Renderer> ().material = Black;
			}
			Activ = false;
		}
	}


}
