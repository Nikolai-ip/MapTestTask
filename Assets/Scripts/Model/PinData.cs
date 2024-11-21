using System;
using System.Numerics;

namespace Model
{
    [System.Serializable]

    public class PinData
    {
        public SerializableVector2 Position;
        public string Title;
        public string ShortInfo;
        public string Info;
        public int ID;
        public string ImagePath;
        public PinData(int id, Vector2 position)
        {
            ID = id;
            Position = position;
        }

        public PinData(int id, string title, string info, string shortInfo, string imagePath)
        {
            ID = id;
            Title = title;
            Info = info;
            ShortInfo = shortInfo;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{Title} pin: id: {ID}, position {Position} Title {Title} Image {ImagePath}";
        }
    }
}
