using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _container;

        private Object _hudObject;
        private GameObject _canvasObject;

        private Canvas _canvas;

        public UIFactory(DiContainer container) =>
            _container = container;

        public void Load()
        {
            _canvasObject = Resources.Load<GameObject>("Canvas");
            _hudObject = Resources.Load("Hud");
        }

        public void CreateCanvas()
        {
            _canvas = Object.Instantiate(_canvasObject).GetComponent<Canvas>();
        }

        public void CreateHud()
        {
            _container.InstantiatePrefab(_hudObject, _canvas.transform);
        }
    }
}
