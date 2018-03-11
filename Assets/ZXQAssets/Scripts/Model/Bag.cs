using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包的基本属性定义
/// </summary>
public class Bag{

	//可存放武器的数量
	private int maxWeaponAccount;
	public int MaxWeaponAccount {
		get { return maxWeaponAccount; }
	}
	//当前武器数量
	private int curWeaponAccount;
	public int CurWeaponAccount {
		get { return curWeaponAccount; }
	}
	//武器数组
	public List<Good> weapons;
	//可存放药品数
	private int maxDrugAccount;
	public int MaxDrugAccount {
		get { return maxDrugAccount; }
	}
	//当前药品数
	private int curDrugAccount;
	public int CurDrugAccount {
		get { return curDrugAccount; }
	}
	//药品数组
	public List<Good> drugs;

	//默认构造函数
	public Bag(int xmaxWeaponAccount = 3, int xmaxDrugAccount = 3) {
		maxWeaponAccount = xmaxWeaponAccount;
		curWeaponAccount = 0;
		weapons = new List<Good> ();

		maxDrugAccount = xmaxDrugAccount;
		curDrugAccount = 0;
		drugs = new List<Good> ();
	}

	///summry
	/// 背包行为
	/// summry

	//升级背包
	public void UpdateBag() {
		if (maxDrugAccount < 100)
			maxDrugAccount++;
		if (maxWeaponAccount < 100)
			maxWeaponAccount++;
	}
	//增加物品
	public void AddGood(Good good) {
		switch(good.Kind) {
		case 0:
			if (curWeaponAccount < maxWeaponAccount) {
				weapons.Add (good);
				curWeaponAccount++;
			}
			break;
		case 1:
			if (curDrugAccount < maxDrugAccount) {
				drugs.Add (good);
				curDrugAccount++;
			}
			break;
		default:
			break;
		}
	}
	//丢弃物品
	public void RemoveGood(Good good) {
		switch(good.Kind) {
		case 0:
			if (weapons.Contains(good)) {
				weapons.Remove (good);
				curWeaponAccount--;
			}
			break;
		case 1:
			if(drugs.Contains(good)) {
				drugs.Remove (good);
				curDrugAccount--;
			}
			break;
		default:
			break;
		}
	}	
}