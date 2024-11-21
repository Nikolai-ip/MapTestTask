using Infrastructure;
using UnityEngine;

namespace View.Container
{
    public class PinPool:MonoBehaviour,IPinPool
    {
        private PoolMono<PinView> _pins;
        [SerializeField] private int _capacity;
        [SerializeField] private bool _autoExpand;
        
        public void Init()
        {
            _pins = new PoolMono<PinView>(Resources.Load<PinView>(AssetPath.PinPath), _capacity,transform)
            {
                AutoExpand = _autoExpand
            };
            // foreach (var pin in _pins)
            // {
            //     pin.Init();
            // }
        }

        public PinView GetFreePin()
        {
            return _pins.GetFreeElement();
        }
    }
}