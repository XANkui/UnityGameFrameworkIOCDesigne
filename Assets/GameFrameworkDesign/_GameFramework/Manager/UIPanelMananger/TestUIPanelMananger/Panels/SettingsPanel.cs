using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFrameworkDesign.Manager.Test { 

	public class SettingsPanel : BasePanel
	{
		static readonly string path = "Prefabs/UI/Panel/SettingsPanel";

        public SettingsPanel() : base(new UIType(path))
        {
        }

        public override void OnEnter()
        {
            UITool.GetOrAddComponentInChildren<Button>("CloseBtn").onClick.AddListener(() => {
                Debug.Log("CloseBtn 被点击了");
                PanelManager.Pop();
            });
        }

    }
}
