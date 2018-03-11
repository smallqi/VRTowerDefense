using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationLoop : MonoBehaviour {

	Animation mAnimation;
	// Use this for initialization
	void Start () {
		mAnimation = this.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!mAnimation.isPlaying) {
			mAnimation.Play ("attack1");
		}
	}
}
