using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager { 

	/// <summary>
	/// 场景状态类
	/// </summary>
	public abstract class SceneState 
	{
		/// <summary>
		/// 场景进入时的操作
		/// </summary>
		public abstract void OnEnter();

		/// <summary>
		/// 场景退出时的操作
		/// </summary>
		public abstract void OnExit();
	}
}
