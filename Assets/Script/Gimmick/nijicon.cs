using UnityEngine;

public class nijicon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + 0.1f, this.transform.position.y, 0);

        if(this.transform.position.x >= -53.99f)
        {
            this.transform.position = new Vector3(this.transform.position.x - 24.00f, this.transform.position.y, 0);
        }
    }
}
