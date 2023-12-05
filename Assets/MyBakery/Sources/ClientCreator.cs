using UnityEngine;
using Virvon.MyBakery.DependencyInjection.Factories;
using Zenject;

public class ClientCreator : MonoBehaviour
{
    private IClientFactory _clientFactory;

    [Inject]
    public void Construct(IClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public void Create()
    {
        _clientFactory.Create();
    }
}
