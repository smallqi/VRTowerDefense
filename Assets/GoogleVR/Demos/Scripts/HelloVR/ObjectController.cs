// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace GoogleVR.HelloVR {
  using UnityEngine;

  [RequireComponent(typeof(Collider))]
  public class ObjectController : MonoBehaviour {
    private Vector3 startingPosition;
//    private Renderer renderer; //被编译器警告的太烦，遂改了改名字
	private Renderer m_renderer;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;
		//是否正在被注视中
		private bool isGazedAt;
		private float gazedAtTime; //第一次注视的时间
		private const float TIME_CLICK = 2f; //点击所需的注视时间
		
    void Start() {
      startingPosition = transform.localPosition;
      m_renderer = GetComponent<Renderer>();
      SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt) {
      if (inactiveMaterial != null && gazedAtMaterial != null) {
        m_renderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
      }
			//改变注视状态更新时间
			isGazedAt = gazedAt;
			if (isGazedAt) {
				gazedAtTime = Time.time;
			}
    }
		public void Update() {
			if (isGazedAt && Time.time - gazedAtTime > TIME_CLICK) {
				clickEvent ();
			}

		}
	
		//点击事件
		public void clickEvent(){
			Debug.Log ("Object is click");
			isGazedAt = false;
		}

    public void Reset() {
      int sibIdx = transform.GetSiblingIndex();
      int numSibs = transform.parent.childCount;
      for (int i=0; i<numSibs; i++) {
        GameObject sib = transform.parent.GetChild(i).gameObject;
        sib.transform.localPosition = startingPosition;
        sib.SetActive(i == sibIdx);
      }
    }

    public void Recenter() {
#if !UNITY_EDITOR
      GvrCardboardHelpers.Recenter();
#else
      if (GvrEditorEmulator.Instance != null) {
        GvrEditorEmulator.Instance.Recenter();
      }
#endif  // !UNITY_EDITOR
    }

    public void TeleportRandomly() {
      // Pick a random sibling, move them somewhere random, activate them,
      // deactivate ourself.
      int sibIdx = transform.GetSiblingIndex();
      int numSibs = transform.parent.childCount;
      sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
      GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

      // Move to random new location ±100º horzontal.
      Vector3 direction = Quaternion.Euler(
          0,
          Random.Range(-90, 90),
          0) * Vector3.forward;
      // New location between 1.5m and 3.5m.
      float distance = 2 * Random.value + 1.5f;
      Vector3 newPos = direction * distance;
      // Limit vertical position to be fully in the room.
      newPos.y = Mathf.Clamp(newPos.y, -1.2f, 4f);
      randomSib.transform.localPosition = newPos;

      randomSib.SetActive(true);
      gameObject.SetActive(false);
      SetGazedAt(false);
    }
  }
}
