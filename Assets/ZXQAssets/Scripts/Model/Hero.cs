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
	//英雄背包
	public Bag bag;
	//英雄装备栏
	public Equipments equipments;

	//构造信息
	public Hero( Image xphoto, string xname = "libai", 
		int xlevel = 1, int xmaxHp = 10, int xattack = 1,
		int xattackRange = 1, int xattackSpeed = 1, int xdefence = 1) {
		heroAccount++;
		id = heroAccount;
		photo = xphoto;
		name = xname;
		level = xlevel;
		curHp = maxHp = xmaxHp;
		attack = xattack;
		attackRange = xattackRange;
		attackSpeed = xattackSpeed;
		bag = new Bag ();
		equipments = new Equipments ();
	}
	public Hero( Image xphoto, Bag xbag, Equipments xequipments, string xname = "jack", 
		int xlevel = 1, int xmaxHp = 10, int xattack = 1,
		int xattackRange = 1, int xattackSpeed = 1, int xdefence = 1) {
		heroAccount++;
		id = heroAccount;
		photo = xphoto;
		name = xname;
		level = xlevel;
		curHp = maxHp = xmaxHp;
		attack = xattack;
		attackRange = xattackRange;
		attackSpeed = xattackSpeed;
		bag = xbag;
		equipments = xequipments;
	}

	//英雄的行为之后补充

	///更新英雄属性
	public void UpdateAttributes(){
		int indexHp = 0;
		int indexAttack = 0;
		int indexAttackRange = 0;
		int indexAttackSpeed = 0;
		int indexdefence = 0;
		foreach (Good weapon in equipments.weapons) {
			indexHp += weapon.HpAdd;
			indexAttack += weapon.AttackAdd;
			indexAttackRange += weapon.AttackRangeAdd;
			indexAttackSpeed += weapon.AttackSpeedAdd;
			indexdefence += weapon.DefenceAdd;
		}
		//提升英雄属性
		curHp += indexHp;
		attack += indexAttack;
		attackRange += indexAttackRange;
		attackSpeed += indexAttackSpeed;
		defence += indexdefence;
	}

	public override string ToString ()
	{
		return string.Format ("[Hero: Id={0}, Name={1}, Level={2}, MaxHp={3}, CurHp={4}, Attack={5}, AttackRange={6}, AttackSpeed={7}, Defence={8}]", Id, Name, Level, MaxHp, CurHp, Attack, AttackRange, AttackSpeed, Defence);
	}
}
