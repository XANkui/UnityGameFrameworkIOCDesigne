using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager { 

	public class SceneSystem 
	{
		SceneState _sceneState;

		/// <summary>
		/// 设置当前场景并进入当前场景
		/// </summary>
		/// <param name="state"></param>
		public void SetScene(SceneState state) {
			_sceneState?.OnExit();
			_sceneState = state;
			_sceneState?.OnEnter();
		}
	}
}
