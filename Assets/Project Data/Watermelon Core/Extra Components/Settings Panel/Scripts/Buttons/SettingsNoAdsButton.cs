﻿using UnityEngine;

namespace Watermelon
{
    public class SettingsNoAdsButton : SettingsButtonBase
    {
        public override bool IsActive()
        {
#if MODULE_IAP
            return AdsManager.IsForcedAdEnabled();
#else
            return false;
#endif
        }

        public override void OnClick()
        {
            AudioController.PlaySound(AudioController.Sounds.buttonSound);

            settingsPanel.Hide(true);
            settingsPanel.InitPositions();
        }
    }
}

// -----------------
// Settings Panel v 0.3
// -----------------