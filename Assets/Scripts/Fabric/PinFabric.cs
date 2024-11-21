using System.Collections.Generic;
using Model;
using UnityEngine;
using View;
using View.Container;

namespace Fabric
{
    public class PinFabric:IPinFabric
    {
        private IPinContainer _pinContainer;
        private IPinPool _pinPool;
        private IPinViewContainer _pinViewContainer;
        public PinFabric(IPinContainer pinContainer, IPinPool pinPool, IPinViewContainer pinViewContainer)
        {
            _pinContainer = pinContainer;
            _pinPool = pinPool;
            _pinViewContainer = pinViewContainer;
        }

        public void CreatePin(Vector2 screenPosition)
        {
            var pinData = new PinData(_pinContainer.GetFreeID(),new System.Numerics.Vector2(screenPosition.x,screenPosition.y));
            InstantiatePin(pinData);
        }

        public void CreatePins(List<PinData> pinData)
        {
            foreach (var pin in pinData)
            {
                InstantiatePin(pin);
            }
        }

        private void InstantiatePin(PinData pin)
        {
            _pinContainer.AddPin(pin);
            var pinObj = _pinPool.GetFreePin();
            var pinView = pinObj.GetComponent<PinView>();
            pinView.SetData(pin);
            _pinViewContainer.AddPin(pinView);
        }
    }
}