using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtlForScene0 : MonoBehaviour {
	
	//用来区分主界面UI的所有按钮
	public enum ButtonType {
		empty,
		start,
		setting,
		quit
	}
	ButtonType currentButtonType; //正在被注视的按钮

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnGazeEnter (int buttonType) {
		currentButtonType = (ButtonType)buttonType;
	}

	public void OnGazeExit () {
		currentButtonType = ButtonType.empty;
	}

	//游戏开始点击事件
	public void HandleClickEvent () {
		//根据不同的按钮实现不同的功能
		switch (currentButtonType) {
		case ButtonType.empty:
			Debug.Log ("empty click");
			break;
		case ButtonType.start://跳转到运行场景
			ZXQ.MySceneManager.instance.loadScene ("Demo1");
			break;
		case ButtonType.setting:
			Debug.Log ("setting click");
			break;
		case ButtonType.quit:
			Debug.Log ("quit click");
			break;
		}
	}
}
