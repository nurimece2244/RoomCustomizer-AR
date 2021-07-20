using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class DataHandler : MonoBehaviour
{
    [SerializeField] private GameObject furniture;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> _items;
    [SerializeField] private String label;

    private int id = 0;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }

    }

    void Start()
    {
        //_items = new List<Item>();
        LoadItems();

        CreateButtons();
    }

    void LoadItems()
    {
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in items_obj)
        {
            _items.Add(item as Item);
        }
    }
    void CreateButtons()
    {
        foreach (Item i in _items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = id;
            b.ButtonTexture = i.itemImage;
            id++;
        }
        buttonContainer.GetComponent<UIContentFitter>().Fit();
    }

    public void SetFurniture(int id)
    {
        furniture = _items[id].itemPrefab;
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }


}