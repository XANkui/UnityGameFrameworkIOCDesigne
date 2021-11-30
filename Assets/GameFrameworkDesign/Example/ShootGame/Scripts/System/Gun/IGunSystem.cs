using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public interface IGunSystem : ISystem
	{
        GunInfo CurrentGun { get; } 
        
    }

    public class GunSystem : AbstractSystem,IGunSystem {

        public GunInfo CurrentGun { get; } = new GunInfo() { 
            BulletCount=new BindableProperty<int>() { Value=3}
        };

        protected override void OnInit()
        {
            
        }
    }
}
