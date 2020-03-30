using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VegGeneration : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] vegsArr;
    private TilemapCollider2D groundCollider;
    private TilemapRenderer groundSprite;
    private Tilemap ground;
    private float groundCells;
    private float vegYPos;
    private int randomIndex;
    private float borderX;

    private void Awake()
    {
        ground = GetComponent<Tilemap>();
        groundSprite = GetComponent<TilemapRenderer>();
        groundCollider = GetComponent<TilemapCollider2D>();

        

        for (int i = 0, limit = 15; i < limit; ++i)
        {
            randomIndex = Random.Range(0, vegsArr.Length);
            borderX = groundSprite.transform.localPosition.x + groundSprite.bounds.extents.x;

            //transform.y - half.y + x * cellsize
            vegYPos = ground.transform.position.y - ground.LocalToWorld(ground.localBounds.extents).y + ground.cellSize.y * (ground.size.y / 3) + vegsArr[randomIndex].bounds.extents.y;

            Instantiate(vegsArr[randomIndex], new Vector3(Random.Range(-borderX, borderX), vegYPos ), vegsArr[randomIndex].transform.rotation);
            Debug.Log("vegsExtentsY " + vegsArr[randomIndex].bounds.extents.y);
            
        }

        Debug.Log("vegYPos " + vegYPos);
        Debug.Log("groundCellsize " + ground.size.y);
        
    }
}
