using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class UIGamePass : MonoBehaviour
	{
        private Button mBackButton;

        private void Awake()
        {
            mBackButton = transform.Find("Canvas/BackButton").GetComponent<Button>();
            mBackButton.onClick.AddListener(() => {
                SceneManager.LoadScene("GameStart");
            });
        }
        

       
    }
}
