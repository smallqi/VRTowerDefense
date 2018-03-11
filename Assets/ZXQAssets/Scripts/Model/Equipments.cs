using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipments{
	//英雄所能装备武器的最大数目
	private int maxEquipmentAccount;
	public int MaxEquipmentAccount {
		get { return maxEquipmentAccount; }
	}
	//英雄当前装备武器的数目
	private int curEquipmentAccount;
	public int CurEquipmentAccount {
		get { return curEquipmentAccount; }
	}
	//装备的武器数组
	public List<Good> weapons;

	//构造函数
	public Equipments(int xmaxEquipmentAccount = 3) {
		maxEquipmentAccount = xmaxEquipmentAccount;
		curEquipmentAccount = 0;
		weapons = new List<Good> ();
	}
	//装备武器
	public void AddWeapon(Good weapon) {
		if (curEquipmentAccount < maxEquipmentAccount) {
			weapons.Add (weapon);
			curEquipmentAccount++;
		}
	}
	//卸下武器
	public void RemoveWeapon(Good weapon) {
		if(weapons.Contains(weapon)) {
			weapons.Remove(weapon);
			curEquipmentAccount--;
		}
	}
	//升级装备栏
	public void UpdateEquipments(){
		if (maxEquipmentAccount < 100) {
			maxEquipmentAccount++;
		}
	}
}
