using UnityEngine;
using System;
using Space.Objects.Stations;

public class ButtonAction : MonoBehaviour, IInteractable
{
    private DeliveryStation deliveryStation;

    private void Awake()
    {
        deliveryStation = GetComponentInParent<DeliveryStation>();
    }

    public void Interact()
    {
        deliveryStation.Execute();

    }


}