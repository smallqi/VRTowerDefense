using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 全场单例
 * 管理场景的切换
 */
public enum SceneType {
	FIRST_SCENE,	//场景1
	SECOND_SCENE
}
public class MySceneManager{
	
	public const string firstScene = "scene0";
	public const string secondScene = "Demo1";

	private static MySceneManager instance;

	private SceneType currentSceneType; //标记当前场景
	public SceneType CurrentSceneType {
		get { return currentSceneType; }
	}

	public static MySceneManager ShareInstance(){
		if (instance == null)
			instance = new MySceneManager ();
		return instance;
	}

	//构造函数
	private MySceneManager() {
		currentSceneType = SceneType.FIRST_SCENE;
	}

	//切换场景
	public void loadScene(SceneType sceneType) {
		string sceneName;
		switch (sceneType) {
		case SceneType.FIRST_SCENE:
			sceneName = firstScene;
			break;
		case SceneType.SECOND_SCENE:
			sceneName = secondScene;
			MessageCenter.PostMsg (MsgType.ENTER_SCOND_SCENE);
			break;
		default :
			sceneName = firstScene;	
			break;
		}
		currentSceneType = sceneType;
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}
}
	
	