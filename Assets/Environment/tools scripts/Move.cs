using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	//路径寻路中的所有点
	public Transform [] paths;
	//动画组件
	private Animation animation;

	private AnemyInfo anemy;

	void Awake()
	{
		animation = GetComponent<Animation>();
		anemy = GetComponent<AnemyInfo> ();
	}

	void Start () 
	{
		Hashtable args = new Hashtable();
		//设置路径的点
		args.Add("path",paths);
		//设置类型为线性，线性效果会好一些。
		args.Add("easeType", iTween.EaseType.linear);
		//设置寻路的速度
		args.Add("speed",1.5f);
		//移动的整体时间。如果与speed共存那么优先speed
		//args.Add("time",200f);
		//不循环
		args.Add("loopType", "none");
		//是否先从原始位置走到路径中第一个点的位置
		args.Add("movetopath",false);
		//是否让模型始终面朝当面目标的方向，拐弯的地方会自动旋转模型
		//如果你发现你的模型在寻路的时候始终都是一个方向那么一定要打开这个
		args.Add("orienttopath",true);

        //处理移动过程中的事件
		//开始发生移动时调用AnimationStart方法,5.0表示它的参数
		args.Add("onstart","AnimationStart");
		args.Add("onstartparams",5.0f);
		//设置接收方法的对象，默认是自身接收,这里也可以改成别的对象
		//那么就得在接受对象的脚本中实现AnimationStart方法
		args.Add("onstarttarget",gameObject);

		//移动结束时调用,参数同上
		args.Add("oncomplete","AnimationEnd");
		args.Add("oncompleteparams","end");
		args.Add("oncompletetarget",gameObject);

		//移动中调用,参数同上
		args.Add("onupdate","AnimationUpdate");
		args.Add("onupdateparams",true);
		args.Add("onupdatetarget",gameObject);

		//让模型开始寻路	
		iTween.MoveTo(gameObject,args);
	}

	void OnDrawGizmos()
	{
		//在scene视图中绘制出路径与线
		iTween.DrawLine(paths,Color.yellow);

		iTween.DrawPath(paths,Color.red);

	}

	void OnTriggerEnter(Collider col) {  
		if (col.gameObject.tag.Equals("Bullet")) {
			//Debug.Log ("..OnTriggerEnter");
			anemy.life = anemy.life - 10;
		}
	} 
	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag.Equals("Bullet")) {
			//Debug.Log ("..OnTriggerStay");
		}
	}
	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag.Equals("Bullet")) {
			//Debug.Log ("..OnTriggerExit");
		}
	}

	//对象移动中调用
	void AnimationUpdate(bool f){
		if (anemy.life > 0) {
			animation.Play ("walk");
		} else {			
			StartCoroutine ("WaitAndPrint");
			iTween.Stop (this.gameObject);
			animation.Play ("die");
		}
		//Debug.Log ("update:"+f);
	}
	//对象开始移动时调用
	void AnimationStart(float f){
		//Debug.Log ("start:"+f);
	}
	//对象移动时调用
	void AnimationEnd(string f){
		animation.Play ("attack1");
		//Debug.Log ("end:"+f);
	}


	IEnumerator WaitAndPrint()  
	{  
		// suspend execution for 5 seconds  
		yield return new WaitForSeconds(2.5f);  
		Destroy (this.gameObject); 
	} 
}
