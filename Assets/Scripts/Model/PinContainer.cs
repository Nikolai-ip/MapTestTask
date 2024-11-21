using System;
using System.Collections.Generic;
using System.Linq;


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
        }

        public int GetFreeID()
        {
            if (_pinData.Count == 0)
                return 0;
            int id = _pinData.OrderBy(pin => pin.ID).Last().ID + 1;
            return id;
        }

        public void DeletePin(int pinID)
        {
            _pinData.Remove(_pinData.Find(pinData => pinData.ID == pinID));
        }

        public List<PinData> GetPins()
        {
            return _pinData;
        }
    }
}