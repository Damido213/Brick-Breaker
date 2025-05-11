using UnityEngine;

public class Platform : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if(this.gameObject.transform.position.x < 7.2f)
            {
                this.gameObject.transform.position += new Vector3(6f, 0, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.x > -7.2f)
            { 
                this.gameObject.transform.position += new Vector3(-6f, 0, 0) * Time.deltaTime;
            }
        }
    }


}
