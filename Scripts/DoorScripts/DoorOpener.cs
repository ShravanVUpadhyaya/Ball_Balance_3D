using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
     public float openTime = 3f;
        public float openHeight = 7f;


        public void Door()
        {
            StartCoroutine(OpenTheDoorCoroutine());
        }


        IEnumerator OpenTheDoorCoroutine()
        {

            Vector3 initialPosition = transform.position;
            Vector3 targetPosition = transform.position + transform.right * openHeight;

            float elapsedTime = 0f;
            while (elapsedTime < openTime)
            {
                transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / openTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the door reaches the exact open position
            transform.position = targetPosition;
        }
}
