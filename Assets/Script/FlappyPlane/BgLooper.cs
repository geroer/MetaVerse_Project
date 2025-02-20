using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //Scene�� �����ϴ� ��� Object�� ���ƴٴϸ鼭 Obstacle�� �޷��ִ��� Ȯ��
        //start�� awake ���� ������ �ѹ��� ���۵ǰ� �ϴ� ���� ����
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        //��� ��ֹ��� �����ϰ� ��ġ
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    //�浹�� ������Ʈ�� ���� ��ġ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;   //Collider2D�� BoxCollider2D�� size�� ���� �� �� ��� ����ȯ �� ��������� ��
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }

    }
}
