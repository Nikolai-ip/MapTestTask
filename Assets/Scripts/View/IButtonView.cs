using System;

namespace View
{
    public interface IButtonView
    {
        event Action OnClick;
    }
}