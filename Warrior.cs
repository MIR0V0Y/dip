using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Warrior : MonoBehaviour {
	public bool ItsEnemy;
	public List<GameObject> watched = new List<GameObject>();
	public Animator anim;
	int attack = Animator.StringToHash("Attack");
	int die = Animator.StringToHash("Die");
	public GameObject[] flank = new GameObject[4];
	public int HP;
	public int MovePoint;
	public int MaxMovePoint;
	public int MaxDistanse;
	public int MaxAttackDistanse;
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
		if (watched.Count == 0) {
			GameObject model = transform.GetChild (4).gameObject;
			model.SetActive (false);
		} else {
			//gameObject.GetComponent<MeshRenderer> ().enabled = true;
			GameObject model = transform.GetChild (4).gameObject;
			model.SetActive (true);
		}
	}

	void OnMouseDown() { // Атака
		GameObject Player = GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer;
		if (GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep && ItsEnemy){
			if (watched.Contains (Player)) {
				Player.transform.rotation = Quaternion.LookRotation(transform.position - Player.transform.position);

	//			Player.transform.rotation = Quaternion.Euler(0F,transform.rotation.eulerAngles.y +180F, 0F);

				if (Player.GetComponent<Warrior> ().MovePoint > 0 &&
					Player.GetComponent<Warrior> ().MaxAttackDistanse > 
					Vector3.Distance(Player.transform.position, transform.position)
					) {
					Player.GetComponent<Warrior> ().anim.SetTrigger (attack);
					HP -= Player.GetComponent<Warrior> ().BaseDam;
						if (HP <= 0) {
							GameObject.Find ("Scripts").GetComponent<EnemyStay> ().Enemy.Remove (gameObject);
							anim.SetTrigger (die);
							//FIXME: плавное движение вниз
							gameObject.transform.position -= gameObject.transform.up *0.8F;
							gameObject.GetComponent<CapsuleCollider> ().enabled = false;
							gameObject.GetComponent<Warrior> ().enabled = false;
						}
						GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer.GetComponent<Warrior> ().MovePoint--;
					}
			}
		}
	}
		
	void EnemyReatc(){
		if (!GameObject.Find ("Scripts").GetComponent<Move> ().PlayerStep && watched.Count != 0
			&& MovePoint > 0 
			&& MaxAttackDistanse > 
			Vector3.Distance(watched [0].transform.position, transform.position)) 
		{
			if (watched [0].GetComponent<Warrior> ().HP > BaseDam) {
				watched [0].GetComponent<Warrior> ().HP -= BaseDam;
				transform.rotation = Quaternion.LookRotation (new Vector3(
					watched [0].transform.position.x - transform.localPosition.x,
					0,
					watched [0].transform.position.z - transform.localPosition.z));
			}
			// Если объект мертв
			else {
		//		Destroy (watched [0]);
				watched [0].GetComponent<Warrior> ().HP = 0;
				watched [0].GetComponent<Warrior>().anim.SetTrigger (die);
				watched [0].transform.position -= gameObject.transform.up * 0.9F;
				watched [0].GetComponent<CapsuleCollider> ().enabled = false;
				watched [0].GetComponent<Warrior> ().MovePoint = 0;
				watched [0].GetComponent<Warrior> ().enabled = false;
				watched.RemoveAt (0);
				// Если больше никто не смотрит
				if (watched.Count == 0) {
					GameObject model = transform.GetChild (4).gameObject;
					model.SetActive (false);
					/*
					if ( GameObject.Find("Prim").GetComponent<Warrior>().HP == 0
						&& GameObject.Find("Sec").GetComponent<Warrior>().HP == 0
					){
						GameObject.Find ("Panel (2)").GetComponent<Image>().enabled = true;
						GameObject.Find ("Win/Fail").GetComponent<Text> ().text = "Поражение!";
					}
					*/
				}
			}
			MovePoint--;
		}
	}
		
	void Start () {
		anim = GetComponent<Animator>();
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