using UnityEngine;

public class VirtualCamaraTrigger : MonoBehaviour
{
    public VirtualCamaraManager virtualCamaraManager;
    public int camaraToSwith; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            virtualCamaraManager.SwitchCamara(camaraToSwith);
        }
    }
}
