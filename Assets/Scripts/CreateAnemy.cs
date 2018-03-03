using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create anemy.
/// </summary>
public class CreateAnemy : MonoBehaviour {
	GameObject Anemy;//申一个敌人时间
	GameObject obj;
	public int AnemyNumber = 10;//敌人总数量
	public int Anemy1Number = 4;//敌人1数量
	public int Anemy2Number = 3;//敌人2数量
	public int Anemy3Number = 2;//敌人3数量
	public int Anemy4Number = 1;//敌人4数量
	float CreateTime = 3f;//设置产生时间
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		CreateTime -= Time.deltaTime;//开始倒计时
		if (CreateTime <= 0 && AnemyNumber > 0) {
			CreateTime = 3f;//Random.Range (5f, 10f);//随机3到9秒内

			if (Anemy1Number > 0) {
				obj = (GameObject)Resources.Load ("Prefabs/Troll 1");//加载预设体到内存
				Anemy1Number--;
			}else if (Anemy2Number > 0) {
				obj = (GameObject)Resources.Load ("Prefabs/Troll 2");//加载预设体到内存
				Anemy2Number--;
			}else if (Anemy3Number > 0) {
				obj = (GameObject)Resources.Load ("Prefabs/Troll 3");//加载预设体到内存
				Anemy3Number--;
			}else if (Anemy4Number > 0) {
				obj = (GameObject)Resources.Load ("Prefabs/Troll 4");//加载预设体到内存
				Anemy4Number--;
			}
			GameObject Anemys = GameObject.Find ("Anemys");//获得Anemys对象
			if (Anemys && obj) {
				Anemy = Instantiate<GameObject> (obj);//实例化敌人
				Anemy.transform.parent = Anemys.transform;//放置到Anemys对象下
				Anemy.transform.position = new Vector3 (190.7f,7.37f,90.34f);//Random.Range (-58f, 35f), -10f, Random.Range (28f, 55f));//随机生成敌人的位置
				AnemyNumber--;
			}
			//测试
			//Debug.Log (AnemyNumber);
		} else {
			//Debug.Log ("");
		}
	}
}
