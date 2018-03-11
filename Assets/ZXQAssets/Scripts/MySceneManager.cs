using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZXQ {
	
public class MySceneManager : MonoBehaviour {
		
	public static MySceneManager instance;
	
	void Awake() {
		instance = new MySceneManager ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//切换场景
	public void loadScene(string sceneName) {
		GameObject.DontDestroyOnLoad (this);
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}
}

}
	