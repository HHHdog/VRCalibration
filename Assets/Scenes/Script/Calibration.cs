using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    public Transform RightHand;
    public Transform LeftHand;
    public Transform Standard;
    Vector3 centre;
    Vector3 origin = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            calibrate();
        }
    }


    void calibrate()
    {
        
        Vector3 slide1 = RightHand.position - LeftHand.position;
        Vector3 slide2 = new Vector3(0, 1, 0);
        Vector3 normal = Vector3.Cross(slide1, slide2);
        Vector3 standard = new Vector3(0, 0, 1);
        float Dot = Vector3.Dot(normal, standard);
        float a = Vector3.Magnitude(normal);
        float b = Vector3.Magnitude(standard);
        float cos = Dot / (a * b);
        float nn = Mathf.Sign(Vector3.Dot(normal, slide2));
        float h = Mathf.Acos(cos);//通过Acos函数可通过余弦值计算出对应弧度
        var d = (h *= Mathf.Rad2Deg);//弧度转度。这里得到的始终为正值
        if (nn > 0)
        {
            transform.RotateAround(origin, Vector3.up, d);
        }
        else
        {
            transform.RotateAround(origin, Vector3.up, -d);
        }
        

        transform.rotation = Standard.rotation;

        centre = (RightHand.position + LeftHand.position) / 2;
    }
}
