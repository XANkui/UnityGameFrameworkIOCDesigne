using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class AddBulletCommand : AbstractCommand
	{
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>();
            var gunConfigModel = this.GetModel<IGunConfigModel>();

            // 给当前的枪增加子弹
            AddBullet(gunSystem.CurrentGun, gunConfigModel);

            // 遍历缓存的枪
            foreach (var gunInfo in gunSystem.GunInfos)
            {
                AddBullet(gunInfo, gunConfigModel);
            }
        }

        void AddBullet(GunInfo gunInfo, IGunConfigModel gunConfigModel)
        {
            var gunConfigItem = gunConfigModel.GetItemByName(gunInfo.GunName.Value);

            if (!gunConfigItem.NeedBullet) // 不需要子弹就是手枪
            {
                // 直接填满即可
                gunInfo.BulletCountInGun.Value = gunConfigItem.BulletMaxCount;
            }
            else
            {
                gunInfo.BulletCountOutGun.Value += gunConfigItem.BulletMaxCount;
            }
        }
    }
}
