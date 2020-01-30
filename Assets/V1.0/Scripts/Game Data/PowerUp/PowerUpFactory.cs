using System;
using System.Collections.Generic;


namespace Kentro
{
    public class PowerUpFactory
    {
        private Dictionary<IPowerUp,int> dic;
        private Dictionary<int, IPowerUp> track;
        private IPowerUp pBlock,pChangeNumber,pFreeze,pNone,pShow,pSwap,pShuffleAll;
        public Stack<IPowerUp> ListPowerUps;
        public PowerUpFactory()
        {
            assign();
            ListPowerUps = new Stack<IPowerUp>();
        }

        public void GetPowerUp()
        {
            Random random = new Random();
            int RandomValue = random.Next(1,7);

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


        public void assign()
        {
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



    }
}
