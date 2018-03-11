using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour {

	//保存英雄实例
	public Hero myhero;

	// Use this for initialization
	void Start () {
		//创建英雄
		myhero = new Hero (null, new Bag (), new Equipments ());
		//给英雄背包添加物品
		DataManager dataManager = DataManager.getInstance();
		foreach (Good good in dataManager.goods) {
			myhero.bag.AddGood (good);
		}
		//给英雄装备武器
		myhero.equipments.AddWeapon(myhero.bag.weapons[0]);
		//更新英雄属性
		myhero.UpdateAttributes();
		Debug.Log (myhero.ToString ());
	}
	
	// Update is called once per frame
	void Update () {

	}
}
