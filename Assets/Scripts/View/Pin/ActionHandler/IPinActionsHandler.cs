using System;
using Model;
using UnityEngine;

namespace View
{
    public interface IPinActionsHandler
    {
        event Action<int> MoreInfoClicked;
        event Action<int> PinSelected;
        event Action<int, Vector2> PinPosChanged;
        event Action<PinData> PinDataChanged;
    }
}