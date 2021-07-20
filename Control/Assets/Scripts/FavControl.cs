using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavControl : MonoBehaviour
{
    private GameObject furniture;

    [SerializeField] private ButtonFav buttonPrefab;
    [SerializeField] private GameObject buttonContainter;
    [SerializeField] private List<GameObject> gameobject;

    private int current_id = 0;


    private static FavControl instance;
    public static FavControl Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FavControl>();
            }
            return instance;
        }

    }

    private void Start()
    {
        LoadFavorite();
        CreateFavoriteButtons();
    }

    void LoadFavorite()
    {
        var fav = Resources.LoadAll("FavoriteObject", typeof(GameObject));
        foreach (var item in fav)
        {
            gameobject.Add(item as GameObject);
        }


    }
    void CreateFavoriteButtons()
    {
        foreach (GameObject i in gameobject)
        {
            ButtonFav b = Instantiate(buttonPrefab, buttonContainter.transform);
            b.ItemId = current_id;
            current_id++;
        }


    }

    public GameObject GetFurniture()
    {
        return furniture;
    }

    public void SetFurniture(int id)
    {
        furniture = gameobject[id].gameObject;
    }



}
