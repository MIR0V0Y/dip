using UnityEngine;
using System.Collections.Generic;

public class Warrior : MonoBehaviour {

	public bool ItsEnemy;
	public List<GameObject> watched = new List<GameObject>();

	public GameObject[] flank = new GameObject[4];

	public int HP;
	public int MovePoint;
	public int MaxMovePoint;
	public int MaxDistanse;
	public int BaseDam;
	public int visibl; // отказаться от переменной
	public int rezist;

	public bool relax = false;

	public void Watch () {
		
		for (int i = 0; i < GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy.Count; i++){
			if (Vector3.Distance (GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy[i].transform.position, transform.position) < visibl) {
			
				Debug.DrawRay (transform.position, (GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy[i].transform.Find("Fwd").transform.position - transform.position));
				RaycastHit hit;
				bool FiNd = false;
				for (int j = 0; j<4; j++)
					if (Physics.Raycast (transform.position, (GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy[i].GetComponent<Warrior>().flank[j].gameObject.transform.position - transform.position), out hit, visibl)){
				if (hit.collider.gameObject == GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy[i]) {
				//	GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy [i].GetComponent<Warrior> ().visible (false, gameObject);
							FiNd = true;
						} else{}
				//	GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy [i].GetComponent<Warrior> ().visible (true, gameObject);
				
			}
				if (FiNd) {
					GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy [i].GetComponent<Warrior> ().visible (false, gameObject);
				} else {
					GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy [i].GetComponent<Warrior> ().visible (true, gameObject);
				}
			}
	}
	}
		
	public void visible(bool Delete,GameObject Player) {
		if (Delete)	watched.Remove (Player);
		else 
			if (!watched.Contains (Player)) 
				watched.Add (Player);
		if (watched.Count == 0) gameObject.GetComponent<MeshRenderer> ().enabled = false;
		else gameObject.GetComponent<MeshRenderer> ().enabled = true;
	}



	void OnMouseDown() {		// нажали на объект
		if (GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep){
		if (ItsEnemy) {
			if (watched.Contains (GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer)) {
					if (GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer.GetComponent<Warrior> ().MovePoint > 0) {
						HP -= GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer.GetComponent<Warrior> ().BaseDam;
						if (HP <= 0) {
							GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy.Remove (gameObject);
							Destroy (gameObject);
						}
						GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer.GetComponent<Warrior> ().MovePoint--;
					}
			}
		}
	}
	}


	void EnemyReatc(){
		if (!GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep) {
			if (watched.Count != 0) {


				if (MovePoint > 0) {
					
					watched [0].GetComponent<Warrior> ().HP -= BaseDam;
				if (watched [0].GetComponent<Warrior> ().HP <= 0) {
					Destroy (watched [0]);
					watched.RemoveAt (0);
						if (watched.Count == 0)  gameObject.GetComponent<MeshRenderer> ().enabled = false;
				}
				MovePoint--;
			} 


		}
		}
	}


	void Start () {
		if (ItsEnemy) {
			flank[0] = transform.Find("Fwd").gameObject;
			flank[1] = transform.Find("Lft").gameObject;
			flank[2] = transform.Find("Rgh").gameObject;
			flank[3] = transform.Find("Bac").gameObject;
		} else {
		}
			
	}


	void Update () {

		if (ItsEnemy) {


			if (GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep) {
				MovePoint = MaxMovePoint;
				relax = true;
			} else {
				relax = false;
			}

			EnemyReatc ();
		} else {
			if (!GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep) {
				MovePoint = MaxMovePoint;
				relax = true;
			} else {
				relax = false;
			}

			Watch ();
		}
	}


}
