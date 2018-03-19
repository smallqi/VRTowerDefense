using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 采用单例模式
 * 事件的监听采用观察者模式
 * 发生源向Center通知某一事件发生
 * 观察者向Center注册某一事件的监听,统一在awake阶段进行注册
 * 当事件发生时，Center负责调用观察者的监听方法
 */

/**
 *所有的事件类型都采用enum,并在此处定义,有需要可以新增
 */
//输入事件
public enum MsgType {
	ONE_FINGER_APPEAR, //当手势识别出一个手指的时候
	TWO_FINGER_APPEAR,
	THREE_FINGER_APPEAR,
	FOUR_FINGER_APPEAR,
	FIVE_FINGER_APPEAR,
	NO_FINGER_APPEAR,

	CLICK_EVENT,       //眼球注视点击事件

	ENTER_SCOND_SCENE	//进入游戏场景
}



public class MessageCenter{

	//设置回调方法的委托类型
	public delegate void MsgHandlerDelegate();
	//用于保存所有事件与对应委托的字典
	private static Dictionary<MsgType, MsgHandlerDelegate> msgDictionary = new Dictionary<MsgType, MsgHandlerDelegate>();

	//注册监听
	public static void AddMsgListenner(MsgType msgTpye, MsgHandlerDelegate handler) {
		if (!msgDictionary.ContainsKey (msgTpye)) {
			msgDictionary.Add (msgTpye, handler);
		} else {
			msgDictionary [msgTpye] += handler;
		}
	}
	//取消监听
	public static void CancelMsgListenner(MsgType msgTpye, MsgHandlerDelegate handler) {
		if (msgDictionary.ContainsKey (msgTpye)) {
			msgDictionary [msgTpye] -= handler;
		}
	}
	//清空字典
	public static void DeleteAllListenner() {
		msgDictionary.Clear ();
	}

	//通知消息发生
	public static void PostMsg(MsgType msgType) {
		Debug.Log ("MsgCenter get message:" + msgType);
		if (msgDictionary.ContainsKey (msgType)) {
			msgDictionary [msgType] ();
		}
	}

}
