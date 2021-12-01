﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class Gun : MonoBehaviour,IController
	{
        private Bullet mBullet;
        private IGunSystem mGunSystem;
        private GunInfo mGunInfo;

        private void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();
            mGunSystem = this.GetSystem<IGunSystem>();
            mGunInfo = mGunSystem.CurrentGun;
        }

        public void Shoot() {
            if (mGunInfo.BulletCountInGun.Value>0 && mGunSystem.CurrentGun.GunState.Value == GunState.Idle)
            {
                var bullet = Instantiate(mBullet, mBullet.transform.position, mBullet.transform.rotation);
                bullet.transform.localScale = mBullet.transform.lossyScale;
                bullet.gameObject.SetActive(true);

                this.SendCommand(ShootCommand.Single);
            }
            
        }


        private void OnDestroy()
        {
            mBullet = null;
            mGunSystem = null;
            mGunInfo = null;
        }

        public IArchitecture GetArchitecture()
        {
            return ShootGame.Interface;
        }
    }
}
