using GameFrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp { 

	public class CounterAppArchitecture : Architecture<CounterAppArchitecture>
	{
		
        protected override void Init()
        {
            RegisterModel<ICounterModel>(new CounterModel());
            RegisterUtility<ICounterStorage>(new PlayerPrefsCounterStorage());
        }
    }
}
