using UnityEngine;

public class CanBeLiten : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LiteUp()
    {
        Debug.Log("Liten!");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
