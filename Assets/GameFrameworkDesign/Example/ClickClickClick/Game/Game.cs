using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example
{ 

	public class Game : MonoBehaviour,IController
	{
		// Start is called before the first frame update
		void Start()
		{
			this.RegisterEvent<OnGameStart>(OnGameStartEvent);
			
		}

		private void OnGameStartEvent(OnGameStart e) {
			transform.Find("Enemys").gameObject.SetActive(true);
		}

        

        private void OnDestroy()
        {
			this.UnRegisterEvent<OnGameStart>(OnGameStartEvent);
			
		}

        public IArchitecture GetArchitecture()
        {
			return ClickClickClickArchitecture.Interface;
        }
    }
}
