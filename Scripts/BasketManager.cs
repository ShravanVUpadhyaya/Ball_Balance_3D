using UnityEngine;

public class BasketManager : MovementManager
{
    [SerializeField] private Transform basketPrefab;
    private float basketMoveSpeed = 1f;
    private float basketMoveDistance = 1f;

    public override void Start()
    {
        movingTransform = basketPrefab;
        moveSpeed = basketMoveSpeed;
        moveDistance = basketMoveDistance;
        base.Start();
    }
}
