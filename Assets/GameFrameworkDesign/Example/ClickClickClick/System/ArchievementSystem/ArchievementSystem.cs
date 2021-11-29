using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class ArchievementSystem : AbstractSystem,IArchievementSystem,ICanGetModel,ICanGetUtility
	{
        public override void OnInit()
        {
            Debug.Log("ArchievementSystem  Init ");
            var gameModel = this.GetModel<IGameModel>();
            var oldCountValue = gameModel.Count.Value;
            gameModel.Count.OnValueChange += newCountValue => {
                Debug.Log("newCountValue  " + newCountValue);
                if (oldCountValue < 5 && newCountValue >= 5)
                {
                    Debug.Log("unlock 5 ");
                }

                else if (oldCountValue < 5 && newCountValue >= 10)
                {
                    Debug.Log("unlock 10 ");
                }

                oldCountValue = newCountValue;
            };
        }
    }
}
