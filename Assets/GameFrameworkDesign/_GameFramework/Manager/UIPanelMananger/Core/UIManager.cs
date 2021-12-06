using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager {

	/// <summary>
	/// 存储所有 UI 信息，并可以创建或者销毁 UI
	/// </summary>
	public class UIManager
	{
		/// <summary>
		/// 存储 UI 的字典
		/// </summary>
		private Dictionary<UIType, GameObject> _uiDic;

		public UIManager() {
			_uiDic = new Dictionary<UIType, GameObject>();
		}

		/// <summary>
		/// 获取 UI 对象
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public GameObject GetSingleUI(UIType type) {
			GameObject parent = GameObject.Find("Canvas");
            if (!parent)
            {
				Debug.LogError(GetType()+ "/GetSingleUI()/ Canvas 不存在");
				return null;
            }

			if (_uiDic.ContainsKey(type))
			{
				return _uiDic[type];
			}
			else {
				GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path),parent.transform);
				ui.name = type.Name;
				_uiDic.Add(type,ui);
				return ui;
			}
		}

		/// <summary>
		/// 销毁一个 UI 对象
		/// </summary>
		/// <param name="type"></param>
		public void DestroyUI(UIType type) {
			if (_uiDic.ContainsKey(type))
			{
				GameObject.Destroy(_uiDic[type]);
				_uiDic.Remove(type);
			}
			else {
				Debug.LogError(GetType() + "/DestroyUI()/ UI 对象 不存在，UIType.Name = "+type.Name);
			}
		}
	}
}
