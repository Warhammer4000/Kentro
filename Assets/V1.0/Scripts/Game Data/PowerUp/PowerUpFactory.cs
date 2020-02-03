using System;
using System.Collections.Generic;
using UnityEngine;


namespace Kentro
{
    public class PowerUpFactory : MonoBehaviour
    {
        public static PowerUpFactory Instance { get; set; }
        
        private Dictionary<IPowerUp,int> dic;
        private Dictionary<int, IPowerUp> track;
        private IPowerUp pBlock,pChangeNumber,pFreeze,pNone,pShow,pSwap,pShuffleAll;
        public Stack<IPowerUp> ListPowerUps;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                assign();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start()
        {
            
            InvokeRepeating("GetPowerUp", 20.0f, 30.0f);
        }

        


        public void GetPowerUp()
        {

            System.Random random = new System.Random();
            int RandomValue = random.Next(1,8);

            if (dic[track[RandomValue]] != 0)
            {
                dic[track[RandomValue]] -= 1;
                ListPowerUps.Push(track[RandomValue]);
            }
            else
            {
                ListPowerUps.Push(new PNone());
            }

        }



        #region Assign Method


        public void assign()
        {
            ListPowerUps = new Stack<IPowerUp>();
            dic = new Dictionary<IPowerUp, int>();
            track = new Dictionary<int, IPowerUp>();
            pBlock = new PBlock();
            pChangeNumber = new PChangeNumber();
            pFreeze = new PFreeze();
            pNone = new PNone();
            pShow = new PShow();
            pSwap = new PSwap();
            pShuffleAll = new PShuffleAll();
            dic.Add(pBlock, 2);
            dic.Add(pChangeNumber, 2);
            dic.Add(pFreeze, 2);
            dic.Add(pNone, 2);
            dic.Add(pShow, 2);
            dic.Add(pSwap, 2);
            dic.Add(pShuffleAll, 2);

            track.Add(pBlock.getProbability(), pBlock);
            track.Add(pChangeNumber.getProbability(), pChangeNumber);
            track.Add(pFreeze.getProbability(), pFreeze);
            track.Add(pNone.getProbability(), pNone);
            track.Add(pShow.getProbability(), pShow);
            track.Add(pSwap.getProbability(), pSwap);
            track.Add(pShuffleAll.getProbability(), pShuffleAll);

            
        }

        #endregion


    }
}
