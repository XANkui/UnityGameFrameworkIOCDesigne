using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFrameworkDesign.Manager.Test { 

	public class StartScene : SceneState
	{
        readonly string _sceneName = "StartTest";
        PanelManager _panelManager;
        public override void OnEnter()
        {
            _panelManager = new PanelManager();
            if (SceneManager.GetActiveScene().name != _sceneName)
            {
                SceneManager.LoadScene(_sceneName);
                SceneManager.sceneLoaded += SceneLoaded;
            }
            else {
                _panelManager.Push(new StartPanel());
            }
        }

        public override void OnExit()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
            _panelManager.PopAll();
        }


        private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log($"{_sceneName} 场景加载完毕");
            _panelManager.Push(new StartPanel());
            GameRoot.Instance.Push = _panelManager.Push;
        }
    }
}
