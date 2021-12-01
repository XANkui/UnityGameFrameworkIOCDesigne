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
            BulletCountInGun=new BindableProperty<int>() { Value=3},
            BulletCountOutGun = new BindableProperty<int>() { Value =1},
            GunName = new BindableProperty<string>() { Value="手枪"},
            GunState = new BindableProperty<GunState>() { Value=GunState.Idle}
        };

        protected override void OnInit()
        {
            
        }
    }
}
