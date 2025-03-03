
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Watermelon.IAPStore
{
    public class PowerUpsOffer
    {
        [SerializeField] List<PowerUpDeal> powerUps;

        protected  void Awake()
        {

#if MODULE_POWERUPS
            for (int i = 0; i < powerUps.Count; i++)
            {
                PowerUpDeal data = powerUps[i];
                if(EnumUtils.IsEnumValid(data.type))
                {
                    data.text.text = $"x{data.amount}";
                }
                else
                {
                    Debug.LogError("[IAP Store]: Power Ups offer contains unknown type!");
                }
            }
#endif
        }

        protected void ApplyOffer()
        {
#if MODULE_POWERUPS
            for (int i = 0; i < powerUps.Count; i++)
            {
                var data = powerUps[i];

                PUController.AddPowerUp(data.type, data.amount);
            }
#endif
        }

        protected void ReapplyOffer()
        {
            
        }

        [System.Serializable]
        private class PowerUpDeal
        {
            public TMP_Text text;

#if MODULE_POWERUPS
            public PUType type;
#endif

            public int amount;
        }
    }
}