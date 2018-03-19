using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene0UICtrl : MonoBehaviour {
	
	//用来区分主界面UI的所有按钮
	public enum ButtonType {
		empty,
		start,
		setting,
		quit
	}
	ButtonType currentButtonType; //正在被注视的按钮

	MessageCenter.MsgHandlerDelegate clickEventHandler; //监听委托

	void Awake () {
		RegisterListener ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestory () {
		CancelListener ();
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
			MySceneManager.ShareInstance().loadScene (SceneType.SECOND_SCENE);
			break;
		case ButtonType.setting:
			Debug.Log ("setting click");
			break;
		case ButtonType.quit:
			Debug.Log ("quit click");
			break;
		}
	}
	//注册
	private void RegisterListener() {
		//注册监听
		clickEventHandler = new MessageCenter.MsgHandlerDelegate(this.HandleClickEvent);
		MessageCenter.AddMsgListenner (MsgType.CLICK_EVENT, clickEventHandler);
	}
	//取消所有注册
	private void CancelListener() {
		clickEventHandler = new MessageCenter.MsgHandlerDelegate(this.HandleClickEvent);
		MessageCenter.CancelMsgListenner (MsgType.CLICK_EVENT, clickEventHandler);
	}
}
