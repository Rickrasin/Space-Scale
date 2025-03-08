using UnityEngine;
using System;
using Space.Objects.Stations;
using Space.Managers;
using static Space.Managers.GameManager;

public class PanelAction : MonoBehaviour, IInteractable
{
    private DeliveryStation deliveryStation;

    private void Awake()
    {
        deliveryStation = GetComponentInParent<DeliveryStation>();
    }

    public void Interact()
    {


        EventManager.TriggerEvent<GameState>(EventKey.ChangeGameEvent, GameState.SelectRecipe);

    }


}