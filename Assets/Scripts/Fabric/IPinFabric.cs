using System;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Fabric
{
    public interface IPinFabric
    {
        void CreatePin(Vector2 pos);
        void CreatePins(List<PinData> pinData);
    }
}