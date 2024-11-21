using System;
using Model;
using UnityEngine;

namespace View
{
    public class PinsInfoActionsHandler:MonoBehaviour, IPinActionsHandler
    {
        public event Action<int> MoreInfoClicked;
        public event Action<int> PinSelected;
        public event Action<int, Vector2> PinPosChanged;
        public event Action<PinData> PinDataChanged;

        public void OnPinSelected(int pinID)
        {
            PinSelected?.Invoke(pinID);
        }

        public void OnMoreInfoClicked(int pinID)
        {
            MoreInfoClicked?.Invoke(pinID);
        }

        public void OnPinPositionChanged(int pinID, Vector2 newPos)
        {
            PinPosChanged?.Invoke(pinID,newPos);
        }

        public void OnPinDataEdit(PinData pinData)
        {
            PinDataChanged?.Invoke(pinData);
        }
    }
}