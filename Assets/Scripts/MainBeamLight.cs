using UnityEngine;

public class MainBeamLight : MonoBehaviour
{
    public GameObject Glow1, Beam1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Mirrordisc"))
        {
            Glow1.SetActive(false);
            Beam1.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Mirrordisc"))
        {
            Glow1.SetActive(true);
            Beam1.SetActive(false);
        }
    }
}