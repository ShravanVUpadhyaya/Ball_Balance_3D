using UnityEngine;

public class ObstacleManager : MovementManager
{
    [SerializeField] private Transform obstaclePrefab;
    private float obstacletMoveSpeed = 1.3f;
    private float obstacleMoveDistance = 2f;

    public override void Start()
    {
        movingTransform = obstaclePrefab;
        moveSpeed = obstacletMoveSpeed;
        moveDistance = obstacleMoveDistance;
        base.Start();
    }
}
