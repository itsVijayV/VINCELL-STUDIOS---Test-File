using UnityEngine;

public class OuterDisk : MonoBehaviour
{
    [SerializeField] GameObject thisDisk;
    [SerializeField] Transform centerPoint;
    [SerializeField] GameObject[] normalLight;
    [SerializeField] GameObject[] lightBeam;
    [SerializeField] Transform lightActivatePoint;

    private void Start()
    {
        for (int i = 0; i < lightBeam.Length; i++)
        {
            lightBeam[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (lightActivatePoint.transform.position == thisDisk.transform.position)
        {
            for (int i = 0; i < lightBeam.Length; i++)
            {
                lightBeam[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < lightBeam.Length; i++)
            {
                lightBeam[i].SetActive(false);
            }
        }

        for (int i = 0; i < normalLight.Length; i++)
        {
            if (thisDisk.transform.position == centerPoint.position || lightActivatePoint.position == thisDisk.transform.position)
            {
                normalLight[i].gameObject.SetActive(false);
                /*lightBeam[i].gameObject.SetActive(false);*/
            }
            else
            {
                normalLight[i].gameObject.SetActive(true);
            }
        }
        
    }
}
