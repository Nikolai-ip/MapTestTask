using Fabric;
using Model;
using View;

namespace Presenter
{
    public class DataStoragePresenter
    {
        private IPinDataStorage _dataStorage;
        private IPinContainer _pinContainer;
        private IPinFabric _pinFabric;
        public DataStoragePresenter(IPinDataStorage dataStorage, IPinContainer pinContainer, IPinFabric pinFabric,
            IButtonView saveButton)
        {
            _dataStorage = dataStorage;
            _pinContainer = pinContainer;
            _pinFabric = pinFabric;
            saveButton.OnClick += OnSaveClicked;
        }

        private void OnSaveClicked()
        {
            var pins = _pinContainer.GetPins();
            _dataStorage.Save(pins);
        }

        public void LoadPinsFromStorage()
        {
            var pinData = _dataStorage.Load();
            if (pinData != null && pinData.Count != 0 )
                _pinFabric.CreatePins(pinData);
        }
    }
}