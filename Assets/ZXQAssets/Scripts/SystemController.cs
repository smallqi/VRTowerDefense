using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour {

	//保存英雄实例
	public Hero myhero;
	//是否在战斗还是UI中
	private bool isInGame;
	//RunUI实例
	private RunUICtrl runUIctrl;

	// Use this for initialization
	void Awake (){
		RegisterListener ();
	}
	void Start () {
		//获取脚本
		runUIctrl = GameObject.FindGameObjectWithTag("RunUICtrl").GetComponent<RunUICtrl>();

		//创建英雄
		myhero = new Hero (null, new Bag (), new Equipments ());
		//给英雄背包添加物品
		DataManager dataManager = DataManager.getInstance();
		foreach (Good good in dataManager.goods) {
			myhero.AddGood (good);
		}
		//给英雄装备武器
		myhero.AddWeapon(dataManager.goods[0]);
		//Debug.Log (myhero.ToString ());

		isInGame = true;
	}

	// Update is called once per frame
	void Update () {
		if (!isInGame)
			return;
	}
	void OnDestory() {
		RegisterListener ();
	}
	//弹出UI界面
	void EnterUI() {
		if (!isInGame)
			return;
		runUIctrl.SetMenuUIActive ();
		isInGame = false;
		CancelListener ();
	}
	//返回到当前游戏
	public void ReturnGame() {
		if (isInGame)
			return;
		isInGame = true;
		RegisterListener ();
	}

	//注册
	private void RegisterListener() {
		//注册监听,出现拳头进入UI界面
		MessageCenter.MsgHandlerDelegate enterUIHandler = new MessageCenter.MsgHandlerDelegate(this.EnterUI);
		MessageCenter.AddMsgListenner(MsgType.NO_FINGER_APPEAR, enterUIHandler);
	}
	//取消所有注册
	private void CancelListener() {
		MessageCenter.MsgHandlerDelegate enterUIHandler = new MessageCenter.MsgHandlerDelegate(this.EnterUI);
		MessageCenter.CancelMsgListenner(MsgType.NO_FINGER_APPEAR, enterUIHandler);
	}
}
