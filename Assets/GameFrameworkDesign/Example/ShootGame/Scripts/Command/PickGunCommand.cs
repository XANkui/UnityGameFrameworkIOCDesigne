using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class PickGunCommand : AbstractCommand
	{
        private readonly string mGunName;
        private readonly int mBulletCountInGun;
        private readonly int mBulletCountOutGun;

        public PickGunCommand(string gunName, int bulletCountInGun, int bulletCountOutGun)
        {
            this.mGunName = gunName;
            this.mBulletCountInGun = bulletCountInGun;
            this.mBulletCountOutGun = bulletCountOutGun;
        }

        public override void OnExecute()
        {
            this.GetSystem<IGunSystem>().PickGun(mGunName, mBulletCountInGun, mBulletCountOutGun);
        }
    }
}
