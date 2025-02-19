using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] GameObject map;

    private TilemapRenderer renderer;

    private float width;
    private float height;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        renderer = map.GetComponent<TilemapRenderer>();

        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 cameraPosition = new Vector3(playerController.transform.position.x, playerController.transform.position.y, transform.position.z);

        float minX = renderer.bounds.min.x + width;
        float maxX = renderer.bounds.max.x - width;
        float minY = renderer.bounds.min.y + height;
        float maxY = renderer.bounds.max.y - height;

        float clampedX = Mathf.Clamp(cameraPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(cameraPosition.y, minY, maxY);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, clampedPosition, Time.deltaTime * playerController.speed);
    }
}
