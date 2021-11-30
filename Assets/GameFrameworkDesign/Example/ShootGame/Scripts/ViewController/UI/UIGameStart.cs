using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class UIGameStart : MonoBehaviour
	{
        private Button mStartButton;

        private void Awake()
        {
            mStartButton = transform.Find("Canvas/StartButton").GetComponent<Button>();
            mStartButton.onClick.AddListener(() => {
                SceneManager.LoadScene("ShootGame");
            });
        }


       
    }
}
