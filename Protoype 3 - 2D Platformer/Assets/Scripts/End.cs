using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add the Scoremanagement Namespace

public class End : MonoBehaviour
{
        public bool finalLevel;

        public string nextLevelName;


        private void OnTriggerEnter2D (Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                //If This is the final level, go to menu.
                if(finalLevel == true)
                {
                    SceneManager.LoadScene(0);
                }

                //Otherwise load up the next level.
                else
                {
                    SceneManager.LoadScene(nextLevelName);
                }
            }
        }


}
