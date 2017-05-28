using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public int speedMove;	
	public int speedRot;
	public float xDeg;
	public float yDeg;
	public float lerpSpeed;
	Quaternion fromRotation;
	Quaternion toRotation;
	GameObject LastBlock ;
	GameObject FirstBlock ;


	void CheckPos () {
		if (transform.position.x > LastBlock.transform.position.x) 
			transform.position = new Vector3 (LastBlock.transform.position.x, transform.position.y, transform.position.z);
		if (transform.position.z > LastBlock.transform.position.z) 
			transform.position = new Vector3 (transform.position.x, transform.position.y, LastBlock.transform.position.z);
		if (transform.position.x < FirstBlock.transform.position.x) 
			transform.position = new Vector3 (FirstBlock.transform.position.x, transform.position.y, transform.position.z);
		if (transform.position.z < FirstBlock.transform.position.z) 
			transform.position = new Vector3 (transform.position.x, transform.position.y, FirstBlock.transform.position.z);


	
	}

	// Use this for initialization
	void Start () {
				FirstBlock = GameObject.Find ("Block0|0");
				LastBlock = GameObject.Find ("Scripts").GetComponent<AutoSetka> ().Block;
	}
	
	// Update is called once per frame
	void Update () {
		CheckPos ();

		if (Input.GetKey (KeyCode.W)) {

			gameObject.transform.position = new Vector3(gameObject.transform.localPosition.x + transform.forward.x*0.1F, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + transform.forward.z*0.1F  );

		//	gameObject.transform.position = gameObject.transform.localPosition + transform.forward*0.1F;
		}
		if (Input.GetKey (KeyCode.S)) {
			gameObject.transform.position = new Vector3(gameObject.transform.localPosition.x - transform.forward.x*0.1F, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - transform.forward.z*0.1F  );
		}

		if (Input.GetKey (KeyCode.Z)) {
			if (gameObject.transform.position.y <10)
				gameObject.transform.position = gameObject.transform.localPosition + Vector3.up * 0.1F;
		}
		if (Input.GetKey (KeyCode.X)) {
			if (gameObject.transform.position.y >3)
				gameObject.transform.position = gameObject.transform.localPosition - Vector3.up*0.1F;
		}


		if (Input.GetKey (KeyCode.A)) {
			gameObject.transform.position = new Vector3(gameObject.transform.localPosition.x - transform.right.x*0.1F, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - transform.right.z*0.1F  );
		}
		if (Input.GetKey (KeyCode.D)) {
			gameObject.transform.position = new Vector3(gameObject.transform.localPosition.x + transform.right.x*0.1F, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + transform.right.z*0.1F  );
		}

	/*	if (Input.GetKey (KeyCode.E)) {
			
	//		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler (transform.rotation.x , transform.localRotation.y+170, 0), Time.deltaTime * lerpSpeed/10); 
		}
		if (Input.GetKey (KeyCode.Q)) {
	//		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler (transform.rotation.x , transform.localRotation.y-170, 0), Time.deltaTime * lerpSpeed/10); 
		}*/

		if (Input.GetMouseButton(1)) {
			xDeg -= Input.GetAxis ("Mouse X") * speedRot;
			yDeg += Input.GetAxis ("Mouse Y") * speedRot;

			fromRotation = transform.rotation;
			if (yDeg < (-90))
				yDeg = -90;
			if (yDeg > 0)
				yDeg = 0;
			
			 
			toRotation = Quaternion.Euler (-yDeg, -xDeg, 0);
			transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed); 

		}


	}
}

	