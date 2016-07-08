using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    class LoadLevel1 : MonoBehaviour
    {
        public void Load()
        {
           
            SceneManager.LoadScene("Scene/MainScene");
        }
        public void Update()
        {

        }
        public void LoadNo()
        {
            SceneManager.LoadScene("Scene/MenuScene");
            //SceneManager.UnloadScene("MainScene");
        }
    }
}
