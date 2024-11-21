using System.Collections.Generic;

namespace Model
{
    public interface IPinDataStorage
    {
        List<PinData> Load();
        void Save(List<PinData> pins);                                                           
    }
}