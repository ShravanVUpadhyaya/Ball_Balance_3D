using UnityEngine;
using UnityEngine.UI;

public class WinRatingsManager : MonoBehaviour
{
    [SerializeField] private Image[] stars;

    public void WinRatings(int throwsRemaining)
    {
        throwsRemaining = Mathf.Clamp(throwsRemaining, 0, stars.Length);

        for (int i = 0; i < stars.Length; i++)
        {
            if (i < stars.Length - throwsRemaining)
            {
                stars[i].enabled = false;
            }
            else
            {
                stars[i].enabled = true;
            }
        }
    }
}
