using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class AttackPlayer : MonoBehaviour,IController
	{
   
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                this.SendCommand(new HurtPlayerCommand(2));

            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootGame.Interface;
        }
    }
}
