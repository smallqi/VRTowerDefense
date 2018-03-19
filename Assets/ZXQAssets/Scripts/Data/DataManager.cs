using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//xml读取所需头文件
using System.Xml;
using System.IO;

/// <summary>
/// 采用单例模式用于管理全局的资源加载
/// </summary>
public class DataManager{

	//全局单例
	private static DataManager dataManager;
	//保存所有的商品信息
	public List<Good> goods;


	//构造函数
	//私有防止产生多个
	private DataManager() {
		goods = new List<Good> ();
		LoadGoodsData ();
	}

	//获得单例
	public static DataManager getInstance() {
		if (dataManager == null)
			dataManager = new DataManager ();
		return dataManager;
	}

	//加载xml文件中的所有物品信息
	public void LoadGoodsData() {
		//创建Xml文档
		XmlDocument xml = new XmlDocument();
		//默认设置下加载xml文件
		xml.Load( XmlReader.Create(Application.dataPath+"/Goods.xml") );
		Debug.Log ("dataPath is " + Application.dataPath + "/Goods.xml");
		//获得根节点“goods”下的所有子节点“good”
		XmlNodeList xmlNodeList = xml.SelectSingleNode("goods").ChildNodes;
		//遍历子节点信息
		foreach (XmlNode node in xmlNodeList) {
			/*
			<good>
				<id>1</id>
				<name>枪</name>
				<kind>0</kind>
				<info>远距离单体射击</info>
				<hpAdd>0</hpAdd>
				<homeHpAdd>0</homeHpAdd>
				<attackAdd>10</attackAdd>
				<attackRangeAdd>20</attackRangeAdd>
				<attackSpeedAdd>10</attackSpeedAdd>
				<defenceAdd>0</defenceAdd>
				<image>null</image>
			</good>
			 */
			//获取物品属性
			int id = int.Parse(node.SelectSingleNode("id").InnerText);
			string name = node.SelectSingleNode("name").InnerText;
			int kind = int.Parse(node.SelectSingleNode("kind").InnerText);
			string info = node.SelectSingleNode("info").InnerText;
			int hpAdd = int.Parse (node.SelectSingleNode("hpAdd").InnerText);
			int homeHpAdd = int.Parse (node.SelectSingleNode("homeHpAdd").InnerText);
			int attackAdd = int.Parse (node.SelectSingleNode("attackAdd").InnerText);
			int attackRangeAdd = int.Parse (node.SelectSingleNode("attackRangeAdd").InnerText);
			int attackSpeedAdd = int.Parse (node.SelectSingleNode("attackSpeedAdd").InnerText);
			int defenceAdd = int.Parse (node.SelectSingleNode("defenceAdd").InnerText);
			string imageFileName = node.SelectSingleNode("image").InnerText;
			//创建物品实体
			Good good = new Good(id,name, kind, info, null, hpAdd, homeHpAdd, attackAdd, attackRangeAdd, attackSpeedAdd, defenceAdd);
			Debug.Log (good.ToString ());
			//加入表
			if (good != null)
				goods.Add (good);


		}
	}
}
