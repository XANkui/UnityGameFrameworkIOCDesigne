using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager { 

	/// <summary>
	/// 所有UI 面板的父类，包含 UI 面板的状态行星
	/// </summary>
	public class BasePanel 
	{
		/// <summary>
		/// UI 信息
		/// </summary>
		public UIType UIType { get; private set; }

		/// <summary>
		/// UI 管理工具
		/// </summary>
		public UITool UITool { get; private set; }

		/// <summary>
		/// 面板管理类
		/// </summary>
		public PanelManager PanelManager { get; private set; }

		/// <summary>
		/// UI 管理类
		/// </summary>
		public UIManager UIManager { get; private set; }

		public BasePanel(UIType uiType) {
			UIType = uiType;
		}

		/// <summary>
		/// 初始化管理工具
		/// </summary>
		/// <param name="uiTool"></param>
		public void Init(UITool uiTool) {
			UITool = uiTool;
		}

		/// <summary>
		/// 初始化 UI 面板管理
		/// </summary>
		/// <param name="panelManager"></param>
		public void Init(PanelManager panelManager) {
			PanelManager = panelManager;
		}

		/// <summary>
		/// 初始化 UI 管理类
		/// </summary>
		/// <param name="uiManager"></param>
		public void Init(UIManager uiManager)
		{
			UIManager = uiManager;
		}

		/// <summary>
		/// UI 进入时执行的操作，只会执行一次
		/// </summary>
		public virtual void OnEnter() { }

		/// <summary>
		/// UI 暂停时执行的操作
		/// </summary>
		public virtual void OnPause() {
			UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
		}

		/// <summary>
		/// UI 继续执行的操作
		/// </summary>
		public virtual void OnResume() {
			UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
		}

		/// <summary>
		/// UI 退出时执行的操作
		/// </summary>
		public virtual void OnExit() {
			UIManager.DestroyUI(UIType);
		}

		/// <summary>
		/// 简化调用 Push 
		/// </summary>
		/// <param name="basePanel"></param>
		public void Push(BasePanel basePanel) => PanelManager?.Push(basePanel);

		/// <summary>
		/// 简化调用 Pop
		/// </summary>
		public void Pop() => PanelManager?.Pop();
	}
}
