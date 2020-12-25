﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//################
//# TODO:
//#   - Posible improvement: create a Sibgleton for this class¿
//###

public class DataHandler : MonoBehaviour
{

    [SerializeField] private GameObject furniture;
    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items; //we will store all the 3D objects we need for the App.

    private int current_id = 0; //we will use it to identify each object. We will use the position of the Item in the List items as ID.

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

    private void Start(){
      //LoadItems(); 
      //CreateButtons();//This does not work when the objects come from Cloud (asynch method), 
                        // the objects are not yet dowloaded when this executes, so we move the button creation
                        // to AssetLoader instead of here.
    }

    public void CreateButton(GameObject cloudAsset, Sprite image, int id)
    {

      Item auxItem = ScriptableObject.CreateInstance<Item>();
      
      auxItem.itemPrefab = cloudAsset;
      auxItem.itemImage = image;
      items.Add(auxItem as Item);

      ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
      b.ItemId = id;
      b.ButtonTexture = auxItem.itemImage;
    }
    
    public void SetFurniture(int id){
        furniture = items[id].itemPrefab;
        Debug.Log("Button " + id + " selected");
    }

    public GameObject GetFurniture(){
      return furniture;
    }

/*     public void LoadItems(List<GameObject> loadedAssets){
        //var items_obj = Resources.LoadAll("Items", typeof(Item));
        //AssetLoader cloudLoader = new AssetLoader();
        //var cloud_objs_list = cloudLoader.GetCloudAssets();

        foreach (var cloudObj in loadedAssets){

          Item auxItem = new Item();
          //auxItem.price = 0.0F;
          auxItem.itemPrefab = cloudObj;
          //auxItem.itemImage = cloudObj.Image;

          items.Add(auxItem as Item);
          print(items);
        }
        
    } */

/*     public void LoadItem(GameObject cloudAsset){

      //Item auxItem = new Item();
      Item auxItem = ScriptableObject.CreateInstance<Item>();
      //auxItem.price = 0.0F;
      auxItem.itemPrefab = cloudAsset;

      items.Add(auxItem as Item);
    } */



/*     public void CreateButtons()
    {
        current_id = 0;
        foreach(Item i in items){
          //We will create a button for each Item in the list
          ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
          b.ItemId = current_id;
          //b.ButtonTexture = i.itemImage;
          current_id++;
        }
    } */

}
