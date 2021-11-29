using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameFrameworkDesign.Example
{ 

	public class GameStartPanel : MonoBehaviour,IController
	{
		// Start is called before the first frame update
		void Start()
		{
			transform.Find("GameStartPanel/Button").GetComponent<Button>().onClick.AddListener(()=> {
				GetArchitecture().SendCommand<StartGameCommand>();
				transform.Find("GameStartPanel").gameObject.SetActive(false);
			});
		}

        public IArchitecture GetArchitecture()
        {
			return ClickClickClickArchitecture.Interface;
        }
    }
}
