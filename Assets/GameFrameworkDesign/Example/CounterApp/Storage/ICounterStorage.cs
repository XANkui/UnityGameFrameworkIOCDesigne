using GameFrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp { 

	public interface ICounterStorage :IUtility { 
		void SaveInt(string key,int value);
		int LoadInt(string key,int defaultValue=0);
	}
}
