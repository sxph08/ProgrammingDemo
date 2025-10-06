using UnityEngine;

public class whatdoIdoP2 : MonoBehaviour
{
    public Light targetLight; 
    public string playerTag = "Player"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (targetLight != null)
            {
                targetLight.enabled = false;
            }
            Debug.Log("nolight");
        }
    }
}