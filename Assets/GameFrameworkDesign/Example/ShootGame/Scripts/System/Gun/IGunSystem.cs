using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public interface IGunSystem : ISystem
	{
        GunInfo CurrentGun { get; }

        void PickGun(string gunName,int bulletCountInGun, int bulletCountOutGun);
        
    }

    public class GunSystem : AbstractSystem,IGunSystem {
        private Queue<GunInfo> mGunInfos = new Queue<GunInfo>();

        public GunInfo CurrentGun { get; } = new GunInfo() { 
            BulletCountInGun=new BindableProperty<int>() { Value=3},
            BulletCountOutGun = new BindableProperty<int>() { Value =1},
            GunName = new BindableProperty<string>() { Value="手枪"},
            GunState = new BindableProperty<GunState>() { Value=GunState.Idle}
        };

        protected override void OnInit()
        {
            
        }

        public void PickGun(string gunName, int bulletCountInGun, int bulletCountOutGun)
        {
            // 当前枪是同类型
            if (CurrentGun.GunName.Value == gunName)
            {
                CurrentGun.BulletCountInGun.Value += bulletCountInGun;
                CurrentGun.BulletCountOutGun.Value += bulletCountOutGun;
            }

            // 已经拥有这把枪
            else if (mGunInfos.Any(info => info.GunName.Value == gunName))
            {
                var gunInfo = mGunInfos.First(info => info.GunName.Value == gunName);
                gunInfo.BulletCountInGun.Value += bulletCountInGun;
                gunInfo.BulletCountOutGun.Value += bulletCountOutGun;
            }
            else {
                // 复制当前枪械信息
                var currentGunInfo = new GunInfo
                {
                    GunName = new BindableProperty<string>() { 
                        Value = CurrentGun.GunName.Value
                    },
                    BulletCountInGun = new BindableProperty<int>() { 
                        Value= CurrentGun.BulletCountInGun.Value
                    },
                    BulletCountOutGun = new BindableProperty<int>()
                    {
                        Value = CurrentGun.BulletCountOutGun.Value
                    },
                    GunState = new BindableProperty<GunState>()
                    {
                        Value = CurrentGun.GunState.Value
                    }
                };

                // 缓存
                mGunInfos.Enqueue(currentGunInfo);

                // 新枪设置为当前枪
                CurrentGun.GunName.Value = gunName;
                CurrentGun.BulletCountInGun.Value = bulletCountInGun;
                CurrentGun.BulletCountOutGun.Value = bulletCountOutGun;
                CurrentGun.GunState.Value = GunState.Idle;

                // 发送换枪事件
                this.SendEvent(new OnCurrentGunChangedEvent()
                {
                    GunName = gunName
                }) ;
            }
        }
    }
}
