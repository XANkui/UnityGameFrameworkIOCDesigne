﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class Player : MonoBehaviour
	{
        private Rigidbody2D mRigidbody2D;
        private bool mJumpPress = false;
        private Trigger2DCheck mGroundCheck;
        private Gun mGun;

        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mGroundCheck = transform.Find("GroundCheck").GetComponent<Trigger2DCheck>();
            mGun = transform.Find("Gun").GetComponent<Gun>();
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mJumpPress = true;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                mGun.Shoot();
            }
        }

        private void FixedUpdate()
        {
            var horizontalMovement = Input.GetAxis("Horizontal");
            mRigidbody2D.velocity = new Vector2(horizontalMovement * 5,mRigidbody2D.velocity.y);

            bool grounded = mGroundCheck.Triggered;
            
            if (mJumpPress && grounded)
            {
                mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x,5);
            }

            mJumpPress = false;
        }
    }
}
