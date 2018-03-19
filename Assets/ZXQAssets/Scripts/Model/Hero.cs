using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// summry
/// 英雄的基本属性定义建模
/// summry

public class Hero {

	//记录全局的英雄数目
	private static int heroAccount = 0;
	public static int HeroAccount {
		get { return heroAccount; }
	}
	//英雄ID
	private int id;
	public int Id {
		get { return id; }
	}
	//英雄名字
	private string name;
	public string Name {
		get { return name; }
		set {
			if (value.Length > 6)
				return;
			else
				name = value;
		}
	}
	//英雄图片
	public Image photo;
	//英雄等级
	private int level;
	public int Level {
		get { return level; }
	}
	private int exprience;
	//经验值
	public int Exprience {
		get {return exprience;}
	}
	//英雄最大血量
	private int maxHp;
	public int MaxHp {
		get { return maxHp; }
	}
	//英雄当前血量
	private int curHp;
	public int CurHp {
		get { return curHp; }
	}
	//家园血量
	private int homeHp;
	public int HomeHp {
		get { return homeHp; }
	}
	//英雄攻击力
	private int attack;
	public int Attack {
		get { return attack; }
	}
	//英雄攻击范围
	private int attackRange;
	public int AttackRange {
		get { return attackRange; }
	}
	//英雄攻击速度
	private int attackSpeed;
	public int AttackSpeed {
		get { return attackSpeed; }
	}
	//英雄防御力
	private int defence;
	public int Defence {
		get { return defence; }
	}

	/*
	 * 隐藏装包和背包
	 * 覆盖他们的方法
	 */
	//英雄背包
	private Bag bag;
	//英雄装备栏
	private Equipments equipments;

	//构造信息
	public Hero( Image xphoto, string xname = "libai", 
		int xlevel = 2,int xexperience = 0,  int xmaxHp = 10, int xhomeHp = 20, 
		int xattack = 2, int xattackRange = 2, int xattackSpeed = 2, int xdefence = 2) {
		heroAccount++;
		id = heroAccount;
		photo = xphoto;
		name = xname;
		level = xlevel;
		exprience = xexperience;
		curHp = maxHp = xmaxHp;
		homeHp = xhomeHp;
		attack = xattack;
		attackRange = xattackRange;
		attackSpeed = xattackSpeed;
		bag = new Bag ();
		equipments = new Equipments ();

	}
	public Hero( Image xphoto, Bag xbag, Equipments xequipments, string xname = "Yase", 
		int xlevel = 1, int xexperience = 0, int xmaxHp = 10, int xhomeHp = 20,
		int xattack = 10, int xattackRange = 10, int xattackSpeed = 10, int xdefence = 10) {
		heroAccount++;
		id = heroAccount;
		photo = xphoto;
		name = xname;
		level = xlevel;
		exprience = xexperience;
		curHp = maxHp = xmaxHp;
		attack = xattack;
		attackRange = xattackRange;
		attackSpeed = xattackSpeed;
		bag = xbag;
		equipments = xequipments;
		bag = xbag;
		equipments = xequipments;
	}


	public override string ToString ()
	{
		return string.Format ("[Hero: Id={0}, Name={1}, Level={2}, MaxHp={3}, CurHp={4}, Attack={5}, AttackRange={6}, AttackSpeed={7}, Defence={8}]", Id, Name, Level, MaxHp, CurHp, Attack, AttackRange, AttackSpeed, Defence);
	}

	//英雄的行为
	private void AddAttribute(Good good){
		curHp += good.HpAdd;
		if (curHp > maxHp)
			curHp = maxHp;
		homeHp += good.HomeHpAdd;
		attack += good.AttackAdd;
		attackRange += good.AttackRangeAdd;
		attackSpeed += good.AttackSpeedAdd;
		defence += good.DefenceAdd;
	}
	private void SubAttribute(Good good) {
		curHp -= good.HpAdd;
		if (curHp < 0)
			curHp = 1;
		homeHp -= good.HomeHpAdd;
		if (homeHp < 0)
			homeHp = 1;
		attack -= good.AttackAdd;
		attackRange -= good.AttackRangeAdd;
		attackSpeed -= good.AttackSpeedAdd;
		defence -= good.DefenceAdd;
	}


	/*
	 * 覆盖背包和装备的方法
	 */
	//装备武器
	public void AddWeapon(Good weapon) {
		if (equipments.AddWeapon (weapon)) {
			AddAttribute (weapon);
		}
	}
	//卸下武器
	public void RemoveWeapon(Good weapon) {
		if (equipments.RemoveWeapon (weapon)) {
			SubAttribute (weapon);
		}
	}
	//卸下所有武器
	public void RemoveAllWeapon() {
		foreach(Good good in equipments.weapons) {
			SubAttribute(good);
		}
		equipments.RemoveAllWeapon ();
	}
	//升级装备栏
	public void UpdateEquipments(){
		equipments.UpdateEquipments ();
	}


	//升级背包
	public void UpdateBag() {
		bag.UpdateBag ();
	}
	//增加物品
	public void AddGood(Good good) {
		bag.AddGood (good);
	}

	//使用药品
	public void UseDrug(Good good) {
		if (bag.RemoveGood (good)) {
			AddAttribute (good);
		}
	}
	//丢弃物品
	public void RemoveGood(Good good) {
		bag.RemoveGood (good);
	}
	//是否包含某个物品
	public bool ContainGood(Good good) {
		if (bag.ContainGood (good)) {
			return true;
		}
		return false;
	}
}
