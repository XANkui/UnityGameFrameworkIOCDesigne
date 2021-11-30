using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MadGazeSlamDemo { 

	public class NextLevel : MonoBehaviour
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
