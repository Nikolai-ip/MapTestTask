using System;
using System.Numerics;

namespace Model
{
    [Serializable]
    public struct SerializableVector2
    {
        public float x;
        public float y;

        public SerializableVector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator Vector2(SerializableVector2 sVector)
        {
            return new Vector2(sVector.x, sVector.y);
        }

        public static implicit operator SerializableVector2(Vector2 vector)
        {
            return new SerializableVector2(vector.X, vector.Y);
        }
    }
}