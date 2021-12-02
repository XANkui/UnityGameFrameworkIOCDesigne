using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class Trigger2DCheck : BaseShootGameController
    {
		public LayerMask TargetLayers;
		public int EnterCount;
        public bool Triggered {
            get {
                return EnterCount > 0;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsInLayerMask(collision.gameObject, TargetLayers))
            {
                EnterCount++;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsInLayerMask(collision.gameObject, TargetLayers))
            {
                EnterCount--;
            }
        }

        bool IsInLayerMask(GameObject obj,LayerMask mask) {
            var objLayerMask = 1 << obj.layer;
            return (mask.value & objLayerMask) > 0;
        }
    }
}
