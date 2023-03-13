using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct Ground
{
    public GameObject tile;
    public float entropy;

    public Ground(GameObject _tile)
    {
        tile = _tile;
        entropy = 0;
    }
    public float modifyEntropy(float amount)
    {
        if (amount == 0) return entropy;
        entropy += amount;
        entropyChanged();
        return entropy;
    }

    private void entropyChanged()
    {
        SpriteRenderer sprite = tile.GetComponentInChildren<SpriteRenderer>();
        sprite.color = new Color(255, 255, 255, 1 - entropy * 0.1f);
        return;
    }
}

public class EntropyController : MonoBehaviour
{
    public GameObject myGameObject;
    public GameObject grassTilePrefab; // Reference to the tile prefab
    public int rows;
    public int cols;

    private Ground[,] _grounds; 
    // Start is called before the first frame update
    void Start()
    {
        _grounds = new Ground[cols, rows];
        myGameObject = GameObject.Find("EntropyController");
        GenerateGrid();
        GenerateEntropyOverlay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateEntropyOverlay()
    {
        Text myTextComponent = myGameObject.AddComponent<Text>();
        myTextComponent.text = "Hello, World!";
        myTextComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        myTextComponent.fontSize = 24;
        myTextComponent.color = Color.white;

        // Add a RectTransform component to the GameObject to position the text
        RectTransform myRectTransform = myGameObject.GetComponent<RectTransform>();
        myRectTransform.localPosition = new Vector3(0, 0, 0);
        myRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        myRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        myRectTransform.pivot = new Vector2(0.5f, 0.5f);
    }
    void GenerateGrid()
    {
        for (int x = 0; x < cols; x++)
        {
            Vector3 position = new Vector3(x, -1, 0);
            if (x % 2 == 1) position.y += 0.5f;
            for (int y = 0; y < rows; y++)
            {
                position.y += 1;
                GameObject tile = Instantiate(grassTilePrefab, position, Quaternion.identity);
                tile.transform.localScale = new Vector3(.833f, .714f, 1);
                _grounds[x, y] = new Ground(tile);
            }
        }
    }
    public float modifyEntropy(int x,  int y)
    {
        Debug.Log($"modifying {x}, {y}");
        return _grounds[x, y].modifyEntropy(1f);
    }
}
