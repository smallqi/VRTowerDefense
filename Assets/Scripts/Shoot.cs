using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public float bulletSpeed = 10f;
	public float shotFace = 1000f;
	public Rigidbody Bullet;//子弹
	public Transform FPoint;//准心

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//方便测试，摄像头移动
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * bulletSpeed;
		float v = Input.GetAxis("Vertical") * Time.deltaTime * bulletSpeed;
		transform.Translate(new Vector3(h,0,v));
		//点击鼠标左键
		if(Input.GetButtonDown("Fire1")){
			Rigidbody clone = Instantiate (Bullet, FPoint.position, FPoint.rotation) as Rigidbody;
			clone.AddForce(FPoint.forward*shotFace);
			//clone.velocity = transform.TransformDirection (Vector3.forward * bulletSpeed);
		}		
	}
}
