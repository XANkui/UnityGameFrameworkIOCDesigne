using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFrameworkDesign.Manager.Test {

    /// <summary>
    /// 开始面板
    /// </summary>
    public class StartPanel : BasePanel
    {
        static readonly string path = "Prefabs/UI/Panel/StartPanel";

        public StartPanel() : base(new UIType(path))
        {
            
        }

        public override void OnEnter()
        {
            Debug.Log(GetType()+ " /OnEnter()/ ");
            UITool.GetOrAddComponentInChildren<Button>("SettingsBtn").onClick.AddListener(() => {
                Debug.Log("SettingsBtn 被点击了");
                PanelManager.Push(new SettingsPanel());
            }); 
            UITool.GetOrAddComponentInChildren<Button>("EnterMainBtn").onClick.AddListener(() => {
                Debug.Log("EnterMainBtn 被点击了");
                GameRoot.Instance.SceneSystem.SetScene(new MainScene()) ;
            });
        }
    }
}
