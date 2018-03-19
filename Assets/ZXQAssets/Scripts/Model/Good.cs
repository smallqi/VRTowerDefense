using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 物品的基本属性建模
/// </summary>
public class Good {
	//物品的种类ID，与数据文件对应
	private int id;
	public int Id {
		get { return id;}
	}
	//物品名称
	private string name;
	public string Name {
		get { return Name; }
	}
	//物品的大种类，药品或者武器
	private int kind;
	public int Kind {
		get { return kind; }
	}
	//物品的描述信息
	private string info;
	public string Info {
		get { return info; }
	}
	//物品的图片秒速信息
	public Image photo;

	///summry
	/// 物品对英雄的属性加成
	/// summry
	//血量加成
	private int hpAdd;
	public int HpAdd {
		get { return hpAdd; }
	}
	//家园血量加成
	private int homeHpAdd;
	public int HomeHpAdd {
		get { return homeHpAdd; }
	}
	//攻击力加成
	private int attackAdd;
	public int AttackAdd {
		get { return attackAdd; }
	}
	//攻击范围加成
	private int attackRangeAdd;
	public int AttackRangeAdd {
		get { return attackRangeAdd; }
	}
	//攻击速度加成
	private int attackSpeedAdd;
	public int AttackSpeedAdd {
		get { return attackSpeedAdd; }
	}
	//防御力加成
	private int defenceAdd;
	public int DefenceAdd {
		get { return defenceAdd; }
	}

	//构造函数
	public Good(int xid, string xname, int xkind, string xinfo, Image xphoto,
		int xhpAdd, int xhomeHpAdd, int xattackAdd, int xattackRangeAdd, 
		int xattackSpeedAdd, int xdefenceAdd) {
		id = xid;
		name = xname;
		kind = xkind;
		info = xinfo;
		hpAdd = xhpAdd;
		homeHpAdd = xhomeHpAdd;
		attackAdd = xattackAdd;
		attackRangeAdd = xattackRangeAdd;
		attackSpeedAdd = xattackSpeedAdd;
		defenceAdd = xdefenceAdd;
		photo = xphoto;
	}
	public Good() {
		id = 0;
		name = null;
		kind = 0;
		info = null;
		hpAdd = 0;
		homeHpAdd = 0;
		attackAdd = 0;
		attackRangeAdd = 0;
		attackSpeedAdd = 0;
		defenceAdd = 0;
		photo = null;
	}
	//重写输出函数
	public override string ToString ()
	{
		return string.Format ("[Good: id={0}, name={1}, kind={2}, info={3}, hpAdd={4}, homeHpAdd = {9}, attackAdd={5}, attackRangeAdd={6}, attackSpeedAdd={7}, defenceAdd={8}]", id, name, kind, info, hpAdd, attackAdd, attackRangeAdd, attackSpeedAdd, defenceAdd, homeHpAdd);
	}
}
