using GameFrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp { 

	public class AddCommand : AbstractCommand
	{
 

        public override void OnExecute()
        {
            this.GetModel<ICounterModel>().Count.Value++;
        }
    }
}
