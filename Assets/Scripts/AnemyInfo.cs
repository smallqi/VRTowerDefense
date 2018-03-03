using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyInfo : MonoBehaviour {
	public int id = 0;
	public int attackSize = 0;
	public int attackSpeed = 0;
	public int moveSpeed = 0;
	public int life = 0;
	// Use this for initialization
	void Awake () {
		if (this.gameObject.tag.Equals ("Anemy1")) {
			id = 1;
			attackSize = 1;
			attackSpeed = 1;
			moveSpeed = 1;
			life = 20;
		}else if (this.gameObject.tag.Equals ("Anemy2")) {
			id = 2;
			attackSize = 2;
			attackSpeed = 2;
			moveSpeed = 2;
			life = 30;
		}else if (this.gameObject.tag.Equals ("Anemy3")) {
			id = 3;
			attackSize = 3;
			attackSpeed = 3;
			moveSpeed = 3;
			life = 40;
		}else if (this.gameObject.tag.Equals ("Anemy4")) {
			id = 4;
			attackSize = 4;
			attackSpeed = 4;
			moveSpeed = 4;
			life = 100;
		}
	}
}
