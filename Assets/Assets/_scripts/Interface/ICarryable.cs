using UnityEngine;

public interface ICarryable
{
    void Take(Transform player, Vector2 offset, float followSpeed, float duration);
    void Release();
    bool IsCarrying();
    bool CanCarry();

    Transform GetTransform(); // Adicionamos para acessar a posição sem depender de variáveis diretas
}
