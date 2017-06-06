using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class AutoSetka : MonoBehaviour {
	public GameObject BackGr;
	public GameObject BlockSetkiL;
	public GameObject BlockSetkiT;
	public GameObject BlockSetkiS;
	public GameObject BlockSetkiD;
	public GameObject BlockSetkiF;
	public GameObject BlockSetkiZ;
	//непосредственно устанавливаемый в данный момент
	GameObject BlockSetki; 			
	public GameObject Setka;
	public GameObject Block;

	void Awake () {
		//Считывание
		string[] lines = System.IO.File.ReadAllLines(@"WriteLines.txt");
		int Xsize  = Int32.Parse(lines [0]);											
		int Ysize = Int32.Parse(lines [1]);												
		short[,] cell = new short[Xsize, Ysize];										
		for (int i = 0; i < Xsize; i++) {
			string nowtext = lines [i + 2];
			for (int j = 0; j < Ysize; j++) 
				cell[i,j] =  Convert.ToInt16(nowtext [j]) ;																			
		}		

		//Расставление_блоков
		for (int i = 0; i < Xsize; i++) 
			for (int j = 0; j < Ysize; j++) {
				switch (cell [i, j]) {													
				case 48:																
					BlockSetki = BlockSetkiZ;
					break;
				case 49:
					BlockSetki = BlockSetkiF;
					break;
				case 50:
					BlockSetki = BlockSetkiS;
					break;
				case 51:
					BlockSetki = BlockSetkiD;
					break;
				case 52:
					BlockSetki = BlockSetkiT;
					break;
				case 53:
					BlockSetki = BlockSetkiL;
					break;
				}
				Block = (GameObject)Instantiate (BlockSetki, new Vector3 (i + 0.5F, 0, j + 0.5F), Quaternion.identity);	
				Block.transform.parent = Setka.transform;															
				Block.name = "Block" + i + "|" + j;
				Block.GetComponent<Block> ().coordinats.x = i;
				Block.GetComponent<Block> ().coordinats.y = j;
			}
	}

	void Start () {
		// Расставление стен локации
		GameObject Ground = new GameObject ();
		Ground = (GameObject)Instantiate(BackGr, new Vector3(Block.transform.position.x *0.5F, 0, -1), Quaternion.identity);
		Ground.transform.localScale = new Vector3 (Block.transform.position.x +3, 16, 1);
		Ground = (GameObject)Instantiate(BackGr, new Vector3(-1, 0, Block.transform.position.z *0.5F), Quaternion.Euler(0,90,0));
		Ground.transform.localScale = new Vector3 (Block.transform.position.z +3, 16, 1 );
		Ground = (GameObject)Instantiate(BackGr, new Vector3(Block.transform.position.x *0.5F, 10.5F, Block.transform.position.z *0.5F), Quaternion.Euler(90,0,0));
		Ground.transform.localScale = new Vector3 (Block.transform.position.z +3, Block.transform.position.x +3, 1 );
		Ground = (GameObject)Instantiate(BackGr, new Vector3(Block.transform.position.x *0.5F, 0, Block.transform.position.z+1), Quaternion.identity);
		Ground.transform.localScale = new Vector3 (Block.transform.position.x +3, 16, 1);
		Ground = (GameObject)Instantiate(BackGr, new Vector3(Block.transform.position.x+1, 0, Block.transform.position.z *0.5F), Quaternion.Euler(0,90,0));
		Ground.transform.localScale = new Vector3 (Block.transform.position.z +3, 16, 1 );
		Ground = (GameObject)Instantiate(BackGr, new Vector3(Block.transform.position.x *0.5F, 0, Block.transform.position.z *0.5F), Quaternion.Euler(90,0,0));
		Ground.transform.localScale = new Vector3 (Block.transform.position.z +3, Block.transform.position.x +3, 1 );
	}
}