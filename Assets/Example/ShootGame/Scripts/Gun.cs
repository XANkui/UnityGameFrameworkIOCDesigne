using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class Gun : MonoBehaviour
	{
        private Bullet mBullet;

        private void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();
        }

        public void Shoot() {
            var bullet = Instantiate(mBullet,mBullet.transform.position,mBullet.transform.rotation);
            bullet.transform.localScale = mBullet.transform.lossyScale;
            bullet.gameObject.SetActive(true);
        }
	}
}
