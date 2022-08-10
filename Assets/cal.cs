using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cal : MonoBehaviour
{
    public bool positive=true;
    public Transform RightHand;
    public Transform LeftHand;
    Vector3 centre;    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            positive = !positive;
        }



            if (Input.GetKeyDown(KeyCode.Y))
        {
            if (positive)
            {
                Debug.Log("pos");
                calibrate1();

            }
            else
            {
                Debug.Log("nopos");

                calibrate2();

            }
        }
    }


    void calibrate1()
    {

        //计算当前面朝方向向量
        Vector3 slide1 = RightHand.position - LeftHand.position;

        Vector3 normal = Vector3.Cross(slide1, Vector3.up);

        //计算当前面朝方向于目标面朝方向向量夹角
        float Dot = Vector3.Dot(normal, Vector3.forward);
        float a = Vector3.Magnitude(normal);
        float b = Vector3.Magnitude(Vector3.forward);
        if (a * b == 0f)
        {
            Debug.Log("zero");
            return;
        }
        float cos = Dot / (a * b);

        float sign = Mathf.Sign(Vector3.Dot(normal, new Vector3(1, 0, 0)));
        float h = Mathf.Acos(cos);//通过Acos函数可通过余弦值计算出对应弧度
        var d = (h *= Mathf.Rad2Deg);//弧度转度。这里得到的始终为正值
        //旋转
        if (sign < 0)
        {
            transform.RotateAround(transform.position, Vector3.up, d);
        }
        else
        {
            transform.RotateAround(transform.position, Vector3.up, -d);
        }

        //移动
        centre = (RightHand.position + LeftHand.position) / 2;
        Vector3 pos = transform.position;
        pos.x = pos.x - centre.x;
        pos.z = pos.z - centre.z;
        transform.position = pos;

    }

    void calibrate2()
    {
        //计算当前面朝方向向量
        Vector3 slide1 = RightHand.position - LeftHand.position;
        Vector3 normal = Vector3.Cross(slide1, Vector3.up);

        //计算当前面朝方向于目标面朝方向向量夹角
        float Dot = Vector3.Dot(normal, -Vector3.forward);
        float a = Vector3.Magnitude(normal);
        float b = Vector3.Magnitude(-Vector3.forward);
        if (a * b == 0f)
        {
            Debug.Log("zero");

            return;
        }
        float cos = Dot / (a * b);
        
        float sign = Mathf.Sign(Vector3.Dot(normal, new Vector3(-1, 0, 0)));
        float h = Mathf.Acos(cos);//通过Acos函数可通过余弦值计算出对应弧度
        var d = (h *= Mathf.Rad2Deg);//弧度转度。这里得到的始终为正值

        //旋转
        if (sign < 0)
        {
            transform.RotateAround(transform.position, Vector3.up, d);
        }
        else
        {
            transform.RotateAround(transform.position, Vector3.up, -d);
        }
        //移动
        centre = (RightHand.position + LeftHand.position) / 2;
        Vector3 pos = transform.position;
        pos.x = pos.x - centre.x;
        pos.z = pos.z - centre.z;
        transform.position = pos;

    }
}

