using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public interface IStateSystem : ISystem
	{
		BindableProperty<int> KillCount { get; }
	}

	public class StateSystem : AbstractSystem, IStateSystem {
        protected override void OnInit()
        {
            
        }

        public BindableProperty<int> KillCount { get; } =new BindableProperty<int>() { 
            Value=0
        };
    }
}
