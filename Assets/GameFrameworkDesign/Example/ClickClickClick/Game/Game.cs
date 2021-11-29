using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example
{ 

	public class Game : MonoBehaviour, IController
    {
        void Start()
        {
            this.RegisterEvent<OnGameStart>(OnGameStart);

            this.RegisterEvent<OnCountDownEndEvent>(e => { transform.Find("Enemies").gameObject.SetActive(false); })
                .UnRegisterWhenGameObjectDestroyed(gameObject);

            this.RegisterEvent<OnGamePass>(e => { transform.Find("Enemies").gameObject.SetActive(false); })
                .UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnGameStart(OnGameStart e)
        {
            var enemyRoot = transform.Find("Enemies");

            enemyRoot.gameObject.SetActive(true);

            foreach (Transform childTrans in enemyRoot)
            {
                childTrans.gameObject.SetActive(true);
            }
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<OnGameStart>(OnGameStart);
        }

        public IArchitecture GetArchitecture()
        {
            return ClickClickClickArchitecture.Interface;
        }
    }
}
