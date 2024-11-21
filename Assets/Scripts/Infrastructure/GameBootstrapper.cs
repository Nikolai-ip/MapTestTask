using Fabric;
using Model;
using Presenter;
using UnityEngine;
using View;
using View.Container;

namespace Infrastructure
{
    public class GameBootstrapper:MonoBehaviour
    {
        [Header("View")]
        [SerializeField] private FieldActionsHandler _fieldActionsHandler;
        [SerializeField] private PinPool _pinPool;
        [SerializeField] private PinsInfoView _pinsInfoView;
        [SerializeField] private PinsInfoActionsHandler _infoActionsHandler;
        [SerializeField] private ButtonView _saveButton;
        private void Awake()
        {
            _pinPool.Init();
            var pinContainer = new PinContainer();
            var pinFabric = new PinFabric(pinContainer,_pinPool,_pinsInfoView);
            var pinPlacementPresenter= new PinPlacementPresenter(_fieldActionsHandler, pinFabric);
            var dataStorage = new DataStorage();
            var pinInfoPresenter = new PinInfoPresenter(pinContainer, _pinsInfoView, _infoActionsHandler);
            var dataStoragePresenter = new DataStoragePresenter(dataStorage, pinContainer, pinFabric, _saveButton);
            dataStoragePresenter.LoadPinsFromStorage();
        }
    }
}