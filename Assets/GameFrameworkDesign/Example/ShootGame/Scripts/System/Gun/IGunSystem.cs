using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public interface IGunSystem : ISystem
	{
        GunInfo CurrentGun { get; }

        Queue<GunInfo> GunInfos { get; }

        void PickGun(string gunName,int bulletCountInGun, int bulletCountOutGun);

        void ShiftGun();
    }

    public class GunSystem : AbstractSystem,IGunSystem {

        private Queue<GunInfo> mGunInfos = new Queue<GunInfo>();

        protected override void OnInit()
        {

        }

        public GunInfo CurrentGun { get; } = new GunInfo() { 
            BulletCountInGun=new BindableProperty<int>() { Value=3},
            BulletCountOutGun = new BindableProperty<int>() { Value =1},
            GunName = new BindableProperty<string>() { Value="手枪"},
            GunState = new BindableProperty<GunState>() { Value=GunState.Idle}
        };

        public Queue<GunInfo> GunInfos { get => mGunInfos;  }

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
                EnqueueCurrentGun(gunName, bulletCountInGun, bulletCountOutGun);
            }
        }

        public void ShiftGun()
        {
            if (mGunInfos.Count > 0)
            {
                var nextGunInfo = mGunInfos.Dequeue();

                EnqueueCurrentGun(nextGunInfo.GunName.Value, nextGunInfo.BulletCountInGun.Value, nextGunInfo.BulletCountOutGun.Value);
            }
        }

        void EnqueueCurrentGun(string nextGunName, int nextGunBulletCountInGun, int nextGunBulletCountOutGun) 
        {
            // 复制当前的枪械信息
            var currentGunInfo = new GunInfo
            {
                GunName = new BindableProperty<string>()
                {
                    Value = CurrentGun.GunName.Value
                },
                BulletCountInGun = new BindableProperty<int>()
                {
                    Value = CurrentGun.BulletCountInGun.Value
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
            CurrentGun.GunName.Value = nextGunName;
            CurrentGun.BulletCountInGun.Value = nextGunBulletCountInGun;
            CurrentGun.BulletCountOutGun.Value = nextGunBulletCountOutGun;
            CurrentGun.GunState.Value = GunState.Idle;

            // 发送换枪事件
            this.SendEvent(new OnCurrentGunChangedEvent()
            {
                GunName = nextGunName
            });
        }

        
    }
}
