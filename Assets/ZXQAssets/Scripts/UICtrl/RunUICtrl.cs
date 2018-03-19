using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunUICtrl : MonoBehaviour {

	private SystemController systemCtrl;

	public GameObject propertyUI;	//属性面板
	private PropertyUICtrl propertyUIctrl; //属性面板脚本
	public GameObject menuUI;	//装备栏
	private AttributesUICtrl attributersUICtrl;

	private bool isInMenuUI; //是否在UI界面

	void Awake () {
		
	}

	// Use this for initialization
	void Start () {
		//获取脚本
		systemCtrl = GameObject.FindGameObjectWithTag ("SystemCtrl").GetComponent<SystemController> ();
		if (systemCtrl == null) {
			//ErrorMessageText.print ("can't find script 'SystemController'");
			Debug.Log ("can't find script 'SystemController'");
		}
		propertyUIctrl = propertyUI.GetComponent<PropertyUICtrl> ();
		attributersUICtrl = menuUI.GetComponent<AttributesUICtrl> ();

		isInMenuUI = false;
	}
	void OnDestory() {
		RegisterListener ();
	}

	// Update is called once per frame
	void Update () {
		//实时更新属性面板
		propertyUIctrl.UpdatePanel (systemCtrl.myhero);
	}

	//更新装备栏面板
	public void UpdateMenuUI() {
		attributersUICtrl.UpdateAttributesUI (systemCtrl.myhero);
	}

	//设置出现
	public void SetMenuUIActive () {
		if (isInMenuUI)
			return;
		UpdateMenuUI ();
		menuUI.SetActive (true);
		isInMenuUI = true;
		RegisterListener ();
	}
	//设置隐藏
	public void SetMenuUIInactive () {
		if (!isInMenuUI)
			return;
		isInMenuUI = false;
		menuUI.SetActive (false);
		systemCtrl.ReturnGame ();
		CancelListener ();
	}

	//使用枪
	public void ChangeToGun() {
		if (!isInMenuUI)
			return;
		Good good = DataManager.getInstance ().goods[0];
		ChangeWeapon (good);
	}
	//使用法杖
	public void ChangeToWand() {
		if (!isInMenuUI)
			return;
		Good good = DataManager.getInstance ().goods[1];
		ChangeWeapon (good);
	}
	//使用剑
	public void ChangeToSword() {
		if (!isInMenuUI)
			return;
		Good good = DataManager.getInstance ().goods[2];
		ChangeWeapon (good);
	}
	//使用药水
	public void UseYaoShui() {
		if (!isInMenuUI)
			return;
		Good good = DataManager.getInstance ().goods[3];
		UseDrug (good);
		
	}
	//使用水晶
	public void UseShuiJing() {
		if (!isInMenuUI)
			return;
		Good good = DataManager.getInstance ().goods[4];
		UseDrug (good);
	}

	//转换武器 0->枪 1->法杖 2->剑
	public void ChangeWeapon(Good good) {
		Hero hero = systemCtrl.myhero;
		systemCtrl.myhero.RemoveAllWeapon ();
		systemCtrl.myhero.AddWeapon (good);
		UpdateMenuUI ();
	}
	//嗑药
	public void UseDrug(Good good) {
		systemCtrl.myhero.UseDrug (good);
		UpdateMenuUI ();
	}
	//注册
	private void RegisterListener() {
		//注册监听事件
		/**
		 * 零手指：返回游戏
		 * 一手指：更改装备为枪
		 * 二手指：更改装备为法杖
		 * 三手指：更改装备为剑
		 * 四手指：使用药水补血
		 * 五手指：使用水晶恢复家园血量
		 */
		MessageCenter.MsgHandlerDelegate returnGameHandler = new MessageCenter.MsgHandlerDelegate(this.SetMenuUIInactive);
		MessageCenter.AddMsgListenner(MsgType.NO_FINGER_APPEAR, returnGameHandler);
		MessageCenter.MsgHandlerDelegate UseGunHandler = new MessageCenter.MsgHandlerDelegate(this.ChangeToGun);
		MessageCenter.AddMsgListenner(MsgType.ONE_FINGER_APPEAR, UseGunHandler);
		MessageCenter.MsgHandlerDelegate UseWandHandler = new MessageCenter.MsgHandlerDelegate(this.ChangeToWand);
		MessageCenter.AddMsgListenner(MsgType.TWO_FINGER_APPEAR, UseWandHandler);
		MessageCenter.MsgHandlerDelegate UseSwordHandler = new MessageCenter.MsgHandlerDelegate(this.ChangeToSword);
		MessageCenter.AddMsgListenner(MsgType.THREE_FINGER_APPEAR, UseSwordHandler);
		MessageCenter.MsgHandlerDelegate UseYaoShuiHandler = new MessageCenter.MsgHandlerDelegate(this.UseYaoShui);
		MessageCenter.AddMsgListenner(MsgType.FOUR_FINGER_APPEAR, UseYaoShuiHandler);
		MessageCenter.MsgHandlerDelegate UseShuijingHandler = new MessageCenter.MsgHandlerDelegate(this.UseShuiJing);
		MessageCenter.AddMsgListenner(MsgType.FIVE_FINGER_APPEAR, UseShuijingHandler);
	}
	//取消
	private void CancelListener() {
		MessageCenter.MsgHandlerDelegate returnGameHandler = new MessageCenter.MsgHandlerDelegate(this.SetMenuUIInactive);
		MessageCenter.CancelMsgListenner(MsgType.NO_FINGER_APPEAR, returnGameHandler);
		MessageCenter.MsgHandlerDelegate UseGunHandler = new MessageCenter.MsgHandlerDelegate(this.ChangeToGun);
		MessageCenter.CancelMsgListenner(MsgType.ONE_FINGER_APPEAR, UseGunHandler);
		MessageCenter.MsgHandlerDelegate UseWandHandler = new MessageCenter.MsgHandlerDelegate(this.ChangeToWand);
		MessageCenter.CancelMsgListenner(MsgType.TWO_FINGER_APPEAR, UseWandHandler);
		MessageCenter.MsgHandlerDelegate UseSwordHandler = new MessageCenter.MsgHandlerDelegate(this.ChangeToSword);
		MessageCenter.CancelMsgListenner(MsgType.THREE_FINGER_APPEAR, UseSwordHandler);
		MessageCenter.MsgHandlerDelegate UseYaoShuiHandler = new MessageCenter.MsgHandlerDelegate(this.UseYaoShui);
		MessageCenter.CancelMsgListenner(MsgType.FOUR_FINGER_APPEAR, UseYaoShuiHandler);
		MessageCenter.MsgHandlerDelegate UseShuijingHandler = new MessageCenter.MsgHandlerDelegate(this.UseShuiJing);
		MessageCenter.CancelMsgListenner(MsgType.FIVE_FINGER_APPEAR, UseShuijingHandler);
	}

}
