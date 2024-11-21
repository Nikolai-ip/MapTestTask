using System;
using UnityEngine;

namespace View
{
    public interface IFieldActionsHandler
    {
        event Action<Vector2> FieldClicked;
    }
}