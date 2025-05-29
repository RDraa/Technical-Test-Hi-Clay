using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform characterPosition;
    public GameObject characterObject;

    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 maxValue, minValue;

    void LateUpdate()
    {

        if (characterPosition == null)
        {
            Debug.Log("character Position Kosong");
            return;
        }
        FollowTarget(characterPosition);
    }

    void FollowTarget(Transform target)
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
