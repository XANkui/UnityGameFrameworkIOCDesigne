using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager {

	/// <summary>
	/// 管理 UI 面板的显示隐藏（压栈和弹栈）
	/// </summary>
	public class PanelManager 
	{
		/// <summary>
		/// 存储UI面板的栈
		/// </summary>
		private Stack<BasePanel> _panelStack;
		/// <summary>
		/// UI管理器
		/// </summary>
		private UIManager _uiManager;
		private BasePanel _panel;

		public PanelManager() {
			_panelStack = new Stack<BasePanel>();
			_uiManager = new UIManager();
		}

		/// <summary>
		/// UI 的入栈操作，此操作显示指定面板
		/// </summary>
		/// <param name="nextPanel"></param>
		public void Push(BasePanel nextPanel) {
			// 如果有面板，则暂停隐藏当前面板
            if (_panelStack.Count>0)
            {
				_panel = _panelStack.Peek();
				_panel.OnPause();
            }
			_panelStack.Push(nextPanel);
			GameObject panelGo = _uiManager.GetSingleUI(nextPanel.UIType);
			nextPanel.Init(new UITool(panelGo));
			nextPanel.Init(this);
			nextPanel.Init(_uiManager);
			nextPanel.OnEnter();
		}

		/// <summary>
		/// 执行面板的出栈操作，此操作退出当前面板，显示上一个面板
		/// </summary>
		public void Pop() {
			// 退出当前面板
            if (_panelStack.Count>0)
            {
				_panelStack.Pop().OnExit();
				
            }

			//如果还有面板，则显示上一个面板
            if (_panelStack.Count>0)
            {
				_panelStack.Peek().OnResume();
            }
		}

		/// <summary>
		/// 执行所有面板的 OnExit
		/// </summary>
		public void PopAll() {
            while (_panelStack.Count>0)
            {
				_panelStack.Pop().OnExit();
            }
		}
	}
}
