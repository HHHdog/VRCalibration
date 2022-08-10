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

        //���㵱ǰ�泯��������
        Vector3 slide1 = RightHand.position - LeftHand.position;

        Vector3 normal = Vector3.Cross(slide1, Vector3.up);

        //���㵱ǰ�泯������Ŀ���泯���������н�
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
        float h = Mathf.Acos(cos);//ͨ��Acos������ͨ������ֵ�������Ӧ����
        var d = (h *= Mathf.Rad2Deg);//����ת�ȡ�����õ���ʼ��Ϊ��ֵ
        //��ת
        if (sign < 0)
        {
            transform.RotateAround(transform.position, Vector3.up, d);
        }
        else
        {
            transform.RotateAround(transform.position, Vector3.up, -d);
        }

        //�ƶ�
        centre = (RightHand.position + LeftHand.position) / 2;
        Vector3 pos = transform.position;
        pos.x = pos.x - centre.x;
        pos.z = pos.z - centre.z;
        transform.position = pos;

    }

    void calibrate2()
    {
        //���㵱ǰ�泯��������
        Vector3 slide1 = RightHand.position - LeftHand.position;
        Vector3 normal = Vector3.Cross(slide1, Vector3.up);

        //���㵱ǰ�泯������Ŀ���泯���������н�
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
        float h = Mathf.Acos(cos);//ͨ��Acos������ͨ������ֵ�������Ӧ����
        var d = (h *= Mathf.Rad2Deg);//����ת�ȡ�����õ���ʼ��Ϊ��ֵ

        //��ת
        if (sign < 0)
        {
            transform.RotateAround(transform.position, Vector3.up, d);
        }
        else
        {
            transform.RotateAround(transform.position, Vector3.up, -d);
        }
        //�ƶ�
        centre = (RightHand.position + LeftHand.position) / 2;
        Vector3 pos = transform.position;
        pos.x = pos.x - centre.x;
        pos.z = pos.z - centre.z;
        transform.position = pos;

    }
}

