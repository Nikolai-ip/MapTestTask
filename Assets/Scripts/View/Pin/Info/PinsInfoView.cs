using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;

namespace View
{
    public class PinsInfoView:MonoBehaviour, IPinInfoView, IPinViewContainer
    {
        private Dictionary<int, PinInfoController> _infoControllers = new();
        public void ShowShortInfo(PinData pinData)
        {
            Debug.Log("Show short info " + pinData);
            _infoControllers[pinData.ID].ShowShortInfo(pinData);
        }

        public void ShowFullInfo(PinData pinData)
        {
            Debug.Log("Show full info " + pinData);
            _infoControllers[pinData.ID].ShowFullInfo(pinData);
        }

        public void AddPin(PinView pinView)
        {
            Debug.Log("Add Pin" + pinView.ID);
            _infoControllers.Add(pinView.ID, pinView.GetComponent<PinInfoController>());
        }
    }
}