using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class GamePassPanel : MonoBehaviour, IController
	{
		// Start is called before the first frame update
		void Start()
		{
			this.RegisterEvent<OnGamePass>(OnGamePassEvent);
		}

		private void OnGamePassEvent(OnGamePass e) {
			transform.Find("GamePassPanel").gameObject.SetActive(true);
		}

        private void OnDestroy()
        {
			this.UnRegisterEvent<OnGamePass>(OnGamePassEvent);
		}

        public IArchitecture GetArchitecture()
        {
			return ClickClickClickArchitecture.Interface;
        }
    }
}
