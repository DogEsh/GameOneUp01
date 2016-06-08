using UnityEngine;
using System.Collections;

namespace SimpleTeam.GameOne.Scene
{
    public class WindowMenu : MonoBehaviour
    {
        public GameObject MyObject;
        public Case Login;
        public void Open()
        {
            //if (MyObject.activeSelf) return;
            MyObject.SetActive(true);
            Login.Close();
        }
        public void Close()
        {
            MyObject.SetActive(false);
        }
    }

}
