using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gamekit3D;
using Gamekit3D.Network;
using Assets._3DGamekit;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    public GameObject InventoryCell;
    public GameObject InventoryGridContent;
    public GameObject picture;
    public TextMeshProUGUI Attribute;
    public TextMeshProUGUI Value;
    public TextMeshProUGUI total_count;
    public TextMeshProUGUI treasure_name;

    public static  Dictionary<string, GameObject> treasure_GameObject = new Dictionary<string, GameObject>();
    public int test = 0;

    // Use this for initialization

    private void Awake()
    {
        InventoryCell.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerMyController.Instance.EnabledWindowCount++;
        int capacity = PlayerMyController.Instance.InventoryCapacity;
        int count = PlayerMyController.Instance.Inventory.Count;
        int count2 = 0;

        foreach (var kv in mycommon.name_status_count)
        {

            if(mycommon.name_status_count[kv.Key].inventory != 0 || mycommon.name_status_count[kv.Key].wear != 0)
            {

                GameObject cloned = GameObject.Instantiate(InventoryCell);          
                Button button = cloned.GetComponent<Button>();
                // TODO ... specify icon by item types
               
                if(test == 0)
                {
                    treasure_GameObject.Add(kv.Key, cloned);   // 出现问题,怎么保证它只调用一次
                }

                Sprite icon = GetAllIcons.icons[kv.Key];
                button.image.sprite = icon;
                button.onClick.AddListener(delegate ()
                {
                   
                    GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;
                    if(mycommon.name_attribute[kv.Key] == "equipment")
                    {
                        string attribute_name =  "装备";
                        Attribute.SetText(string.Format(attribute_name), true);
                    }
                    else if (mycommon.name_attribute[kv.Key] == "tool")
                    {
                        string attribute_name =  "工具";
                        Attribute.SetText(string.Format(attribute_name), true);
                    }
                    else if(mycommon.name_attribute[kv.Key] == "accessories")
                    {
                        string attribute_name =  "配饰";
                        Attribute.SetText(string.Format(attribute_name), true);
                    }
                    else
                    {
                        string attribute_name = "消耗品";
                        Attribute.SetText(string.Format(attribute_name), true);
                    }
                    Value.SetText(mycommon.name_value[kv.Key].ToString(), true);

                    int count_tmp = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                    total_count.SetText(count_tmp.ToString(), true);
                    treasure_name.SetText(kv.Key, true);

                    //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                });

                //string name_tmp = kv.Key;
                //treasure_name.SetText(name_tmp, true);
                //int total = mycommon.name_status_count[kv.Key].inventory + mycommon.name_status_count[kv.Key].wear;
                //total_count.SetText(total.ToString(), true);

                cloned.SetActive(true);
                cloned.transform.SetParent(InventoryGridContent.transform, false);
                count2++;
            }


        }

        test++;


        //foreach (var kv in PlayerMyController.Instance.Inventory)
        //{
        //    GameObject cloned = GameObject.Instantiate(InventoryCell);
        //    Button button = cloned.GetComponent<Button>();
        //    // TODO ... specify icon by item types
        //    Sprite icon = GetAllIcons.icons["Sword_2"];
        //    button.image.sprite = icon;
        //    button.onClick.AddListener(delegate ()
        //    {
        //        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;
        //        GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
        //    });


        //    cloned.SetActive(true);
        //    cloned.transform.SetParent(InventoryGridContent.transform, false);
            
        //}

        
        for (int i = 0; i < capacity - count2; i++)
        {
            GameObject cloned = GameObject.Instantiate(InventoryCell);
            cloned.SetActive(true);
            cloned.transform.SetParent(InventoryGridContent.transform, false);
        }
    }

    private void OnDisable()
    {
        int cellCount = InventoryGridContent.transform.childCount;
        foreach (Transform transform in InventoryGridContent.transform)
        {
            Destroy(transform.gameObject);
        }
        PlayerMyController.Instance.EnabledWindowCount--;
    }

    void Start()
    {
        //foreach (var kv in mycommon.name_attribute)
        //{
        //    treasure_GameObject.Add(kv.Key, cloned);   // 出现问题

        //}
            
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RoleUI_Elixir_destroy()
    {
        
    }

    void ExtendBagCapacity(int n)
    {
        int cellCount = InventoryGridContent.transform.childCount;
        for (int i = 0; i < n - cellCount; i++)
        {
            GameObject cloned = GameObject.Instantiate(InventoryCell);
            cloned.SetActive(true);
            cloned.transform.SetParent(InventoryGridContent.transform, false);
        }
    }
}
