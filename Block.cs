using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public GameObject StoreObject;
	public Vector2 coordinats;
	bool Activ = false;
	public Material Black;
	public Material Main;
	public Material Texture;

	bool PlayerReadyGo () {
		StoreObject = GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer;
		if ((Vector3.Distance(StoreObject.transform.position, transform.position) < StoreObject.GetComponent<Warrior>().MaxDistanse) 
			&& (StoreObject.GetComponent<Warrior> ().MovePoint > 0) && (gameObject.tag != "Zero") 
			&& (gameObject.tag != "First") && (gameObject.tag != "Second") && (!StoreObject.GetComponent<Player>().moved)){
				// Кидаем луч от нас к врагу
				bool raycast = Physics.Raycast (StoreObject.transform.position, (transform.position - StoreObject.transform.position) + Vector3.up * 0.5F, Vector3.Distance (StoreObject.transform.position, transform.position));
				if (raycast) {
					StoreObject = null;
					return false;
				}
				else 
					return true;
			}
		return false;
	}

	void PlayerGo () {
		GameObject.Find ("Block" + StoreObject.GetComponent<Player> ().coordinats.x + "|" + StoreObject.GetComponent<Player> ().coordinats.y).GetComponent<Block>().StoreObject = null;
		StoreObject.GetComponent<Player> ().coordinats = coordinats;
		StoreObject.GetComponent<Player> ().position = transform.position;
		StoreObject.GetComponent<Player> ().position.y = StoreObject.transform.position.y;
		StoreObject.GetComponent<Player> ().moved = true;
		StoreObject.GetComponent<Player> ().anim.SetTrigger("Walk");
		StoreObject.GetComponent<Warrior> ().MovePoint--;
	}

	void OnMouseDown() {		// нажали на объект
		if (GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep)
		if ((GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer!= null) )
			if (PlayerReadyGo ())
				PlayerGo ();
	}
		
	void OnMouseEnter() {
		if (!Activ && transform.Find ("Sphere") != null) {
			transform.Find ("Sphere").GetComponent<Renderer> ().material = Main;
			transform.Find ("Sphere").transform.position += Vector3.up * 0.1F;
		}
	}
		
	void OnMouseExit() {
		if (!Activ && transform.Find ("Sphere") != null) {
				transform.Find ("Sphere").GetComponent<Renderer> ().material = Black;
				transform.Find ("Sphere").transform.position -= Vector3.up * 0.1F;
		}
	}
		
	void Update () {
		// Подсветка типа блоков
		if (Input.GetKey (KeyCode.Space)) {
			Cursor.visible = false;
			if (transform.Find ("Sphere") != null && !Activ){
				transform.Find ("Sphere").transform.position += Vector3.up * 0.1F;
				transform.Find ("Sphere").GetComponent<Renderer> ().material = Main;
				Activ = true;
			}
			if (transform.Find ("Cube") != null) 
				transform.Find ("Cube").GetComponent<Renderer> ().material = Texture;
		}

		if (Input.GetKeyUp(KeyCode.Space)) {
			Cursor.visible = true;
			if (transform.Find ("Sphere") != null) {
				transform.Find ("Sphere").transform.position -= Vector3.up*0.1F;
				transform.Find ("Sphere").GetComponent<Renderer> ().material = Black;
			}
			if (transform.Find ("Cube") != null) 
				transform.Find ("Cube").GetComponent<Renderer> ().material = Black;
			Activ = false;
		}
	}
}