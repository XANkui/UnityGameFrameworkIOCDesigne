using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class IOCExample : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			var container = new IOCContainer();
			container.Register(new WIFIManager());
			var wifiManager = container.Get<WIFIManager>();
			wifiManager.Connect();
		}

		public class WIFIManager { 
			public void Connect() {
				Debug.Log(" WIFI connect");
			}
		}
	}
}
