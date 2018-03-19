using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributesUICtrl : MonoBehaviour {

	public Text name;
	public Text level;
	public Text experience;
	public Text hp;
	public Text homeHp;
	public Text attack;
	public Text attackRange;
	public Text attackSpeed;
	public Text defend;

	public void UpdateAttributesUI(Hero hero){
		name.text = hero.Name;
		level.text = "Level:" + hero.Level.ToString();
		experience.text = "Next:" + hero.Exprience.ToString ();
		hp.text = "HP:" + hero.MaxHp.ToString ();
		homeHp.text = "HomeHP:" + hero.HomeHp.ToString ();
		attack.text = "ACK:" + hero.Attack.ToString ();
		attackRange.text = "ACKR:" + hero.AttackRange.ToString ();
		attackSpeed.text = "ACKS:" + hero.AttackSpeed.ToString ();
		defend.text = "DEF:" + hero.Defence.ToString ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
