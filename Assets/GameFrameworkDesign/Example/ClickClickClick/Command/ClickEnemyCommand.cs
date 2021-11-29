using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class ClickEnemyCommand : AbstractCommand
	{
        public override void OnExecute()
        {
            IGameModel gameModel = this.GetModel<IGameModel>();
            gameModel.KillCount.Value++;

            if (UnityEngine.Random.Range(0, 10) < 3)
            {
                gameModel.Gold.Value += UnityEngine.Random.Range(1, 3);
            }

            this.SendEvent<OnKillEnemyEvent>();
            Debug.Log("gameModel.KillCount.Value  " + gameModel.KillCount.Value);
            if (gameModel.KillCount.Value == 10)
            {
                this.SendEvent<OnGamePass>();
            }
        }
    }
}
