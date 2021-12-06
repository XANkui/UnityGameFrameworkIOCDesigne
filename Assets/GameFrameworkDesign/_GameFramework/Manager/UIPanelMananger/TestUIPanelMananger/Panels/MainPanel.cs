using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFrameworkDesign.Manager.Test { 

	public class MainPanel : BasePanel
	{
        static readonly string path = "Prefabs/UI/Panel/MainPanel";

        public MainPanel() : base(new UIType(path))
        {
        }

        public override void OnEnter()
        {
            UITool.GetOrAddComponentInChildren<Button>("BackStartBtn").onClick.AddListener(() => {
                Debug.Log("BackStartBtn 被点击了");
                GameRoot.Instance.SceneSystem.SetScene(new StartScene());
            });
        }
    }
}
