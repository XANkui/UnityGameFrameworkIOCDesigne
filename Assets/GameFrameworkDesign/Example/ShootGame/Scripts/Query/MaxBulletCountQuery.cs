using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class MaxBulletCountQuery : AbstractQuery<int>
	{
        private readonly string mGunName; //readonly常量是字段，只能在定义类的构造函数内修改（或者变量初始化器），派生类的构造函数不可以

        public MaxBulletCountQuery( string gunName) {
            mGunName = gunName;
        }

        protected override int OnDo()
        {
            var gunConfigModel = this.GetModel<IGunConfigModel>();
            var gunConfigItem = gunConfigModel.GetItemByName(mGunName);
            return gunConfigItem.BulletMaxCount;
        }
    }
}
