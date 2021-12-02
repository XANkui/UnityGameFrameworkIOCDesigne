using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class CameraController : BaseShootGameController
	{
		private Transform mPlayerTransform;

		private float SmoothSpeed = 2;
		private float X_MIN = -5;
		private float X_MAX = 5;
		private float Y_MIN = -5;
		private float Y_MAX = 5;
		private Vector3 mTargetPos;

		// Update is called once per frame
		void Update()
		{
            if (mPlayerTransform==false)
            {
				GameObject tmp = GameObject.Find("Player");
				if (tmp != null)
				{
					mPlayerTransform = tmp.transform;
				}
				else {
					return;
				}
            }

			
			var isRight = Mathf.Sign(transform.lossyScale.x); // 获取 x 朝向
			mTargetPos.x = mPlayerTransform.position.x + 3 * isRight;
			mTargetPos.y = mPlayerTransform.position.y + 2;
			mTargetPos.z = -10;

			var pos = transform.position;

			pos = Vector3.Lerp(pos,mTargetPos,Time.deltaTime * SmoothSpeed);
			transform.position = new Vector3(Mathf.Clamp(pos.x,X_MIN,X_MAX), Mathf.Clamp(pos.y, Y_MIN, Y_MAX), pos.z);
		}
	}
}
