using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example {

    public interface IScoreSystem : ISystem
    {

    }

    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        protected override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();

            // 监听事件
            this.RegisterEvent<OnGamePass>(e =>
            {
                var countDownSystem = this.GetSystem<ICountDownSystem>(); 

                var timeScore = countDownSystem.CurrentRemainSeconds * 10; 

                gameModel.Score.Value += timeScore; 

                if (gameModel.Score.Value > gameModel.BestScore.Value)
                {
                    Debug.Log("新纪录");
                    gameModel.BestScore.Value = gameModel.Score.Value;
                }
            });

            this.RegisterEvent<OnKillEnemyEvent>(e =>
            {
                gameModel.Score.Value += 10;

            });

            this.RegisterEvent<OnMissEvent>(e =>
            {
                gameModel.Score.Value -= 5;
            });
        }
    }
    
}
