using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame
{ 

	public interface IPlayerModel : IModel
	{
		BindableProperty<int> HP { get; }
	}

	public class PlayerModel : AbstractModel, IPlayerModel {
        public override void OnInit()
        {
        }

        public BindableProperty<int> HP { get; }=new BindableProperty<int>() { 
            Value=3
        };
    }
}
