using System;
using System.Collections.Generic;

namespace Model
{
    public interface IPinContainer
    {
        event Action<IEnumerable<PinData>> PinDataChanged;
        PinData GetPin(int pinID);
        void AddPin(PinData pinData);
        int GetFreeID();

        List<PinData> GetPins();
    }
}