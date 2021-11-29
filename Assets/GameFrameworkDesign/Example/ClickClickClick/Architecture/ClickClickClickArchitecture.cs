using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class ClickClickClickArchitecture : Architecture<ClickClickClickArchitecture>
	{

        protected override void Init()
        {
            RegisterSystem<IScoreSystem>(new ScoreSystem());
            RegisterSystem<ICountDownSystem>(new CountDownSystem());
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            RegisterSystem<IArchievementSystem>(new ArchievementSystem());
            RegisterModel<IGameModel>(new GameModel());
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}
