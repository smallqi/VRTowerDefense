using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttet : MonoBehaviour {

	void Update(){
		//1秒后删除,限制射程
		Destroy (this.gameObject,1f);
	}
	void OnCollisionEnter(Collision col) {  
		if (col.gameObject.tag.Equals("Anemy")) {
			Debug.Log ("..OnCollisionEnter");
		}
	} 
	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag.Equals("Anemy")) {
			Debug.Log ("..OnCollisionStay");
		}
	}
	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag.Equals("Anemy")) {
			Debug.Log ("..OnCollisionExit");
		}
	}

	void OnTriggerEnter(Collider col) {  
		if (col.gameObject.tag.Equals("Anemy1")||col.gameObject.tag.Equals("Anemy2")||col.gameObject.tag.Equals("Anemy3")||col.gameObject.tag.Equals("Anemy4")) {
			Debug.Log ("..OnTriggerEnter");
			Destroy(this.gameObject);  // 摧毁子弹  
		}
	} 
	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag.Equals("Anemy")) {
			Debug.Log ("..OnTriggerStay");
		}
	}
	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag.Equals("Anemy")) {
			Debug.Log ("..OnTriggerExit");
		}
	}
}
