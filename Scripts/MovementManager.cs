using UnityEngine;

public class MovementManager : MonoBehaviour
{
    #region Protected fields
    protected Transform movingTransform;
    protected float moveSpeed;
    protected float moveDistance;

    private Vector3 startPosition;
    private float timeCounter;
    #endregion

    public virtual void Start()
    {
        startPosition = movingTransform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(timeCounter * moveSpeed) * moveDistance;
        movingTransform.position = startPosition + new Vector3(0, yOffset, 0);

        timeCounter += Time.deltaTime;
    }
}
