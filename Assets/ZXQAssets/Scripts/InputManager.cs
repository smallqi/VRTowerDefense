using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 作为和手势输入识别的接口
 * 统一管理所有输入事件
 * 暂时没用，纠结于向MsgCenter发送消息不是更直接，何必搞多这一步
 */


public class InputManager{

	//当一个手指时响应
	public static void OnOneFingerAppear(){
		//Todo....
		MessageCenter.PostMsg(MsgType.ONE_FINGER_APPEAR);
	
	}
	//当两个手指时响应
	public static void OnTwoFingerAppear(){
		//Todo....
		MessageCenter.PostMsg(MsgType.TWO_FINGER_APPEAR);
	}
	//当三个手指时响应
	public static void OnThreeFingerAppear(){
		//Todo....
		MessageCenter.PostMsg(MsgType.THREE_FINGER_APPEAR);
	}
	//当四个手指时响应
	public static void OnFourFingerAppear(){
		//Todo....
		MessageCenter.PostMsg(MsgType.FOUR_FINGER_APPEAR);
	}
	//当五个手指时响应
	public static void OnFiveFingerAppear(){
		//Todo....
		MessageCenter.PostMsg(MsgType.FIVE_FINGER_APPEAR);
	}

	//当眼球注视事件发生时
	public static void OnClickEvent() {
		//Todo.....
		MessageCenter.PostMsg(MsgType.CLICK_EVENT);
	}
}
