using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate() {
      // GameObject worm = GameObject.Find("worm");
    // target = worm.transform.Find("muscle/muscle 18");
    Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.y = 77;
     //   Vector3 rot = new Vector3(90, 90, 0);
        transform.position = smoothedPosition;

      // transform.LookAt(target);
    }
}
