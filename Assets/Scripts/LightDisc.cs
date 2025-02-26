using UnityEngine;

public class LightDisc : MonoBehaviour
{
    [SerializeField] private GameObject[] lightBeams;
    [SerializeField] private Transform centerTransform;

    // Update is called once per frame
    void Update()
    {
        if (transform.position != centerTransform.position)
        {
            for (int i = 0; i < lightBeams.Length; i++)
            {
                lightBeams[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < lightBeams.Length; i++)
            {
                lightBeams[i].SetActive(true);
            }
        }
    }
}
