using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class Bullet : MonoBehaviour,IController
	{
		private Rigidbody2D mRigidbody2D;

		private void Awake()
        {
			mRigidbody2D = GetComponent<Rigidbody2D>();
            Destroy(this.gameObject,5);
		}

        void Start()
		{
            var isRight = Mathf.Sign(transform.lossyScale.x); // 获取 x 朝向
			mRigidbody2D.velocity = Vector2.right * 10 * isRight;
		}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                this.SendCommand<KillEnemyCommand>();
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootGame.Interface;
        }
    }
}
