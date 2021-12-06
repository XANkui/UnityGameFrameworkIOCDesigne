using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameFrameworkDesign.Manager.Test {

	/// <summary>
	/// 该案例依赖 UIPanelMananger Test 测试部分
	/// </summary>
	public class GameRoot : MonoBehaviour
	{
		public static GameRoot Instance { get; private set; }
		SceneSystem _sceneSystem;
		public SceneSystem SceneSystem { get => _sceneSystem; }
		public UnityAction<BasePanel> Push; // 把 Panel 面板弹出功能添加到此,简化方便调用
		private void Awake()
        {
			if (Instance == null)
			{
				Instance = this;

			}
			else {
				Destroy(gameObject);
			}
			_sceneSystem = new SceneSystem();

			DontDestroyOnLoad(gameObject);
		}

        // Start is called before the first frame update
        void Start()
		{
			_sceneSystem.SetScene(new StartScene()) ;
		}

		
	}
}
