using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class GunPickItem : BaseShootGameController
    {

        public string GunName;
        public int BulletCountInGun;
        public int BulletCountOutGun;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                this.SendCommand(new PickGunCommand(GunName,BulletCountInGun,BulletCountOutGun) );
                Destroy(this.gameObject);
            }
        }

       
    }
}
