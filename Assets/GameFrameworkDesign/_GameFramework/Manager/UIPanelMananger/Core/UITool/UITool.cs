using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager { 

	/// <summary>
	/// UI 工具
	/// </summary>
	public class UITool 
	{
		/// <summary>
		/// 当前活动的面板
		/// </summary>
		GameObject _activePanel;

		public UITool(GameObject panel) {
			_activePanel = panel;
		}

		/// <summary>
		/// 获取或者没有则添加一个组件
		/// </summary>
		/// <typeparam name="T">组件</typeparam>
		/// <returns></returns>
		public T GetOrAddComponent<T>() where T : Component {
            if (_activePanel.GetComponent<T>()==null)
            {
				_activePanel.AddComponent<T>();
            }

			return _activePanel.GetComponent<T>();
		}

		/// <summary>
		/// 根据名称查找子对象
		/// </summary>
		/// <param name="name">子对象名称</param>
		/// <returns></returns>
		public GameObject FindChildGameObject(string name) {
			Transform[] trans = _activePanel.GetComponentsInChildren<Transform>();
            foreach (Transform item in trans)
            {
                if (item.name==name)
                {
					return item.gameObject;
                }
            }

			Debug.LogError(GetType()+$"/FindChildGameObject()/{_activePanel.name}该面板没有名字为 {name} 的子对象");
			return null;
		}

		/// <summary>
		/// 根据名称获取子对象上的组件
		/// </summary>
		/// <typeparam name="T">组件</typeparam>
		/// <param name="name">子对象名称</param>
		/// <returns></returns>
		public T GetOrAddComponentInChildren<T>(string name) where T : Component {
			GameObject child = FindChildGameObject(name);
            if (child!=null)
            {
                if (child.GetComponent<T>()==null)
                {
					child.AddComponent<T>();

				}

				return child.GetComponent<T>();
            }
			Debug.LogError(GetType() + $"/GetOrAddComponentInChildren()/{_activePanel.name}该面板没有名字为 {name} 的子对象,无法获取组件 { typeof(T).Name}");
			return null;
		}
	}
}
