using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VegGeneration : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] vegsArr;
    private TilemapCollider2D groundCollider;
    private TilemapRenderer ground;
    private float groundColliderTop;
    private int randomIndex;
    private float borderX;

    private void Awake()
    {
        ground = GetComponent<TilemapRenderer>();
        groundCollider = GetComponent<TilemapCollider2D>();

        for (int i = 0, limit = 5; i < limit; ++i)
        {
            randomIndex = Random.Range(0, vegsArr.Length);
            borderX = ground.transform.position.x + ground.bounds.extents.x;
            groundColliderTop = groundCollider.transform.position.y + groundCollider.bounds.extents.y;
            Instantiate(vegsArr[randomIndex]);
            vegsArr[randomIndex].transform.position = new Vector3(Random.Range(-borderX, borderX), groundColliderTop + vegsArr[randomIndex].bounds.extents.y);
        }
    }
}
