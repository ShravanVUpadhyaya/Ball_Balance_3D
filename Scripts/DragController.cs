using UnityEngine;
using UnityEngine.UI;

public class DragController : MonoBehaviour
{
    #region [SerializeField] private fields
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LineRenderer trajectoryRenderer;
    [SerializeField] private float dragLimit = 3f;
    [SerializeField] private float forceToAdd = 5f;
    [SerializeField] private float step;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float totalTime = 10;
    [SerializeField] private Canvas gameEndCanvas;
    [SerializeField] private Canvas levelCompletedCanvas;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Collider2D ballCollider;
    [SerializeField] private WinRatingsManager winRatingsManager;
    #endregion


    #region Public Fields
    public int throwCount = 3;
    #endregion


    #region Private Fields
    Camera cam;
    bool isDragging = false;
    #endregion


    Vector3 MousePosition
    {
        get
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            return pos;
        }
    }


    #region Unity Methods
    void Start()
    {
        cam = Camera.main;
        gameEndCanvas.enabled = false;
        levelCompletedCanvas.enabled = false;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Vector2.zero);
        lineRenderer.SetPosition(1, Vector2.zero);
        lineRenderer.enabled = false;
        trajectoryRenderer.enabled = false;
    }

    void Update()
    {
        if (throwCount > 0)
        {
            if (isDragging)
            {
                DrawPath();
                Drag();
            }
            else
            {
                trajectoryRenderer.enabled = false;
            }

            if (Input.GetMouseButtonDown(0) && !isDragging)
            {
                if (IsMouseOverBall())
                {
                    DragStart();
                }
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                DragEnd();
                throwCount--;
                hearts[throwCount].enabled = false;
            }
        }
        else
        {
            Invoke(nameof(Delay), 8f);
        }
    }

    bool IsMouseOverBall()
    {
        Vector2 mousePos = MousePosition;
        return ballCollider.OverlapPoint(mousePos);
    }

    void DragStart()
    {
        lineRenderer.enabled = true;
        trajectoryRenderer.enabled = true;
        isDragging = true;
        lineRenderer.SetPosition(0, MousePosition);
    }

    void Drag()
    {
        Vector3 startPosition = lineRenderer.GetPosition(0);
        Vector3 currentPosition = MousePosition;
        Vector3 distance = currentPosition - startPosition;
        if (distance.magnitude > dragLimit)
        {
            lineRenderer.SetPosition(1, startPosition + (distance.normalized * dragLimit));
        }
        else
        {
            lineRenderer.SetPosition(1, currentPosition);
        }
    }

    void DragEnd()
    {
        isDragging = false;
        lineRenderer.enabled = false;
        trajectoryRenderer.enabled = false;

        Vector3 startPosition = lineRenderer.GetPosition(0);
        Vector3 endPosition = lineRenderer.GetPosition(1);
        Vector3 distance = endPosition - startPosition;
        Vector2 finalForce = -distance * forceToAdd;

        rigidBody.AddForce(finalForce, ForceMode2D.Impulse);

        winRatingsManager.WinRatings(throwCount);
    }

    void DrawPath()
    {
        trajectoryRenderer.positionCount = 0;

        Vector3 startPosition = lineRenderer.GetPosition(0);
        Vector3 endPosition = lineRenderer.GetPosition(1);
        Vector3 forceVector = endPosition - startPosition;
        Vector2 initialVelocity = -forceVector * forceToAdd;

        //float angle = Mathf.Atan2(initialVelocity.y, initialVelocity.x);
        step = Mathf.Max(0.01f, step);
        trajectoryRenderer.positionCount = (int)(totalTime / step) + 1;
        int count = 0;

        for (float time = 0; time < totalTime; time += step)
        {
            float x = initialVelocity.x * time;
            float y = initialVelocity.y * time - 0.5f * -Physics.gravity.y * time * time;
            trajectoryRenderer.SetPosition(count, shootPoint.position + new Vector3(x, y, 0));
            count++;
        }

        float xFinal = initialVelocity.x * totalTime;
        float yFinal = initialVelocity.y * totalTime - 0.5f * -Physics.gravity.y * totalTime * totalTime;
        trajectoryRenderer.SetPosition(count, shootPoint.position + new Vector3(xFinal, yFinal, 0));
    }

    void Delay()
    {
        if (levelCompletedCanvas.enabled == false)
        {
            gameEndCanvas.enabled = true;
        }
    }
    #endregion


}
