using UnityEngine;

public class ContinuousSwipeMovement : MonoBehaviour
{
    public float speed = 5f;
    public float swipeRange = 50f;
    public float laneWidth = 4f;
    public float interpolationSpeed = 10f;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private bool stopTouch = false;
    private int currentLane = 0;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    stopTouch = false;
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    if (!stopTouch)
                    {
                        currentTouchPosition = touch.position;
                        Vector2 distance = currentTouchPosition - startTouchPosition;

                        if (distance.x < -swipeRange)
                        {
                            // Swipe Left
                            MoveLane(-1);
                            startTouchPosition = currentTouchPosition;
                        }
                        else if (distance.x > swipeRange)
                        {
                            // Swipe Right
                            MoveLane(1);
                            startTouchPosition = currentTouchPosition;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    stopTouch = true;
                    break;
            }
        }
        Vector3 targetPosition = new Vector3(currentLane * laneWidth, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, interpolationSpeed * Time.deltaTime);
    }

    private void MoveLane(int direction)
    {
        currentLane += direction;
        currentLane = Mathf.Clamp(currentLane, -2, 2);
    }
}
