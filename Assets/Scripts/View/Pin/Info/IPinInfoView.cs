using Model;

namespace View
{
    public interface IPinInfoView
    {
        void ShowShortInfo(PinData pinData);
        void ShowFullInfo(PinData pinData);

    }

    public interface IPinViewContainer
    {
        void AddPin(PinView pinView);
    }
}