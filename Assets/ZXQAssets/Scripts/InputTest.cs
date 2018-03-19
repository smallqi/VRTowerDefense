using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 模拟手势输入测试
 */

public class InputTest : MonoBehaviour {

	public float indexTime = 1f;
	private float previousTime = 0;

	void Update() {
		if (Time.time - previousTime > indexTime) {
			if (Input.GetKey (KeyCode.Keypad0)) {
				MessageCenter.PostMsg (MsgType.NO_FINGER_APPEAR);
				previousTime = Time.time;
				return;
			}
			if (Input.GetKey (KeyCode.Keypad1)) {
				MessageCenter.PostMsg (MsgType.ONE_FINGER_APPEAR);
				previousTime = Time.time;
				//Debug.Log ("1");
				return;
			}
			if (Input.GetKey (KeyCode.Keypad2)) {
				MessageCenter.PostMsg (MsgType.TWO_FINGER_APPEAR);
				previousTime = Time.time;
				return;
			}
			if (Input.GetKey (KeyCode.Keypad3)) {
				MessageCenter.PostMsg (MsgType.THREE_FINGER_APPEAR);
				previousTime = Time.time;
				return;
			}
			if (Input.GetKey (KeyCode.Keypad4)) {
				MessageCenter.PostMsg (MsgType.FOUR_FINGER_APPEAR);
				previousTime = Time.time;
				return;
			}
			if (Input.GetKey (KeyCode.Keypad5)) {
				MessageCenter.PostMsg (MsgType.FIVE_FINGER_APPEAR);
				previousTime = Time.time;
				return;
			}
		}
		
	}

}
