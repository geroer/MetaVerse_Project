using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public new List<SpriteRenderer> light;

    public GameObject minigameText;

    private Transform interact;

    private Color curColor;
    private Color targetColor;

    private void Awake()
    {
        interact = this.transform;
        targetColor = light[0].color;
    }

    private void Start()
    {
        minigameText.SetActive(false);
    }

    void Update()
    {
        curColor = Color.Lerp(curColor, targetColor, Time.deltaTime * 3);

        foreach (var l in light)
        {
            l.color = curColor;
        }

        if (minigameText.activeSelf)
        {
            minigameText.transform.position = interact.position + new Vector3 ( 0, 3, 0 );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            minigameText.SetActive(true);
            targetColor.a = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            minigameText.SetActive(false);
            targetColor.a = 0f;
        }
    }
}
