using Fabric;
using UnityEngine;
using View;

namespace Presenter
{
    public class PinPlacementPresenter                                  
    {
        private IFieldActionsHandler _fieldActionsHandler;
        private IPinFabric _pinFabric;

        public PinPlacementPresenter(IFieldActionsHandler fieldActionsHandler, IPinFabric pinFabric)
        {
            _fieldActionsHandler = fieldActionsHandler;
            _fieldActionsHandler.FieldClicked += OnFieldClick;
            _pinFabric = pinFabric;

        }
        private void OnFieldClick(Vector2 pointPos)
        {
            _pinFabric.CreatePin(pointPos);
        }
    }
}