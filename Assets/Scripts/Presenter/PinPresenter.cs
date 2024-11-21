using Model;
using UnityEngine;
using View;

namespace Presenter
{
    public class PinPresenter
    {
        private IPinContainer _pinContainer;
        private IPinInfoView _pinInfoView;
        private IPinActionsHandler _view;


        public PinPresenter(IPinContainer pinContainer, IPinInfoView pinInfoView, IPinActionsHandler view)
        {
            _view = view;
            _view.PinSelected += OnPinSelected;
            _view.MoreInfoClicked += OnMoreInfoClicked;
            _view.PinPosChanged += OnPinPosChanged;
            _view.PinDataChanged += OnPinDataChanged;
            _view.PinDeleted += OnPinDeleted;
            _pinContainer = pinContainer;
            _pinInfoView = pinInfoView;
        }

        private void OnPinDataChanged(PinData pinData)
        {
            var pin = _pinContainer.GetPin(pinData.ID);
            if (pinData.Info != null && pin.Info != pinData.Info) pin.Info = pinData.Info;
            if (pinData.ShortInfo != null  && pin.ShortInfo != pinData.ShortInfo) pin.ShortInfo = pinData.ShortInfo;
            if (pinData.Title != null && pin.Title != pinData.Title) pin.Title = pinData.Title;
            if (pinData.ImagePath != null && pin.ImagePath != pinData.ImagePath) pin.ImagePath = pinData.ImagePath;
        }

        private void OnPinDeleted(int pinID)
        {
            _pinContainer.DeletePin(pinID);
        }
        private void OnPinPosChanged(int pinID, Vector2 position)
        {
            var pin = _pinContainer.GetPin(pinID);
            pin.Position.x = position.x;
            pin.Position.y = position.y;
        }

        private void OnPinSelected(int pinID)
        {
            PinData pinData = _pinContainer.GetPin(pinID);
            _pinInfoView.ShowShortInfo(pinData);
        }

        private void OnMoreInfoClicked(int pinID)
        {
            PinData pinData = _pinContainer.GetPin(pinID);
            _pinInfoView.ShowFullInfo(pinData);
        }


    }
}