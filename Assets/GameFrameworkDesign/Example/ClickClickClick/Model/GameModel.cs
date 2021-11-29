using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example
{
	public interface IGameModel:IModel {
		BindableProperty<int> Count { get; }
	}

	public class GameModel : AbstractModel, IGameModel
	{
		public BindableProperty<int> Count { get; } = new BindableProperty<int>() { 
			Value =0
		};

        public override void OnInit()
        {
			Debug.Log("GameModel Init");
		}
    }
}
