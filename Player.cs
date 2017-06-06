using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool ItsEnemy;
	public Vector2 coordinats;
	public Vector3 position;
	public Animator anim;
	public int walk = Animator.StringToHash ("Walk");
	public bool moved;
	public float speedmoved = 5F;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void OnMouseDown() {
		if (!ItsEnemy)
			GameObject.Find ("Scripts").GetComponent<Move> ().NowPlayer = gameObject;
	}
		
	void Update () {
		if (moved) {
			Vector3 newDir = Vector3.RotateTowards(transform.forward, (position - transform.position), 1, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
			transform.position = Vector3.MoveTowards(transform.position, position , Time.deltaTime * speedmoved);
			if (transform.position.x == position.x && transform.position.z == position.z) { 
				Debug.Log ("Stopped");
				anim.SetTrigger("Walk");
				moved = false;
			}
		}
	}
}