using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class BulletPickItem : BaseShootGameController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                this.SendCommand<AddBulletCommand>();
                Destroy(this.gameObject);
            }
        }

        
    }
}
