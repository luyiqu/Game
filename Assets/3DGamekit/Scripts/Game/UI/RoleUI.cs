using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Gamekit3D;
using System;
using Assets._3DGamekit;
using UnityEngine.UI;
using Common;
using Gamekit3D.Network;

public class RoleUI : MonoBehaviour
{

    public TextMeshProUGUI HPValue;
    public TextMeshProUGUI AttackValue;
    public TextMeshProUGUI WorkingValue;
    public TextMeshProUGUI LuckValue;
    public TextMeshProUGUI SilverValue;
    public TextMeshProUGUI GoldValue;

    public TextMeshProUGUI total_count;
    public TextMeshProUGUI treasure_name;

    private Damageable m_damageable;
    private PlayerController m_controller;

    public GameObject InventoryCell;
    public GameObject InventoryGridContent;
    public TextMeshProUGUI Attribute;
    public TextMeshProUGUI Value;
    public GameObject hel;     //每个button都需要建立一个实体，和UI里面的连吗
    public GameObject arm;
    public GameObject wea;
    public GameObject rin;
    public GameObject amu;
    public GameObject shi;
    public GameObject wear;
    public GameObject putoff;
    public GameObject too;
    //public GameObject eli;
    public Sprite backgroud;

    public Dictionary<string,GameObject> treasure_GameObject = InventoryUI.treasure_GameObject;


    private void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        PlayerMyController.Instance.EnabledWindowCount++;
        if (m_controller == null || m_damageable == null)
        {
            m_controller = PlayerController.Mine;
            m_damageable = PlayerController.Mine.GetComponent<Damageable>();
        }
        string hp = string.Format("{0}/{1}", m_damageable.currentHitPoints, m_damageable.maxHitPoints);
        Console.WriteLine(hp);
        HPValue.SetText(hp, true);  //这里需要转成string


        //HPValue.text = "100";
        //InteligenceValue.text = "100";
        String LV = Assets._3DGamekit.mycommon.luck_value.ToString();
        String WV = Assets._3DGamekit.mycommon.working_value.ToString();
        String AV = Assets._3DGamekit.mycommon.attack_value.ToString();
        String SV = Assets._3DGamekit.mycommon.silver_coin.ToString();
        String GV = Assets._3DGamekit.mycommon.gold_coin.ToString();

        Console.WriteLine(SV);
        Console.WriteLine(AV);

        LuckValue.SetText(LV, true);
        WorkingValue.SetText(WV, true);
        AttackValue.SetText(AV, true);
        SilverValue.SetText(SV, true);
        GoldValue.SetText(GV, true);

        foreach (var kv in mycommon.name_status_count)
        {
            if (mycommon.name_status_count[kv.Key].wear == 1)
            {
                if (mycommon.name_category[kv.Key] == "helmet")
                {
                    Button button = hel.GetComponent<Button>();
                    Sprite icon = GetAllIcons.icons[kv.Key];
                    button.image.sprite = icon;
                    button.onClick.AddListener(delegate ()
                    {
                        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                        if (mycommon.name_attribute[kv.Key] == "equipment")
                        {
                            string attribute_name = "装备";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else if (mycommon.name_attribute[kv.Key] == "tool")
                        {
                            string attribute_name = "工具";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else
                        {
                            string attribute_name = "配饰";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        Value.SetText(mycommon.name_value[kv.Key].ToString(), true);
                        int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                        total_count.SetText(count.ToString(), true);
                        treasure_name.SetText(kv.Key, true);
                        //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                    });
                }

                else if (mycommon.name_category[kv.Key] == "armour")
                {
                    Button button = arm.GetComponent<Button>();
                    Sprite icon = GetAllIcons.icons[kv.Key];
                    button.image.sprite = icon;
                    button.onClick.AddListener(delegate ()
                    {
                        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                        if (mycommon.name_attribute[kv.Key] == "equipment")
                        {
                            string attribute_name = "装备";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else if (mycommon.name_attribute[kv.Key] == "tool")
                        {
                            string attribute_name = "工具";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else
                        {
                            string attribute_name = "配饰";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        Value.SetText(mycommon.name_value[kv.Key].ToString(), true);
                        int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                        total_count.SetText(count.ToString(), true);
                        treasure_name.SetText(kv.Key, true);
                        //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                    });
                }

                else if (mycommon.name_category[kv.Key] == "weapon")
                {
                    Button button = wea.GetComponent<Button>();
                    Sprite icon = GetAllIcons.icons[kv.Key];
                    button.image.sprite = icon;
                    button.onClick.AddListener(delegate ()
                    {
                        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                        if (mycommon.name_attribute[kv.Key] == "equipment")
                        {
                            string attribute_name = "装备";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else if (mycommon.name_attribute[kv.Key] == "tool")
                        {
                            string attribute_name = "工具";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else
                        {
                            string attribute_name = "配饰";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        Value.SetText(mycommon.name_value[kv.Key].ToString(), true);
                        int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                        total_count.SetText(count.ToString(), true);
                        treasure_name.SetText(kv.Key, true);
                        //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                    });
                }

               

                else if (mycommon.name_category[kv.Key] == "amulet")
                {
                    Button button = amu.GetComponent<Button>();
                    Sprite icon = GetAllIcons.icons[kv.Key];
                    button.image.sprite = icon;
                    button.onClick.AddListener(delegate ()
                    {
                        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                        if (mycommon.name_attribute[kv.Key] == "equipment")
                        {
                            string attribute_name = "装备";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else if (mycommon.name_attribute[kv.Key] == "tool")
                        {
                            string attribute_name = "工具";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else
                        {
                            string attribute_name = "配饰";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        Value.SetText(mycommon.name_value[kv.Key].ToString(), true);
                        int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                        total_count.SetText(count.ToString(), true);
                        treasure_name.SetText(kv.Key, true);
                        //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                    });
                }

                else if (mycommon.name_category[kv.Key] == "shield")
                {
                    Button button = shi.GetComponent<Button>();
                    Sprite icon = GetAllIcons.icons[kv.Key];
                    button.image.sprite = icon;
                    button.onClick.AddListener(delegate ()
                    {
                        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                        if (mycommon.name_attribute[kv.Key] == "equipment")
                        {
                            string attribute_name = "装备";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else if (mycommon.name_attribute[kv.Key] == "tool")
                        {
                            string attribute_name = "工具";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else
                        {
                            string attribute_name = "配饰";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        Value.SetText(mycommon.name_value[kv.Key].ToString(), true);
                        int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                        total_count.SetText(count.ToString(), true);
                        treasure_name.SetText(kv.Key, true);
                        //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                    });
                }

                else if (mycommon.name_category[kv.Key] == "tool")
                {
                    Button button = too.GetComponent<Button>();
                    Sprite icon = GetAllIcons.icons[kv.Key];
                    button.image.sprite = icon;
                    button.onClick.AddListener(delegate ()
                    {
                        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                        if (mycommon.name_attribute[kv.Key] == "equipment")
                        {
                            string attribute_name = "装备";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else if (mycommon.name_attribute[kv.Key] == "tool")
                        {
                            string attribute_name = "工具";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else
                        {
                            string attribute_name = "配饰";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        Value.SetText(mycommon.name_value[kv.Key].ToString(), true);
                        int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                        total_count.SetText(count.ToString(), true);
                        treasure_name.SetText(kv.Key, true);
                        //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                    });
                }


                else
                {
                    Button button = rin.GetComponent<Button>();
                    Sprite icon = GetAllIcons.icons[kv.Key];
                    button.image.sprite = icon;
                    button.onClick.AddListener(delegate ()
                    {
                        GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                        if (mycommon.name_attribute[kv.Key] == "equipment")
                        {
                            string attribute_name = "装备";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else if (mycommon.name_attribute[kv.Key] == "tool")
                        {
                            string attribute_name = "工具";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        else
                        {
                            string attribute_name = "配饰";
                            Attribute.SetText(string.Format(attribute_name), true);
                        }
                        Value.SetText(mycommon.name_value[kv.Key].ToString(), true);
                        int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                        total_count.SetText(count.ToString(), true);
                        treasure_name.SetText(kv.Key, true);
                        //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
                    });
                }

            }



        }

        Button button_wear = wear.GetComponent<Button>();
        button_wear.onClick.AddListener(delegate ()
        {

            Wear();
            //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
        });

        Button button_putoff = putoff.GetComponent<Button>();
        button_putoff.onClick.AddListener(delegate ()
        {
            Putoff();

        });


    }

    private void OnDisable()
    {
        PlayerMyController.Instance.EnabledWindowCount--;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Test()
    {
        HPValue.text = "100";
        AttackValue.text = "100";
    }

    void Putoff()
    {
        CPutoff msg = new CPutoff();

        status_count tmp;

        string treasure_category;
        //得到脱下宝物的icon
        Sprite icon = GameObject.Find("ItemImage").GetComponent<Image>().sprite;
        foreach (string key in GetAllIcons.icons.Keys)
        {
            if (GetAllIcons.icons[key].Equals(icon))
            {
                msg.old_treasure = key;

                break;    //退出循环
            }
        }

        treasure_category = mycommon.name_category[msg.old_treasure];
        Button button2;
        Sprite icon2;
         
        //判断是否有穿着
        if(mycommon.name_status_count[msg.old_treasure].wear == 1)
        {
            string treasure_name_tmp = msg.old_treasure;
            tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
            tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
            mycommon.name_status_count[msg.old_treasure] = tmp;


            if (treasure_category == "helmet")
            {
                button2 = hel.GetComponent<Button>();
                button2.image.sprite = backgroud;   //不知道这样子对不对
                mycommon.attack_value -= mycommon.name_value[msg.old_treasure];
                AttackValue.SetText(mycommon.attack_value.ToString(), true);

                msg.treasure_attribute = "equipment";     //方便修改player表的属性值
                msg.treasure_value = mycommon.attack_value;

            }

            else if (treasure_category == "armour")
            {
                button2 = arm.GetComponent<Button>();
                button2.image.sprite = backgroud;
                mycommon.attack_value -= mycommon.name_value[msg.old_treasure];
                AttackValue.SetText(mycommon.attack_value.ToString(), true);

                msg.treasure_attribute = "equipment";     //方便修改player表的属性值
                msg.treasure_value = mycommon.attack_value;

            }

            else if (treasure_category == "weapon")
            {
                button2 = wea.GetComponent<Button>();
                icon2 = button2.image.sprite;
                button2.image.sprite = backgroud;
                mycommon.attack_value -= mycommon.name_value[msg.old_treasure];
                AttackValue.SetText(mycommon.attack_value.ToString(), true);


                msg.treasure_attribute = "equipment";     //方便修改player表的属性值
                msg.treasure_value = mycommon.attack_value;

            }
            else if (treasure_category == "amulet")
            {
                button2 = amu.GetComponent<Button>();
                icon2 = button2.image.sprite;
                button2.image.sprite = backgroud;
                mycommon.luck_value -= mycommon.name_value[msg.old_treasure];
                LuckValue.SetText(mycommon.luck_value.ToString(), true);


                msg.treasure_attribute = "accessories";     //方便修改player表的属性值
                msg.treasure_value = mycommon.luck_value;

            }

            else if (treasure_category == "tool")
            {
                button2 = too.GetComponent<Button>();
                icon2 = button2.image.sprite;
                button2.image.sprite = backgroud;
                mycommon.working_value -= mycommon.name_value[msg.old_treasure];
                WorkingValue.SetText(mycommon.working_value.ToString(), true);


                msg.treasure_attribute = "tool";     //方便修改player表的属性值
                msg.treasure_value = mycommon.working_value;

            }


            else if (treasure_category == "shield")
            {
                button2 = shi.GetComponent<Button>();
                icon2 = button2.image.sprite;
                button2.image.sprite = backgroud;
                mycommon.attack_value -= mycommon.name_value[msg.old_treasure];
                AttackValue.SetText(mycommon.attack_value.ToString(), true);

                msg.treasure_attribute = "equipment";     //方便修改player表的属性值
                msg.treasure_value = mycommon.attack_value;

            }
            else if (treasure_category == "ring")
            {
                button2 = rin.GetComponent<Button>();
                icon2 = button2.image.sprite;
                button2.image.sprite = backgroud;

                mycommon.luck_value -= mycommon.name_value[msg.old_treasure];
                LuckValue.SetText(mycommon.luck_value.ToString(), true);


                msg.treasure_attribute = "accessories";     //方便修改player表的属性值
                msg.treasure_value = mycommon.luck_value;

            }

            MyNetwork.Send(msg);
        }
        //else
        //{
            
        //}

    }

    void Wear()
    {
        CWear msg = new CWear();

        status_count tmp;

        string treasure_category;
        msg.new_treasure = string.Empty;
        msg.old_treasure = string.Empty;

        //得到new_treasure_name
        Sprite icon = GameObject.Find("ItemImage").GetComponent<Image>().sprite;
        foreach (string key in GetAllIcons.icons.Keys)
        {
            if (GetAllIcons.icons[key].Equals(icon))
            {
                msg.new_treasure = key;

                break;    //退出循环
            }
        }

        //得到new_treasure_category，方便替换
        treasure_category = mycommon.name_category[msg.new_treasure];

        //得到old_treasure_name , 注意空icons的判断,如果存在old_treasure的话，直接减掉它的值就好了，然后传这个消息回去ba
        //+ 传类别 & 属性值
        //判断new_treasure_category,在对应位置显示出来！

        Button button2;
        Sprite icon2;

        if (mycommon.name_status_count[msg.new_treasure].inventory != 0)
        {
            string treasure_name_tmp = msg.new_treasure;

            tmp.wear = mycommon.name_status_count[msg.new_treasure].wear + 1;
            tmp.inventory = mycommon.name_status_count[msg.new_treasure].inventory - 1;
            mycommon.name_status_count[msg.new_treasure] = tmp;

            if (treasure_category == "helmet")
        {
            button2 = hel.GetComponent<Button>();
            icon2 = button2.image.sprite;
            button2.image.sprite = GetAllIcons.icons[msg.new_treasure];   //直接显示在前端！
            mycommon.attack_value += mycommon.name_value[msg.new_treasure];
            AttackValue.SetText(mycommon.attack_value.ToString(), true);

            foreach (string key in GetAllIcons.icons.Keys)
            {
                if (GetAllIcons.icons[key].Equals(icon2))
                {
                    msg.old_treasure = key;
                    mycommon.attack_value -= mycommon.name_value[msg.old_treasure];

                    tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
                    tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
                    mycommon.name_status_count[msg.old_treasure] = tmp;

                        AttackValue.SetText(mycommon.attack_value.ToString(), true);
                    
                    break;    //退出循环
                }
            }

            button2.onClick.AddListener(delegate ()
            {
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                if (mycommon.name_attribute[msg.new_treasure] == "equipment")
                {
                    string attribute_name = "装备";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else if (mycommon.name_attribute[msg.new_treasure] == "tool")
                {
                    string attribute_name = "工具";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else
                {
                    string attribute_name = "配饰";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                Value.SetText(mycommon.name_value[msg.new_treasure].ToString(), true);
                //int count = mycommon.name_status_count[kv.Key].wear + mycommon.name_status_count[kv.Key].inventory;
                //total_count.SetText(count.ToString(), true);
                //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
            });

            msg.treasure_attribute = "equipment";     //方便修改player表的属性值
            msg.treasure_value = mycommon.attack_value;

        }

        else if (treasure_category == "armour")
        {
            button2 = arm.GetComponent<Button>();
            icon2 = button2.image.sprite;
            button2.image.sprite = GetAllIcons.icons[msg.new_treasure];
            mycommon.attack_value += mycommon.name_value[msg.new_treasure];
            AttackValue.SetText(mycommon.attack_value.ToString(), true);

            foreach (string key in GetAllIcons.icons.Keys)
            {
                if (GetAllIcons.icons[key].Equals(icon2))
                {
                    msg.old_treasure = key;
                    mycommon.attack_value -= mycommon.name_value[msg.old_treasure];
                    AttackValue.SetText(mycommon.attack_value.ToString(), true);
                    tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
                    tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
                    mycommon.name_status_count[msg.old_treasure] = tmp;
                        break;    //退出循环
                }
            }

            button2.onClick.AddListener(delegate ()
            {
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                if (mycommon.name_attribute[msg.new_treasure] == "equipment")
                {
                    string attribute_name = "装备";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else if (mycommon.name_attribute[msg.new_treasure] == "tool")
                {
                    string attribute_name = "工具";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else
                {
                    string attribute_name = "配饰";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                Value.SetText(mycommon.name_value[msg.new_treasure].ToString(), true);
                //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
            });

            msg.treasure_attribute = "equipment";     //方便修改player表的属性值
            msg.treasure_value = mycommon.attack_value;

        }

        else if (treasure_category == "weapon")
        {
            button2 = wea.GetComponent<Button>();
            icon2 = button2.image.sprite;
            button2.image.sprite = GetAllIcons.icons[msg.new_treasure];
            mycommon.attack_value += mycommon.name_value[msg.new_treasure];
            AttackValue.SetText(mycommon.attack_value.ToString(), true);

            foreach (string key in GetAllIcons.icons.Keys)
            {
                if (GetAllIcons.icons[key].Equals(icon2))
                {
                    msg.old_treasure = key;
                    mycommon.attack_value -= mycommon.name_value[msg.old_treasure];

                    AttackValue.SetText(mycommon.attack_value.ToString(), true);
                    tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
                    tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
                    mycommon.name_status_count[msg.old_treasure] = tmp;
                        break;    //退出循环
                }
            }

            button2.onClick.AddListener(delegate ()
            {
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;    //确定这里是icon吗

                if (mycommon.name_attribute[msg.new_treasure] == "equipment")
                {
                    string attribute_name = "装备";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else if (mycommon.name_attribute[msg.new_treasure] == "tool")
                {
                    string attribute_name = "工具";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else
                {
                    string attribute_name = "配饰";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                Value.SetText(mycommon.name_value[msg.new_treasure].ToString(), true);
                //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
            });

            msg.treasure_attribute = "equipment";     //方便修改player表的属性值
            msg.treasure_value = mycommon.attack_value;

        }
        else if (treasure_category == "amulet")
        {
            button2 = amu.GetComponent<Button>();
            icon2 = button2.image.sprite;
            button2.image.sprite = GetAllIcons.icons[msg.new_treasure];
            mycommon.luck_value += mycommon.name_value[msg.new_treasure];
            LuckValue.SetText(mycommon.luck_value.ToString(), true);
            foreach (string key in GetAllIcons.icons.Keys)
            {
                if (GetAllIcons.icons[key].Equals(icon2))
                {
                    msg.old_treasure = key;
                    mycommon.luck_value -= mycommon.name_value[msg.old_treasure];
                    LuckValue.SetText(mycommon.luck_value.ToString(), true);
                        tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
                        tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
                        mycommon.name_status_count[msg.old_treasure] = tmp;
                        break;    //退出循环
                }
            }

            button2.onClick.AddListener(delegate ()
            {
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                if (mycommon.name_attribute[msg.new_treasure] == "equipment")
                {
                    string attribute_name = "装备";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else if (mycommon.name_attribute[msg.new_treasure] == "tool")
                {
                    string attribute_name = "工具";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else
                {
                    string attribute_name = "配饰";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                Value.SetText(mycommon.name_value[msg.new_treasure].ToString(), true);
                //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
            });

            msg.treasure_attribute = "accessories";     //方便修改player表的属性值
            msg.treasure_value = mycommon.luck_value;

        }

        else if (treasure_category == "tool")
        {
            button2 = too.GetComponent<Button>();
            icon2 = button2.image.sprite;
            button2.image.sprite = GetAllIcons.icons[msg.new_treasure];
            mycommon.working_value += mycommon.name_value[msg.new_treasure];
            WorkingValue.SetText(mycommon.working_value.ToString(), true);
            foreach (string key in GetAllIcons.icons.Keys)
            {
                if (GetAllIcons.icons[key].Equals(icon2))
                {
                    msg.old_treasure = key;
                    mycommon.working_value -= mycommon.name_value[msg.old_treasure];
                    WorkingValue.SetText(mycommon.working_value.ToString(), true);
                        tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
                        tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
                        mycommon.name_status_count[msg.old_treasure] = tmp;
                        break;    //退出循环
                }
            }

            button2.onClick.AddListener(delegate ()
            {
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                if (mycommon.name_attribute[msg.new_treasure] == "equipment")
                {
                    string attribute_name = "装备";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else if (mycommon.name_attribute[msg.new_treasure] == "tool")
                {
                    string attribute_name = "工具";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else
                {
                    string attribute_name = "配饰";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                Value.SetText(mycommon.name_value[msg.new_treasure].ToString(), true);
                //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
            });

            msg.treasure_attribute = "tool";     //方便修改player表的属性值
            msg.treasure_value = mycommon.working_value;

        }


        else if (treasure_category == "shield")
        {
            button2 = shi.GetComponent<Button>();
            icon2 = button2.image.sprite;
            button2.image.sprite = GetAllIcons.icons[msg.new_treasure];
            mycommon.attack_value += mycommon.name_value[msg.new_treasure];
            AttackValue.SetText(mycommon.attack_value.ToString(), true);
            foreach (string key in GetAllIcons.icons.Keys)
            {
                if (GetAllIcons.icons[key].Equals(icon2))
                {
                    msg.old_treasure = key;
                    mycommon.attack_value -= mycommon.name_value[msg.old_treasure];
                    AttackValue.SetText(mycommon.attack_value.ToString(), true);
                        tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
                        tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
                        mycommon.name_status_count[msg.old_treasure] = tmp;
                        break;    //退出循环
                }
            }

            button2.onClick.AddListener(delegate ()
            {
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                if (mycommon.name_attribute[msg.new_treasure] == "equipment")
                {
                    string attribute_name = "装备";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else if (mycommon.name_attribute[msg.new_treasure] == "tool")
                {
                    string attribute_name = "工具";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else
                {
                    string attribute_name = "配饰";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                Value.SetText(mycommon.name_value[msg.new_treasure].ToString(), true);
                //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
            });

            msg.treasure_attribute = "equipment";     //方便修改player表的属性值
            msg.treasure_value = mycommon.attack_value;

        }
        else if(treasure_category == "ring")
        {
            button2 = rin.GetComponent<Button>();
            icon2 = button2.image.sprite;
            button2.image.sprite = GetAllIcons.icons[msg.new_treasure];

            mycommon.luck_value += mycommon.name_value[msg.new_treasure];
            LuckValue.SetText(mycommon.luck_value.ToString(), true);

            foreach (string key in GetAllIcons.icons.Keys)
            {
                if (GetAllIcons.icons[key].Equals(icon2))
                {
                    msg.old_treasure = key;
                    mycommon.luck_value -= mycommon.name_value[msg.old_treasure];
                    LuckValue.SetText(mycommon.luck_value.ToString(), true);
                        tmp.wear = mycommon.name_status_count[msg.old_treasure].wear - 1;
                        tmp.inventory = mycommon.name_status_count[msg.old_treasure].inventory + 1;
                        mycommon.name_status_count[msg.old_treasure] = tmp;
                        break;    //退出循环
                }
            }

            button2.onClick.AddListener(delegate ()
            {
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = icon;

                if (mycommon.name_attribute[msg.new_treasure] == "equipment")
                {
                    string attribute_name = "装备";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else if (mycommon.name_attribute[msg.new_treasure] == "tool")
                {
                    string attribute_name = "工具";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                else
                {
                    string attribute_name = "配饰";
                    Attribute.SetText(string.Format(attribute_name), true);
                }
                Value.SetText(mycommon.name_value[msg.new_treasure].ToString(), true);
                //GameObject.Find("HelmetImage").GetComponent<Image>().sprite = icon;
            });

            msg.treasure_attribute = "accessories";     //方便修改player表的属性值
            msg.treasure_value = mycommon.luck_value;

        }


        //需要判断Inventory是否为0
        else if (treasure_category == "elixir")                     //注意药水的处理方式！！  需要修改全部变量
                                                                    // 注意这里需要对inventory中的对应的进行删除，后端也需要进行删除
            {

                tmp.inventory = mycommon.name_status_count[msg.new_treasure].inventory;    //之前inventory已经减过1了
                tmp.wear = 0;  
                mycommon.name_status_count[msg.new_treasure] = tmp;


                mycommon.attack_value += mycommon.name_value[msg.new_treasure];
                AttackValue.SetText(mycommon.attack_value.ToString(), true);

                int count = mycommon.name_status_count[msg.new_treasure].wear + mycommon.name_status_count[msg.new_treasure].inventory;
                total_count.SetText(count.ToString(), true);
                treasure_name.SetText(msg.new_treasure, true);

                if (mycommon.name_status_count[msg.new_treasure].inventory == 0)
                {
                    msg.treasure_attribute = "elixir";
                    msg.treasure_value = mycommon.attack_value;
                    GameObject destroy = treasure_GameObject[msg.new_treasure];
                    Destroy(destroy);
                    treasure_GameObject.Remove(msg.new_treasure);
                    mycommon.name_attribute.Remove(msg.new_treasure);
                    mycommon.name_category.Remove(msg.new_treasure);
                    mycommon.name_status_count.Remove(msg.new_treasure);
                    mycommon.name_value.Remove(msg.new_treasure);
                }

            
                




            }

        MyNetwork.Send(msg);
    }

    }

    public void InitUI(PlayerController controller)
    {
        m_damageable = controller.GetComponent<Damageable>();
        m_controller = controller;

    }
}
