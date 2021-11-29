using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class Bullet : MonoBehaviour
	{
		private Rigidbody2D mRigidbody2D;

		private void Awake()
        {
			mRigidbody2D = GetComponent<Rigidbody2D>();

		}

        void Start()
		{
			mRigidbody2D.velocity = Vector2.right * 10;
		}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
