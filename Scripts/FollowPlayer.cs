using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 50, 25);

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);

        if (transition > 1.0f)
        {
            transform.position = smoothedPosition;
        }
        else
        {
            //Animation
            transform.position = Vector3.Lerp(smoothedPosition + animationOffset, smoothedPosition, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            
   

        }
        

  
    }
}
