using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameworkDesign.Example { 

	public class UI : MonoBehaviour, IController
    {
        void Start()
        {
            this.RegisterEvent<OnGamePass>(OnGamePass);
            this.RegisterEvent<OnCountDownEndEvent>(e =>
            {
                transform.Find("Canvas/GamePanel").gameObject.SetActive(false);
                transform.Find("Canvas/GameOverPanel").gameObject.SetActive(true);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnGamePass(OnGamePass e)
        {
            Debug.Log("UI/OnGamePass");
            transform.Find("Canvas/GamePanel").gameObject.SetActive(false);
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            this.UnRegisterEvent<OnGamePass>(OnGamePass);
        }

        public IArchitecture GetArchitecture()
        {
            return ClickClickClickArchitecture.Interface;
        }
    }
}
