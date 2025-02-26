using System.Collections;
using UnityEngine;

public class DiscMoveLogic : MonoBehaviour
{

    // GameObjects Refrencess
    [SerializeField] private GameObject[] allDiscGameObjects;
    [SerializeField] private Transform startingPosition;
    [SerializeField] private Transform centerPosition;
    [SerializeField] private Transform EndingPosition;

    // Moving Disc 
    GameObject startingDisc;
    GameObject centerDisc;
    GameObject endingDisc;
    // Move and Rotation Variables
    [SerializeField] private float moveDuration = 1.5f;
    [SerializeField] private float rotationDegree = 60f;
    [SerializeField] private bool isMoving = false;

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            StartCoroutine(AllDiscSwap());
        }
    }

    IEnumerator AllDiscSwap()
    {
        for (int i = 0; i < allDiscGameObjects.Length; i++)
        {
            if (allDiscGameObjects[i].transform.position == startingPosition.position)
            {
                startingDisc  = allDiscGameObjects[i];
            }
            if (allDiscGameObjects[i].transform.position == centerPosition.position)
            {
                centerDisc = allDiscGameObjects[i];
            }
            if (allDiscGameObjects[i].transform.position == EndingPosition.position)
            {
                endingDisc = allDiscGameObjects[i];
            }
        }

        isMoving = true;
        float elapsedTime = 0;

        // Mirror Disc Rotate
        Quaternion startingRotation = transform.rotation;
        Quaternion targetRotation = startingRotation * Quaternion.Euler(0,0, rotationDegree);

        // Starting and Ending Position
        Transform startingpos = startingPosition;
        Transform centerPos = centerPosition;
        Transform endPos = EndingPosition;

        Transform startingTargetpos = centerPos;
        Transform centerTargetPos = endPos;
        Transform endTargetPos = startingpos;

        while (elapsedTime < moveDuration)
        {
            float smoothTransition = Mathf.SmoothStep(0, 1, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;

            startingDisc.transform.position = Vector3.Lerp(startingpos.position, startingTargetpos.transform.position, smoothTransition);
            centerDisc.transform.position = Vector3.Lerp(centerPos.position, centerTargetPos.transform.position, smoothTransition);
            endingDisc.transform.position = Vector3.Lerp(endPos.position, endTargetPos.transform.position, smoothTransition);

            transform.rotation = Quaternion.Lerp(startingRotation, targetRotation, smoothTransition);

            yield return null;
        }

        //assign destination
        startingDisc.transform.position = startingTargetpos.position;
        centerDisc.transform.position = centerTargetPos.position;
        endingDisc.transform.position = endTargetPos.position;

        //assign Rotation
        transform.rotation = targetRotation;

        isMoving = false;
    }
}
