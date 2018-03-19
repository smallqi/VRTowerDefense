// Copyright 2017 Google Inc. All rights reserved.
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

using UnityEngine;
using UnityEngine.EventSystems;

/// Draws a circular reticle in front of any object that the user points at.
/// The circle dilates if the object is clickable.
public class GvrReticlePointer : GvrBasePointer {
  /// The constants below are expsed for testing. Minimum inner angle of the reticle (in degrees).
  public const float RETICLE_MIN_INNER_ANGLE = 1.5f;  //初始值为环
	/// Minimum inner angle for correct click 
	public const float CLICK_MIN_INNER_ANGLE = 0.0005f;

  /// Minimum outer angle of the reticle (in degrees).
  public const float RETICLE_MIN_OUTER_ANGLE = 2.0f;

  /// Angle at which to expand the reticle when intersecting with an object (in degrees).
  public const float RETICLE_GROWTH_ANGLE = -1.5f;  //选中后缩小为点

  /// Minimum distance of the reticle (in meters).
  public const float RETICLE_DISTANCE_MIN = 0.45f;  //光标初始渲染位置

  /// Maximum distance of the reticle (in meters).
  public float maxReticleDistance = 10.0f; //射线最大射程

  /// Number of segments making the reticle circle.
  public int reticleSegments = 20;  //把圆环切成多少节来渲染

  /// Growth speed multiplier for the reticle/
  public float reticleGrowthSpeed = 8.0f; //圆环增长速度

  /// Sorting order to use for the reticle's renderer.
  /// Range values come from https://docs.unity3d.com/ScriptReference/Renderer-sortingOrder.html.
  /// Default value 32767 ensures gaze reticle is always rendered on top.
  [Range(-32767, 32767)]
  public int reticleSortingOrder = 32767;

	//是否正在处于点击之中
	private bool isClicking = false;

  public Material MaterialComp { private get; set; }//当前物体的材料组件

  // Current inner angle of the reticle (in degrees).
  // Exposed for testing.
  public float ReticleInnerAngle { get; private set; }

  // Current outer angle of the reticle (in degrees).
  // Exposed for testing.
  public float ReticleOuterAngle { get; private set; }

  // Current distance of the reticle (in meters).
  // Getter exposed for testing.
  public float ReticleDistanceInMeters { get; private set; }

  // Current inner and outer diameters of the reticle, before distance multiplication.
  // Getters exposed for testing.
  public float ReticleInnerDiameter { get; private set; }

  public float ReticleOuterDiameter { get; private set; }

  public override float MaxPointerDistance { get { return maxReticleDistance; } }

  public override void OnPointerEnter(RaycastResult raycastResultResult, bool isInteractive) {
    SetPointerTarget(raycastResultResult.worldPosition, isInteractive);
  }

  public override void OnPointerHover(RaycastResult raycastResultResult, bool isInteractive) {
    SetPointerTarget(raycastResultResult.worldPosition, isInteractive);
  }

  public override void OnPointerExit(GameObject previousObject) {
    ReticleDistanceInMeters = maxReticleDistance;
    ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE;
    ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE;
		//退出变为白色,恢未点击状态
		MaterialComp.color = Color.white;
		isClicking = false;
  }

  public override void OnPointerClickDown() {}

  public override void OnPointerClickUp() {}

  public override void GetPointerRadius(out float enterRadius, out float exitRadius) {
    float min_inner_angle_radians = Mathf.Deg2Rad * RETICLE_MIN_INNER_ANGLE;
    float max_inner_angle_radians = Mathf.Deg2Rad * (RETICLE_MIN_INNER_ANGLE + RETICLE_GROWTH_ANGLE);

    enterRadius = 2.0f * Mathf.Tan(min_inner_angle_radians);
    exitRadius = 2.0f * Mathf.Tan(max_inner_angle_radians);
  }

	private bool SetPointerTarget(Vector3 target, bool interactive) {
		if (base.PointerTransform == null) {
			Debug.LogWarning("Cannot operate on a null pointer transform");
			return false;
		}

		Vector3 targetLocalPosition = base.PointerTransform.InverseTransformPoint(target);
		//获取碰撞体位置来决定光标渲染的位置
		ReticleDistanceInMeters =
			Mathf.Clamp(targetLocalPosition.z, RETICLE_DISTANCE_MIN, maxReticleDistance);
		if (interactive) {
			ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE + RETICLE_GROWTH_ANGLE;
			ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE + RETICLE_GROWTH_ANGLE;
		} else {
			ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE;
			ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE;
		}
		return true;
	}
  //更新内外角的大小使之有环形效果
  public void UpdateDiameters() {
    ReticleDistanceInMeters =
      Mathf.Clamp(ReticleDistanceInMeters, RETICLE_DISTANCE_MIN, maxReticleDistance);

    if (ReticleInnerAngle < 0f) {
      ReticleInnerAngle = 0f;
    }

    if (ReticleOuterAngle < 0f) {
      ReticleOuterAngle = 0f;
    }

    float inner_half_angle_radians = Mathf.Deg2Rad * ReticleInnerAngle * 0.5f;
    float outer_half_angle_radians = Mathf.Deg2Rad * ReticleOuterAngle * 0.5f;

    float inner_diameter = 2.0f * Mathf.Tan(inner_half_angle_radians);
    float outer_diameter = 2.0f * Mathf.Tan(outer_half_angle_radians);

    ReticleInnerDiameter =
      Mathf.Lerp(ReticleInnerDiameter, inner_diameter, Time.deltaTime * reticleGrowthSpeed);
    ReticleOuterDiameter =
      Mathf.Lerp(ReticleOuterDiameter, outer_diameter, Time.deltaTime * reticleGrowthSpeed);
	//这个操作很神奇，好像是跟着色器有关的特定名词？
    MaterialComp.SetFloat("_InnerDiameter", ReticleInnerDiameter * ReticleDistanceInMeters);
    MaterialComp.SetFloat("_OuterDiameter", ReticleOuterDiameter * ReticleDistanceInMeters);
    MaterialComp.SetFloat("_DistanceInMeters", ReticleDistanceInMeters);
	//第一次选中变为红色
		if (!isClicking && ReticleInnerDiameter < CLICK_MIN_INNER_ANGLE ) {
			MaterialComp.color = Color.red;
			//Debug.Log ("article should be red.");
			//这里发送PointerClick事件，选择确认需要的时间计算在这里统一完成而不需要在每个物体身上进行
			//物体只需要撰写监听函数就可以了
			MessageCenter.PostMsg(MsgType.CLICK_EVENT);

			isClicking = true;
		}
		//Debug.Log ("inner_diameter is " + inner_diameter);
		//Debug.Log ("ReticleInnerDiameter is " + ReticleInnerDiameter);

  }

  void Awake() {
    //当前内外光圈初始值
    ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE;
    ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE;
  }

  protected override void Start() {
    base.Start();
	//获取材质组件
    Renderer rendererComponent = GetComponent<Renderer>();
    rendererComponent.sortingOrder = reticleSortingOrder;

    MaterialComp = rendererComponent.material;

    CreateReticleVertices();//创建光标点
  }

  void Update() {
    UpdateDiameters();//更新光标直径
  }

 
  //创建光标点，顶点渲染
  private void CreateReticleVertices() {
    Mesh mesh = new Mesh();
    gameObject.AddComponent<MeshFilter>();
    GetComponent<MeshFilter>().mesh = mesh;

    int segments_count = reticleSegments;
    int vertex_count = (segments_count+1)*2;

    #region Vertices

    Vector3[] vertices = new Vector3[vertex_count];

    const float kTwoPi = Mathf.PI * 2.0f;
    int vi = 0;
    for (int si = 0; si <= segments_count; ++si) {
      // Add two vertices for every circle segment: one at the beginning of the
      // prism, and one at the end of the prism.
      float angle = (float)si / (float)(segments_count) * kTwoPi;

      float x = Mathf.Sin(angle);
      float y = Mathf.Cos(angle);

      vertices[vi++] = new Vector3(x, y, 0.0f); // Outer vertex.
      vertices[vi++] = new Vector3(x, y, 1.0f); // Inner vertex.
    }
    #endregion

    #region Triangles
    int indices_count = (segments_count+1)*3*2;
    int[] indices = new int[indices_count];

    int vert = 0;
    int idx = 0;
    for (int si = 0; si < segments_count; ++si) {
      indices[idx++] = vert+1;
      indices[idx++] = vert;
      indices[idx++] = vert+2;

      indices[idx++] = vert+1;
      indices[idx++] = vert+2;
      indices[idx++] = vert+3;

      vert += 2;
    }
    #endregion

    mesh.vertices = vertices;
    mesh.triangles = indices;
    mesh.RecalculateBounds();
#if !UNITY_5_5_OR_NEWER
    // Optimize() is deprecated as of Unity 5.5.0p1.
    mesh.Optimize();
#endif  // !UNITY_5_5_OR_NEWER
  }
}
