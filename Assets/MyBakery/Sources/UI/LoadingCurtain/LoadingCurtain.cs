﻿using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.UI
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<string, UniTask<LoadingCurtain>>
        {

        }
    }
}
