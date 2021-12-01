using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class ShootCommand : AbstractCommand
	{
        public readonly static ShootCommand Single = new ShootCommand();
        public override void OnExecute()
        {
            IGunSystem curGunSystem = this.GetSystem<IGunSystem>();
            curGunSystem.CurrentGun.BulletCountInGun.Value--;
            curGunSystem.CurrentGun.BulletCountOutGun.Value++;
            curGunSystem.CurrentGun.GunState.Value = GunState.Shooting;

            IGunConfigModel curGunConfigModel = this.GetModel<IGunConfigModel>();

            this.GetSystem<ITimeSystem>().AddDelayTask(1/curGunConfigModel.GetItemByName(curGunSystem.CurrentGun.GunName.Value).Frequency, ()=> {
                curGunSystem.CurrentGun.GunState.Value = GunState.Idle;
            });
        }
    }
}
