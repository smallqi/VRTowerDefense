using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Property user interface ctl.
/// 控制英雄属性面板的更新显示
/// </summary>

public class PropertyUICtrl : MonoBehaviour {

	//名字
	public Text nameText;
	public Text levelText;
	public Image photoImage;
	public Image hpImage;
	public Image experienceImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	//更新面板显示
	public void UpdatePanel(Hero hero) {
		nameText.text = hero.Name;
		levelText.text = hero.Level.ToString();
		photoImage = hero.photo;

		float hpPercent = hero.CurHp / (hero.MaxHp + 0.0f);
		hpImage.fillAmount = hpPercent;
	}
}
