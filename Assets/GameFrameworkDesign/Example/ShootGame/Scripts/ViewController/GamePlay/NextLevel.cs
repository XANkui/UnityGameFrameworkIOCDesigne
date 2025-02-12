﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFrameworkDesign.Example.ShootGame { 

	public class NextLevel : BaseShootGameController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                SceneManager.LoadScene("GamePass");
            }
        }
    }
}
