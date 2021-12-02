using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

    /// <summary>
    /// 填弹
    /// </summary>
	public class ReloadBulletCommand : AbstractCommand
	{

        protected override void OnExecute()
        {
            var currentGun = this.GetSystem<IGunSystem>().CurrentGun;
            var gunConfigItem = this.GetModel<IGunConfigModel>()
                .GetItemByName(currentGun.GunName.Value);

            // 需要的子弹数理
            var needBulletCount = gunConfigItem.BulletMaxCount - currentGun.BulletCountInGun.Value;

            if (needBulletCount>0) // 有空格填弹药
            {
                if (currentGun.BulletCountOutGun.Value>0) // 有弹药
                {
                    

                    currentGun.GunState.Value = GunState.Reload;

                    this.GetSystem<ITimeSystem>().AddDelayTask(gunConfigItem.ReloadSceonds,
                        ()=> {
                            // 充足弹药
                            if (currentGun.BulletCountOutGun.Value > needBulletCount)
                            {
                                currentGun.BulletCountOutGun.Value -= needBulletCount;
                                currentGun.BulletCountInGun.Value += needBulletCount;

                            }
                            else
                            {
                                currentGun.BulletCountInGun.Value += currentGun.BulletCountOutGun.Value;
                                currentGun.BulletCountOutGun.Value = 0;

                            }

                            currentGun.GunState.Value = GunState.Idle;
                        });
                }

            }
            
        }
    }
}
