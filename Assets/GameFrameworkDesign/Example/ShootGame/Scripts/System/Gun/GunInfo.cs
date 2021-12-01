using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame {

	public enum GunState { 
		Idle,
		Shooting,
		Reload,
		EmptyBullet,
		CoolDown,
	}

	public class GunInfo 
	{
		[Obsolete("请使用 BulletCountInGun 代替",true)]
		public BindableProperty<int> BulletCount {
            get { return BulletCountInGun; }
			set { BulletCountInGun = value; }
		}

		public BindableProperty<int> BulletCountInGun;
		public BindableProperty<string> GunName;
		public BindableProperty<GunState> GunState;
		public BindableProperty<int> BulletCountOutGun;
	}
}
