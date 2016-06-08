using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SimpleTeam.GameOne.Message;
using SimpleTeam.GameOne.GameInfo;

namespace SimpleTeam.GameOne.Scene
{
    public class GameMapOld : MonoBehaviour
    {
        private ArrayList _simplusContainer = new ArrayList();

        private ArrayList _mapInitInfo;

        //send it somewhere else
        
        private GameObject _simplusRedPrefab;
        private const string _pathSimplusRed = "Game/SimplusRedPrefab";
         public void Start()
        {
            //CreateMapObjects();

            //tmp
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Simplus");
            foreach (GameObject obj in objects)
            {
                SimplusOld simpl = obj.GetComponent<SimplusOld>();
                _simplusContainer.Add(simpl);
            }
            _simplusRedPrefab = Resources.Load<GameObject>(_pathSimplusRed);
        }

        public void CreateMapObjects()
        {
            if (null != _mapInitInfo)
            {
                foreach (SimplusInfo simpInf in _mapInitInfo)
                {
                    CreateSimplus(simpInf);
                }
            }
            else
            {
                throw new System.Exception("empty init info");
            }
        }

        public void CreateSimplus(SimplusInfo info)
        {
            //depending on info we choose one of prefabs

            //assume we choosed red one
            GameObject go = Instantiate(_simplusRedPrefab);
            SimplusOld simp = go.GetComponent<SimplusOld>();
            go.name = "Simplus_" + info.Party.ID.ToString();

            simp.InitInfo(info);

            _simplusContainer.Add(simp);
        }

        public SimplusOld GetFocusedSimplus(Vector2 pos)
        {
            foreach (SimplusOld wrap in _simplusContainer)
            {
                if (wrap._wrapper.IsFocused(pos))
                    return wrap;
            }
            return null;
        }
        //GJ
        public void SetInitMapInfo()//InitMapInfo info)
        {
            //_mapInitInfo = info;
            //foreach(SimplusInfo simpInf in info.SimplusInfo)
            //{
            //    //create simplus
            //    var GO = new GameObject("Simplus_" + simpInf.Party.ID.ToString());
            //    //GO
            //    //set parameter
            //}
            ////Simplus testSimp = new Simplus();
            
        }
        //GJ
        public void UpdateMap()//UpdateMapInfo info)
        {

        }

        public SimplusOld GetSimplus(int ID)
        {
            foreach(SimplusOld smpl in _simplusContainer)
            {
                if (smpl.Info.ID == ID)
                    return smpl;
            }
            return null;
        }
    }
}
