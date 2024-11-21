using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class PinContainer:IPinContainer
    {
        private List<PinData> _pinData = new();

        private List<PinData> PinData
        {
            get => _pinData;
            set
            {
                _pinData = value; 
                PinDataChanged?.Invoke(_pinData);
            } 
        }

        public event Action<IEnumerable<PinData>> PinDataChanged;

        public PinData GetPin(int pinID)
        {
            return _pinData.Find(pin => pin.ID == pinID);
        }

        public void AddPin(PinData pinData)
        {
            _pinData.Add(pinData);
            // Debug.ClearDeveloperConsole();
            // foreach (var pin in _pinData)
            // {
            //     Debug.Log(pin);
            // }
        }

        public int GetFreeID()
        {
            if (_pinData.Count == 0)
                return 0;
            int id = _pinData.OrderBy(pin => pin.ID).Last().ID + 1;
            return id;
        }

        public List<PinData> GetPins()
        {
            return _pinData;
        }
    }
}