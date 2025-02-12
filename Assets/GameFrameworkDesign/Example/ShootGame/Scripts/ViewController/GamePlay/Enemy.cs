﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class Enemy : BaseShootGameController
	{
		private Trigger2DCheck mWallCheck;
		private Trigger2DCheck mFallCheck;
		private Trigger2DCheck mGroundCheck;
		private Rigidbody2D mRigidbody2D;


        private void Awake()
        {
			mWallCheck = transform.Find("WallCheck").GetComponent<Trigger2DCheck>();
			mFallCheck = transform.Find("FallCheck").GetComponent<Trigger2DCheck>();
			mGroundCheck = transform.Find("GroundCheck").GetComponent<Trigger2DCheck>();
			mRigidbody2D = GetComponent<Rigidbody2D>();
		}



        private void FixedUpdate()
        {
			var scaleX = transform.localScale.x;

			if (mGroundCheck.Triggered && mFallCheck.Triggered && mWallCheck.Triggered == false)
			{
				mRigidbody2D.velocity = new Vector2(scaleX * 10, mRigidbody2D.velocity.y);
			}
			else {
				var localScal = transform.localScale;
				localScal.x = -scaleX;
				transform.localScale = localScal;
			}
        }
    }
}
