using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class FullBulletCommand : AbstractCommand
	{
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>();
            var gunConfigModel = this.GetModel<IGunConfigModel>();

            gunSystem.CurrentGun.BulletCountInGun.Value =
                gunConfigModel.GetItemByName(gunSystem.CurrentGun.GunName.Value).BulletMaxCount;

            foreach (var gunSystemGunInfo in gunSystem.GunInfos)
            {
                gunSystemGunInfo.BulletCountInGun.Value =
                    gunConfigModel.GetItemByName(gunSystemGunInfo.GunName.Value).BulletMaxCount;
            }
        }
    }
}
