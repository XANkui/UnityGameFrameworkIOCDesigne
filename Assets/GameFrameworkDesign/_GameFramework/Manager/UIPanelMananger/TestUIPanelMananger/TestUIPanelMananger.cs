using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Manager.Test { 

	public class TestUIPanelMananger : MonoBehaviour
	{
		private PanelManager _panelManager;


        private void Awake()
        {
			_panelManager = new PanelManager();
        }

        // Start is called before the first frame update
        void Start()
		{
			_panelManager.Push(new StartPanel());
		}

		
	}
}
