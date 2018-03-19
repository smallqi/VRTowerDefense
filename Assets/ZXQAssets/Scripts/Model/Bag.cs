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
	public Dictionary<Good, int> drugs;

	//默认构造函数
	public Bag(int xmaxWeaponAccount = 3, int xmaxDrugAccount = 3) {
		maxWeaponAccount = xmaxWeaponAccount;
		curWeaponAccount = 0;
		weapons = new List<Good> ();

		maxDrugAccount = xmaxDrugAccount;
		curDrugAccount = 0;
		drugs = new Dictionary<Good, int>();
	}

	///summry
	/// 背包行为
	/// summry

	//升级背包
	public bool UpdateBag() {
		if (maxDrugAccount < 100) {
			maxDrugAccount++;
			return true;
		}
		return false;
	}
	//增加物品
	public bool AddGood(Good good) {
		switch(good.Kind) {
		case 0:
			if (curWeaponAccount < maxWeaponAccount) {
				weapons.Add (good);
				curWeaponAccount++;
				return true;
			}
			break;
		case 1:
			if (curDrugAccount < maxDrugAccount) {
				if (drugs.ContainsKey (good)) {
					drugs [good]++;
					return true;
				} else {
					drugs.Add (good, 1);
					return true;
				}
				curDrugAccount++;
			}
			break;
		default:
			break;
		}
		return false;
	}
	//是否包含某个物品
	public bool ContainGood(Good good) {
		switch(good.Kind) {
		case 0:
			if (weapons.Contains (good)) {
				return true;
			}
			break;
		case 1:
			if (drugs.ContainsKey (good) && drugs [good] > 0) {
				return true;
			}
			break;
		default:
			break;
		}
		return false;
	}

	//丢弃物品
	public bool RemoveGood(Good good) {
		switch(good.Kind) {
		case 0:
			if (weapons.Contains(good)) {
				weapons.Remove (good);
				curWeaponAccount--;
				return true;
			}
			break;
		case 1:
			if (drugs.ContainsKey (good)) {
				drugs [good]--;
				if (drugs [good] < 1) {
					drugs.Remove (good);
				}
				return true;
			}
			break;
		default:
			break;
		}
		return false;
	}	
}