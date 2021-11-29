using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class ClickClickClickArchitecture : Architecture<ClickClickClickArchitecture>
	{

        protected override void Init()
        {
            RegisterSystem<IArchievementSystem>(new ArchievementSystem());
            RegisterModel<IGameModel>(new GameModel());
        }
    }
}
