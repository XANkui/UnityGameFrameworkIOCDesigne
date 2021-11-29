using GameFrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp { 

	public class SubCommand : AbstractCommand
	{
   
        public override void OnExecute()
        {
            CounterAppArchitecture.Get<ICounterModel>().Count.Value--;
        }
    }
}
