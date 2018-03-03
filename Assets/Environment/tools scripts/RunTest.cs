using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunTest : MonoBehaviour {
	public Transform TargetObject;
	// Use this for initialization
	void Start () {
		if (TargetObject != null) {
			GetComponent<NavMeshAgent> ().destination = TargetObject.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
