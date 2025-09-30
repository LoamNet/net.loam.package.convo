using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Loam.Convo
{
    public class ConvoBasicDialogUIOption : MonoBehaviour
    {
        public Button entryButton;
        public TextMeshProUGUI entryLabel;

        [HideInInspector] public int entryIndex = int.MaxValue;
    }
}