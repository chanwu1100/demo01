﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class DefaultItemTableData
{
    public int id; //ID
    public int itemid; //英雄id
    public int type;//类型，1为英雄，需要读HeroTableData；2为道具，需要读ItemTableData
    public int masterId;//如果是装备，这个值填写英雄id(唯一标识)
}
public class HeroTableData
{
    public int id;               //ID
    public string name;              //名字
    public string des;              //描述
    public string icon;              //图标
    public string heroPrefab;            //英雄预制体
    public int hp;// 初始血量
    public int attack;//初始物理攻击力
    public int defene;//初始防御
    public int magic;//魔法攻击
    public int magicDef;//魔法抗性
    public int speed;//出手速度
    public int technique;//技巧，影响命中率和暴击
    public int isCanMove;//是否可以移动
    public int equipType;//武器类型限制
    public float searchRadius;//攻击敌人的搜索半径
    public float attackSpeed;//攻击频率
    public float moveSpeed;//移动速度
    public int skillid;
    public int heroJob;//职业
    public int heroQuality;//资质
    public int heroSex;//性别
    public int heroHair;//头发
    public int heroBeard;//胡子
    public int heroBody;//形象
};
public class EnemyTableData
{
    public int id;               //ID
    public string name;              //名字
    public string des;              //描述
    public string icon;              //图标
    public string enemyPrefab;            //预制体
    public int hp;// 初始血量
    public int attack;//初始物理攻击力
    public int defene;//初始防御
    public int magic;//魔法攻击
    public int isCanMove;//是否可以移动
    public int equipType;//武器类型限制
    public float searchRadius;//攻击敌人的搜索半径
    public float attackSpeed;//攻击频率
    public float moveSpeed;//移动速度
    public int skillid;//自带技能
    public int isUnarmed;//是否徒手攻击
    public int leftWeapon;//左手武器
    public int rightWeapon;//右手武器
    public int backWeapon;//背部装备
    public int isBoss;//是不是boss
    public string bossEffect;//boss特效
};
public class ItemTableData
{
    public int id;               //ID
    public string name;              //名字
    public string des;              //描述
    public string itemPrefab;//预制体
    public string icon;              //图标
    public int group;            //分组
    public string groupName;         //组名称
    public int damaged;        //初始伤害值
    public int defene;     //初始防御值
    public float attackRadius;        //攻击距离
    public float attackSpeed;     //攻击频率
    public int isBomb;        //是否有子弹
    public string pointParticle;         //攻击口特效
    public string moveParticle;         //移动特效
    public string hitParticle;         //击中特效
    public float bombMoveSpeed;//子弹移动速度
    public int bombCount;//一次攻击几发子弹
    public int quality;//资质
    public int animationId;//装备对应动作ID（如果是武器的话）

};
public class AnimationTableData
{
    public int id;                         // 不可重置（归零再加），只能增长
    public string Idle;                    // 待机动作
    public string Walk;                    // 跑动动作
    public string Run;                 // 跑动动作
    public string Attack;                  // 普攻动作
    public string Hit;                 // 被击打动作
    public string Die;                 // 死亡动作
    public string Stunned;                 // 被晕住动作
    public string Victory;					// 待机动作
};
public class DIYTableData
{
    public int id;                         // 不可重置（归零再加），只能增长
    public string name;                    // 名字
    public string prefab;                  // 预制体
    public int sex;                    // 性别 0为女性 1位男性
    public int job;                    // 职业 0射手 1战士 2法师 3牧师 4刺客 -1不是职业预制体，可能是头发或者胡须
    public int part;					// 如果job为-1，需要这个字段判断是哪个部位 0为头发 1为胡须
    public int dummyProp;					// 如果job为-1，需要这个字段判断添加到dummyProp
};
public class ChapterTableData
{
    public int id;                         // 不可重置（归零再加），只能增长
    public int mapId;                  // 地图ID
    public string mapName;                 // 地图名称
    public int subId;                  // 小关ID，小关没有名称，直接用<地图名称+subId>来表示
    public int isBoss;                 // 是否为Boss关
    public string monsters;                    // 怪物们儿，使用下划线_分割开，如果是Boss，第一个为Boss的id
    public string monsterAddRate;      // 怪物在初始属性上的加成比例,比如10，则表示加成比率为10%，初始血量了100，则加成后为110，用string为了方便扩展
    public int newMonster;                 // 需要介绍的新怪物id
    public string drops;                   // 物品掉落列表，使用下划线_分割开。
    public int reserve1;                   // 保留字段，方便扩展
    public int reserve2;                   // 保留字段，方便扩展
    public string reserve3;                    // 保留字段，方便扩展
    public string reserve4;					// 保留字段，方便扩展
};

//public class ConfigTableData
//{
//    public string key;                         // key
//    public string value;                   // 值
//    public string info;					// 说明
//};
public enum TableDataName
{
    ConfigTableData,
    DefaultItemTableData,
    ItemTableData,
    HeroTableData,
    EnemyTableData,
    AnimationTableData,
    ItemTableDataOld,
    ChapterTableData,
    DIYTableData
}
public enum ItemQuality
{
    Black = 1,
    Green,
    Blue,
    Purple,
    Yellow,
    Red

}
[Serializable]
public enum HeroJob
{
    Archer,//射手
    Warrior,//战士
    Mage,//法师
    Priest,//牧师
    Assassin,//刺客
    NULL
}
[Serializable]
public enum HeroPart
{
    Hair,//头发
    Beard,//胡子
    Body,//身体
    NULL
}
[Serializable]
public enum HeroQuality
{
    B,
    A,
    S,
    SS,
    SSR,
    NULL
}
[Serializable]
public enum HeroSex
{
    Female,//女性
    Male,//男性
    NULL
}
public class DataManager
{
    public Dictionary<string, string> ConfigMap = new Dictionary<string, string>();
    public Dictionary<int, ItemTableData> ItemTableDataDic = new Dictionary<int, ItemTableData>();
    public Dictionary<int, HeroTableData> HeroTableDataDic = new Dictionary<int, HeroTableData>();
    public Dictionary<int, EnemyTableData> EnemyTableDataDic = new Dictionary<int, EnemyTableData>();
    public Dictionary<int, DefaultItemTableData> DefaultItemTableDataDic = new Dictionary<int, DefaultItemTableData>();
    public Dictionary<int, AnimationTableData> AnimationTableDataDic = new Dictionary<int, AnimationTableData>();
    public Dictionary<int, ItemTableData> ItemTableDataOldDic = new Dictionary<int, ItemTableData>();
    public Dictionary<int, ChapterTableData> ChapterTableDataDic = new Dictionary<int, ChapterTableData>();
    public Dictionary<int, DIYTableData> DIYTableDataDic = new Dictionary<int, DIYTableData>();
    public AssetBundle assetBundlePrefabs;
    public AssetBundle assetBundleStatic;
    public AssetBundle assetBundleUI;
    public AssetBundle assetBundleMaterial;
    private GameData GD;
    public static readonly DataManager instance = new DataManager();
    public static DataManager GetInstance()//单例
    {
        return instance;
    }
    public DataManager()
    {
        //CreateItemTableData();
        //CreateDIYTableData("Assets/Little Heroes Mega Pack/Prefabs/01 Choose Costume", ".prefab");
        assetBundlePrefabs = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/prefab");
        assetBundleStatic = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/staticdata");
        assetBundleUI = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/ui");
        assetBundleMaterial = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/material");
        InitItemTableDataOld();
        InitItemTableData();
        InitHeroTableData();
        InitEnemyTableData();
        InitAnimationTableData();
        InitChapterTableData();
        InitDIYTableData();
        InitConfigTableData();


        //初始化英雄，可以读取本地数据，或者服务器发来的数据
        LoadByBin();
        if (GD == null)//说明第一次启动，需要读取初始的英雄信息，最好配置表
        {
            GD = new GameData();
            int teamposition = 0;
            long startid = long.Parse(System.DateTime.Now.ToString("yyyyMMddhhmmss"));
            foreach (KeyValuePair<int, DefaultItemTableData> pair in DefaultItemTableDataDic)
            {
                //if (HeroTableDataDic.ContainsKey(pair.Value.itemid))
                {
                    if (pair.Value.type == 2)//如果是装备
                    {
                        ItemTableData itemTableData = ItemTableDataDic[pair.Value.itemid];
                        Item item = new Item
                        {
                            id = startid + pair.Key,
                            itemId = pair.Value.itemid,
                            masterId = pair.Value.masterId,
                            itemLevel = 1
                        };
                        GD.Items.Add(item.id, item);
                    }
                    else if (pair.Value.type == 1) {
                        HeroTableData heroTableData = HeroTableDataDic[pair.Value.itemid];
                        Hero hero = new Hero
                        {
                            id = RandomHeroManager.instance.GetRandomId(),
                            teamPosition = 0,
                            heroLevel = 1,
                            heroJob = (HeroJob)heroTableData.heroJob,
                            heroQuality = (HeroQuality)heroTableData.heroQuality,
                            heroSex = (HeroSex)heroTableData.heroSex

                        };
                        hero.heroPartDic[HeroPart.Body] = heroTableData.heroBody;
                        hero.heroPartDic[HeroPart.Hair] = heroTableData.heroHair;
                        hero.heroPartDic[HeroPart.Beard] = heroTableData.heroBeard;
                        teamposition++;
                        GD.Heroes.Add(hero.id, hero);
                    }

                }
            }
            SaveByBin();//保存下
        }
        CreateItem();



        foreach (KeyValuePair<long, Item> item in GD.Items)
        {
            if (item.Value.masterId > 0)//有持有者
            {
                if (GD.Heroes.ContainsKey(item.Value.masterId))//如果有这个持有者
                {
                    Hero hero = GD.Heroes[item.Value.masterId];
                    ItemTableData itemTableData = GetItemTableDataByItemId(item.Value.itemId);
                    if (itemTableData != null)
                    {
                        hero.dummyPropDic[(DummyProp)itemTableData.group] = item.Value.id;
                    }

                }
            }
        }


    }
    public void CreateItem()
    {
        foreach (KeyValuePair<int,ItemTableData> pair in ItemTableDataDic)
        {
            ItemTableData itemTableData = pair.Value;
            Item item = new Item
            {
                id = pair.Key + 10000,
                itemId = pair.Value.id,
                masterId = 0,
                itemLevel = 1
            };
            if (!GD.Items.ContainsKey(item.id))
            {
                GD.Items.Add(item.id, item);
            }
            
        }
    }
    public void CreateItemTableData()
    {
        Dictionary<DummyProp, List<string>> names = GetFileNameByPath("Assets/Little Heroes Mega Pack/Prefabs", ".prefab");
        
        //创建一个文件流
        string dir = Application.persistentDataPath;
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
        //FileStream fileStream = File.Create(dir + "/ItemTableData.csv");

        using (FileStream fsWrite = new FileStream(dir + "/ItemTableData.csv", FileMode.Append))
        {
            string msg1 = "int,string,string,string,string,int,string,int,int,float,float,int,string,string,string,float,int\n";
            byte[] myByte1 = System.Text.Encoding.UTF8.GetBytes(msg1);
            fsWrite.Write(myByte1, 0, myByte1.Length);

            string msg2 = "ID,名字,描述,预制体,图标,分组,组名称,初始伤害值,初始防御值,攻击距离,攻击频率,是否有子弹,攻击口特效,移动特效,击中特效,子弹移动速度,一次攻击几发子弹\n";
            byte[] myByte2 = System.Text.Encoding.UTF8.GetBytes(msg2);
            fsWrite.Write(myByte2, 0, myByte2.Length);

            string msg3 = "id,name,des,itemPrefab,icon,group,groupName,damaged,defene,attackRadius,attackSpeed,isBomb,pointParticle,moveParticle,hitParticle,bombMoveSpeed,bombCount,quality,animationId\n";
            byte[] myByte3 = System.Text.Encoding.UTF8.GetBytes(msg3);
            fsWrite.Write(myByte3, 0, myByte3.Length);
            int id = 1;
            foreach (KeyValuePair<DummyProp, List<string>> sub in names)
            {
                for (int i = 0; i < sub.Value.Count; i++)
                {
                    int group = (int)sub.Key;
                    string msg = id.ToString() + "," + sub.Value[i] + ",这是" + sub.Value[i] + "," + sub.Value[i] + "," + sub.Value[i] +
                        "," + group.ToString() +
                        "," + sub.Key.ToString() +
                        ",15,0,25,0.5,1,0,0,0,1,1," + GetQuality(sub.Value[i]).ToString()+ "," + GetAnimationId(sub.Value[i]).ToString() + "\n";
                    //if (sub.Value.Count-1 != i)
                    //{
                    //    msg += "\n";
                    //}
                    byte[] myByte = System.Text.Encoding.UTF8.GetBytes(msg);
                    fsWrite.Write(myByte, 0, myByte.Length);
                    id++;
                }
            }


        };

    }
    public void CreateDIYTableData(string path, string format)
    {
        Dictionary<HeroJob, List<string>> names = GetFileNameByPathForDIY(path, format);
        Dictionary<HeroPart, List<string>> names2 = GetFileNameByPathForDIY2("Assets/Little Heroes Mega Pack/Prefabs", ".prefab");
        //创建一个文件流
        string dir = Application.persistentDataPath;
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
        //FileStream fileStream = File.Create(dir + "/ItemTableData.csv");

        using (FileStream fsWrite = new FileStream(dir + "/DIYTableData.csv", FileMode.Append))
        {
            string msg1 = "int,string,string,int,int,int,int\n";
            byte[] myByte1 = System.Text.Encoding.UTF8.GetBytes(msg1);
            fsWrite.Write(myByte1, 0, myByte1.Length);

            string msg2 = "不可重置（归零再加），只能增长,名字,预制体,性别 0为女性 1位男性,职业 0射手 1战士 2法师 3牧师 4刺客 -1不是职业预制体，可能是头发或者胡须,如果job为-1，需要这个字段判断是哪个部位 0为头发 1为胡须,如果job为-1，需要这个字段判断添加到dummyProp\n";
            byte[] myByte2 = System.Text.Encoding.UTF8.GetBytes(msg2);
            fsWrite.Write(myByte2, 0, myByte2.Length);

            string msg3 = "id,name,prefab,sex,job,part,dummyProp\n";
            byte[] myByte3 = System.Text.Encoding.UTF8.GetBytes(msg3);
            fsWrite.Write(myByte3, 0, myByte3.Length);
            int id = 1;
            foreach (KeyValuePair<HeroJob, List<string>> sub in names)
            {
                for (int i = 0; i < sub.Value.Count; i++)
                {
                    int group = (int)sub.Key;
                    string msg = id.ToString() + "," + sub.Value[i]  + "," + sub.Value[i] + "," + GetSex(sub.Value[i]).ToString() +"," + group.ToString() +
                        "," + GetPart(sub.Value[i]).ToString() + "," + GetDummyProp(sub.Value[i]).ToString() + "\n";
                    //if (sub.Value.Count-1 != i)
                    //{
                    //    msg += "\n";
                    //}
                    byte[] myByte = System.Text.Encoding.UTF8.GetBytes(msg);
                    fsWrite.Write(myByte, 0, myByte.Length);
                    id++;
                }
            }
            foreach (KeyValuePair<HeroPart, List<string>> sub in names2)
            {
                for (int k = 0; k < sub.Value.Count; k++)
                {
                    int group = (int)sub.Key;
                    string msg = id.ToString() + "," + sub.Value[k] + "," + sub.Value[k] + "," + GetSex(sub.Value[k]).ToString() + ",-1"+
                        "," + GetPart(sub.Value[k]).ToString() + "," + GetDummyProp(sub.Value[k]).ToString()+ "\n";
                    //if (sub.Value.Count-1 != i)
                    //{
                    //    msg += "\n";
                    //}
                    byte[] myByte = System.Text.Encoding.UTF8.GetBytes(msg);
                    fsWrite.Write(myByte, 0, myByte.Length);
                    id++;
                }
            }


        };
    }
    public int GetSex(string name)
    {
        if (name.Contains("Male"))
        {
            return 1;
        }
        if (name.Contains("Female"))
        {
            return 0;
        }
        if (name.Contains("Beard"))
        {
            return 1;
        }
        return -1;
    }
    public int GetPart(string name)
    {
        if (name.Contains("Beard"))
        {
            return 1;
        }
        if (name.Contains("Hair"))
        {
            return 0;
        }
        return -1;
    }
    public int GetDummyProp(string name)
    {
        if (name.Contains("Beard"))
        {
            return (int)DummyProp.Head;
        }
        if (name.Contains("Hair"))
        {
            return (int)DummyProp.Head;
        }
        return -1;
    }
    public int GetQuality(String itemname)
    {
        ItemQuality quality = ItemQuality.Black;
        if (itemname.Contains("Green"))
        {
            quality = ItemQuality.Green;
        }
        if (itemname.Contains("Bule"))
        {
            quality = ItemQuality.Blue;
        }
        if (itemname.Contains("Purple"))
        {
            quality = ItemQuality.Purple;
        }
        if (itemname.Contains("Yellow"))
        {
            quality = ItemQuality.Yellow;
        }
        if (itemname.Contains("Red"))
        {
            quality = ItemQuality.Red;
        }
        return (int)quality;
    }
    public int GetAnimationId(String itemname)
    {
        int animationId =1;
        if (itemname.Contains("Wand"))
        {
            animationId = 5;
        }
        if (itemname.Contains("Sword"))
        {
            animationId = 4;
        }
        if (itemname.Contains("Axe") || itemname.Contains("Mace") || itemname.Contains("Scythe"))
        {
            animationId = 3;
        }
        if (itemname.Contains("Spear"))
        {
            animationId = 2;
        }
        if (itemname.Contains("Crossbow"))
        {
            animationId = 8;
        }
        if (itemname.Contains("TH Axe") || itemname.Contains("TH Sword"))
        {
            animationId = 6;
        }
        if (itemname.Contains("Longbow"))
        {
            animationId = 7;
        }
        return animationId;
    }
    private void InitItemTableDataOld()
    {
        string[][] arrAll = GetData(TableDataName.ItemTableDataOld.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);

            ItemTableData itemTableData = new ItemTableData
            {
                id = id,
                name = arr[1],
                des = arr[2],
                itemPrefab = arr[3],
                icon = arr[4],
                group = int.Parse(arr[5]),
                groupName = arr[6],
                damaged = int.Parse(arr[7]),
                defene = int.Parse(arr[8]),
                attackRadius = float.Parse(arr[9]),
                attackSpeed = float.Parse(arr[10]),
                isBomb = int.Parse(arr[11]),
                pointParticle = arr[12],
                moveParticle = arr[13],
                hitParticle = arr[14],
                bombMoveSpeed = float.Parse(arr[15]),
                bombCount = int.Parse(arr[16]),
                quality = int.Parse(arr[17]),
                animationId = int.Parse(arr[18])
            };
            ItemTableDataOldDic[id] = itemTableData;
        }
    }
    private void InitItemTableData()
    {
        string[][] arrAll = GetData(TableDataName.ItemTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);

            ItemTableData itemTableData = new ItemTableData
            {
                id = id,
                name = arr[1],
                des = arr[2],
                itemPrefab = arr[3],
                icon = arr[4],
                group = int.Parse(arr[5]),
                groupName = arr[6],
                damaged = int.Parse(arr[7]),
                defene = int.Parse(arr[8]),
                attackRadius = float.Parse(arr[9]),
                attackSpeed = float.Parse(arr[10]),
                isBomb = int.Parse(arr[11]),
                pointParticle = arr[12],
                moveParticle = arr[13],
                hitParticle = arr[14],
                bombMoveSpeed = float.Parse(arr[15]),
                bombCount = int.Parse(arr[16]),
                quality = int.Parse(arr[17]),
                animationId = int.Parse(arr[18])
            };
            ItemTableDataDic[id] = itemTableData;
        }
    }
    private void InitHeroTableData()
    {
        string[][] arrAll = GetData(TableDataName.HeroTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);
            HeroTableData tableData = new HeroTableData
            {
                id = id,
                name = arr[1],
                des = arr[2],
                icon = arr[3],
                heroPrefab = arr[4],
                hp = int.Parse(arr[5]),
                attack = int.Parse(arr[6]),
                defene = int.Parse(arr[7]),
                magic = int.Parse(arr[8]),
                magicDef = int.Parse(arr[9]),
                speed = int.Parse(arr[10]),
                technique = int.Parse(arr[11]),
                isCanMove = int.Parse(arr[12]),
                equipType = int.Parse(arr[13]),
                searchRadius = float.Parse(arr[14]),
                attackSpeed = float.Parse(arr[15]),
                moveSpeed = float.Parse(arr[16]),
                skillid = int.Parse(arr[17]),
                heroJob = int.Parse(arr[18]),//职业
                heroQuality = int.Parse(arr[19]),//资质
                heroSex = int.Parse(arr[20]),//性别
                heroHair = int.Parse(arr[21]),//头发
                heroBeard = int.Parse(arr[22]),//胡子
                heroBody = int.Parse(arr[23])//形象
            };
            HeroTableDataDic[id] = tableData;
        }
        /////////////////////////
        arrAll = GetData(TableDataName.DefaultItemTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);
            DefaultItemTableData tableData = new DefaultItemTableData
            {
                id = id,
                itemid = int.Parse(arr[1]),
                type = int.Parse(arr[2]),
                masterId = int.Parse(arr[3])
            };
            DefaultItemTableDataDic[id] = tableData;
        }
    }
    private void InitEnemyTableData()
    {
        string[][] arrAll = GetData(TableDataName.EnemyTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);
            EnemyTableData tableData = new EnemyTableData
            {
                id = id,
                name = arr[1],
                des = arr[2],
                icon = arr[3],
                enemyPrefab = arr[4],
                hp = int.Parse(arr[5]),
                attack = int.Parse(arr[6]),
                defene = int.Parse(arr[7]),
                magic = int.Parse(arr[8]),
                isCanMove = int.Parse(arr[9]),
                equipType = int.Parse(arr[10]),
                searchRadius = float.Parse(arr[11]),
                attackSpeed = float.Parse(arr[12]),
                moveSpeed = float.Parse(arr[13]),
                skillid = int.Parse(arr[14]),
                isUnarmed = int.Parse(arr[15]),
                leftWeapon = int.Parse(arr[16]),
                rightWeapon = int.Parse(arr[17]),
                backWeapon = int.Parse(arr[18]),
                isBoss = int.Parse(arr[19]),
                bossEffect = arr[20]
            };
            EnemyTableDataDic[id] = tableData;
        }
    }
    public void InitAnimationTableData()
    {
        string[][] arrAll = GetData(TableDataName.AnimationTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);
            AnimationTableData tableData = new AnimationTableData
            {
                id = id,
                Idle = arr[1],
                Walk = arr[2],
                Run = arr[3],
                Attack = arr[4],
                Hit = arr[5],
                Die = arr[6],
                Stunned = arr[7],
                Victory = arr[8]
            };
            AnimationTableDataDic[id] = tableData;
        }
    }
    public void InitDIYTableData()
    {
        string[][] arrAll = GetData(TableDataName.DIYTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);
            DIYTableData tableData = new DIYTableData
            {
                id = id,
                name = arr[1],
                prefab = arr[2],
                sex = int.Parse(arr[3]),
                job = int.Parse(arr[4]),
                part = int.Parse(arr[5]),
                dummyProp = int.Parse(arr[6])
            };
            DIYTableDataDic[id] = tableData;
        }
    }
    public void InitConfigTableData()
    {
        string[][] arrAll = GetData(TableDataName.ConfigTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            ConfigMap[arr[0]] = arr[1];
        }
    }
    public void InitChapterTableData()
    {
        string[][] arrAll = GetData(TableDataName.ChapterTableData.ToString());
        for (int i = 0; i < arrAll.Length; i++)
        {
            string[] arr = arrAll[i];
            int id = int.Parse(arr[0]);
            ChapterTableData tableData = new ChapterTableData
            {
                id = id,
                mapId = int.Parse(arr[1]),
                mapName = arr[2],
                subId = int.Parse(arr[3]),
                isBoss = int.Parse(arr[4]),
                monsters = arr[5],
                monsterAddRate = arr[6],
                newMonster = int.Parse(arr[7]),
                drops = arr[8],
                reserve1 = int.Parse(arr[9]),
                reserve2 = int.Parse(arr[10]),
                reserve3 = arr[11],
                reserve4 = arr[12]
            };
            ChapterTableDataDic[id] = tableData;
        }
    }
    public int GetConfigValueToInt(string key)
    {
        return int.Parse(ConfigMap[key]);
    }
    public float GetConfigValueToFloat(string key)
    {
        return float.Parse(ConfigMap[key]);
    }
    public string GetConfigValueToString(string key)
    {
        return ConfigMap[key];
    }
    public ChapterTableData GetChapterTableDataById(int chapterid)
    {
        if (ChapterTableDataDic.ContainsKey(chapterid))
        {
            return ChapterTableDataDic[chapterid];
        }
        return null;
    }
    public HeroTableData GetHeroTableDataByHeroId(int heroid)
    {
        if (HeroTableDataDic.ContainsKey(heroid))
        {
            return HeroTableDataDic[heroid];
        }
        return null;
    }
    public ItemTableData GetItemTableDataByItemId(int itemid)
    {
        if (ItemTableDataDic.ContainsKey(itemid))
        {
            return ItemTableDataDic[itemid];
        }
        return null;
    }
    public ItemTableData GetItemTableDataByItemName(string name)
    {
        ItemTableData itemTableData = null;
        foreach (KeyValuePair<int,ItemTableData> item in ItemTableDataOldDic)
        {
            if(item.Value.name == name)
            {
                itemTableData = item.Value;
                break;
            }
        }
        return itemTableData;
    }
    public HeroTableData GetHeroTableDataByHero(Hero hero)
    {
        //if (HeroTableDataDic.ContainsKey(hero.heroId))
        //{
        //    return HeroTableDataDic[hero.heroId];
        //}
        return null;
    }
    public HeroTableData NewHeroByHeroTableData(HeroTableData heroTableData)
    {
        Hero hero = new Hero
        {
            //heroId = heroTableData.id,
            teamPosition = -1,
            heroLevel = 1

        };
        return null;
    }
    public ItemTableData GetItemTableDataByItem(Item item)
    {
        if (ItemTableDataDic.ContainsKey(item.itemId))
        {
            return ItemTableDataDic[item.itemId];
        }
        return null;
    }
    public AnimationTableData GetAnimationTableDataById(int id)
    {
        if (AnimationTableDataDic.ContainsKey(id))
        {
            return AnimationTableDataDic[id];
        }
        return null;
    }
    public DIYTableData GetDIYTableDatasById(int diyId)
    {
        if (DIYTableDataDic.ContainsKey(diyId))
        {
            return DIYTableDataDic[diyId];
        }
        return null;
    }
    public List<DIYTableData> GetDIYTableDatasByHeroJobAndSex(HeroJob heroJob, HeroSex sex)
    {
        List<DIYTableData> dIYTableDatas = new List<DIYTableData>();
        foreach (KeyValuePair<int,DIYTableData> item in DIYTableDataDic)
        {
            if (item.Value.job == (int)heroJob && item.Value.sex == (int)sex)
            {
                dIYTableDatas.Add(item.Value);
            }
        }
        return dIYTableDatas;
    }
    public List<DIYTableData> GetDIYTableDatasByHeroPartAndSex(HeroPart heroPart, HeroSex sex)
    {
        List<DIYTableData> dIYTableDatas = new List<DIYTableData>();
        foreach (KeyValuePair<int, DIYTableData> item in DIYTableDataDic)
        {
            if (item.Value.part == (int)heroPart && item.Value.sex == (int)sex)
            {
                dIYTableDatas.Add(item.Value);
            }
        }
        return dIYTableDatas;
    }
    private string[][] GetData(string path, string _split= "\r\n", int fromIndex = 3)
    {
        //path = "StaticData/" + path + ".csv";
        string[][] data;  //读取csv二进制文件   
        TextAsset binAsset = assetBundleStatic.LoadAsset(path, typeof(TextAsset)) as TextAsset;// Resources.Load (path, typeof(TextAsset)) as TextAsset;
        if (binAsset != null) {   //读取每一行的内容     
            string[] lineArray = binAsset.text.Split (_split.ToCharArray (), StringSplitOptions.RemoveEmptyEntries);
            //创建二维数组     
            data = new string [lineArray.Length - fromIndex][];
            //把csv中的数据储存在二位数组中     
            int index = 0;
            for (int i = fromIndex; i < lineArray.Length; i++) {
                data [index] = lineArray [i].Split (',');
                index++;
            }
        } else
        {
            data = new string [0][];
        }
        return data;
    }
    public GameObject CreateGameObjectFromAssetsBundle(string path,string name)
    {
        GameObject DBobj;
        //3、资源加载的第三种方式，使用AssetBundle加载的方式加载(常用方式)
        DBobj = GameObject.Instantiate(assetBundlePrefabs.LoadAsset<GameObject>(name));
        return DBobj;
    }
    public Sprite CreateSpriteFromAssetsBundle(string path, string name)
    {
        Sprite sprite = null;
        //3、资源加载的第三种方式，使用AssetBundle加载的方式加载(常用方式)
        Sprite load = assetBundleUI.LoadAsset<Sprite>(name);
        if(load != null)
        {
            sprite = GameObject.Instantiate(assetBundleUI.LoadAsset<Sprite>(name));
        }
        
        return sprite;
    }
    public Material CreateMaterialFromAssetsBundle(string path, string name)
    {
        Material material = null;
        //3、资源加载的第三种方式，使用AssetBundle加载的方式加载(常用方式)
        Material load = assetBundleMaterial.LoadAsset<Material>(name);
        if (load != null)
        {
            material = GameObject.Instantiate(assetBundleMaterial.LoadAsset<Material>(name));
        }

        return material;
    }
    public Dictionary<DummyProp, List<string>> GetFileNameByPath(string path, string format)
    {

        Dictionary<DummyProp, List<string>> names = new Dictionary<DummyProp, List<string>>();
        //1、获得当前运行程序的路径
        string rootPath = Directory.GetCurrentDirectory();
        //C#遍历指定文件夹中的所有文件 
        DirectoryInfo TheFolder = new DirectoryInfo(path);
        if (!TheFolder.Exists)
            return null;

        
        DirectoryInfo[] directoryInfos = TheFolder.GetDirectories();
        for (int i = 0; i < directoryInfos.Length; i++)
        {
            //FileInfo[] fileInfosAll = directoryInfos[i].GetFiles(directoryInfos[i].FullName, SearchOption.AllDirectories);
            DirectoryInfo[] directoryInfos2 = directoryInfos[i].GetDirectories();
            for (int k = 0; k < directoryInfos2.Length; k++)
            {
                FileInfo[] fileInfos = directoryInfos2[k].GetFiles();
                //遍历文件
                foreach (FileInfo NextFile in fileInfos)
                {
                    //if (NextFile.Name == "0-0-11.grid")
                    //    continue;
                    // 获取文件完整路径
                    //string heatmappath = NextFile.FullName;
                    DummyProp keyname = DummyProp.NULL;
                    if (NextFile.Directory.Name.Contains("(Back)"))
                    {
                        keyname = DummyProp.Back;
                    }
                    if (NextFile.Directory.Name.Contains("(Head)"))
                    {
                        keyname = DummyProp.Head;
                    }
                    if (NextFile.Directory.Name.Contains("(R Arm)"))
                    {
                        keyname = DummyProp.Right;
                    }
                    if (NextFile.Directory.Name.Contains("(L Arm)"))
                    {
                        keyname = DummyProp.Left;
                    }
                    if (NextFile.Directory.Name.Contains("(Main Prefab)"))
                    {
                        keyname = DummyProp.Chest;
                    }
                    if (NextFile.Directory.Name.Contains("(Both Arms)"))
                    {
                        keyname = DummyProp.Left;
                    }
                    if (keyname != DummyProp.NULL)
                    {
                        if (!names.ContainsKey(keyname))
                        {
                            names[keyname] = new List<string>();
                        }
                        if (format == NextFile.Extension)
                        {
                            string name = NextFile.Name.Replace(format, "").Trim();
                            if (!name.Contains("Beard") && !name.Contains("FX") && !name.Contains("Hand Aura"))
                            {
                                names[keyname].Add(name);
                            }
                            
                        }
                    }

                }
            }
        }
        
        return names;

    }
    public Dictionary<HeroJob, List<string>> GetFileNameByPathForDIY(string path, string format)
    {

        Dictionary<HeroJob, List<string>> names = new Dictionary<HeroJob, List<string>>();
        //1、获得当前运行程序的路径
        string rootPath = Directory.GetCurrentDirectory();
        //C#遍历指定文件夹中的所有文件 
        DirectoryInfo TheFolder = new DirectoryInfo(path);
        if (!TheFolder.Exists)
            return null;


        DirectoryInfo[] directoryInfos = TheFolder.GetDirectories();
        for (int i = 0; i < directoryInfos.Length; i++)
        {
            //FileInfo[] fileInfosAll = directoryInfos[i].GetFiles(directoryInfos[i].FullName, SearchOption.AllDirectories);
            DirectoryInfo[] directoryInfos2 = directoryInfos[i].GetDirectories();
            for (int k = 0; k < directoryInfos2.Length; k++)
            {
                FileInfo[] fileInfos = directoryInfos2[k].GetFiles();
                //遍历文件
                foreach (FileInfo NextFile in fileInfos)
                {
                    //if (NextFile.Name == "0-0-11.grid")
                    //    continue;
                    // 获取文件完整路径
                    //string heatmappath = NextFile.FullName;
                    HeroJob keyname = HeroJob.NULL;
                    if (NextFile.Directory.Name.Contains("Archer"))
                    {
                        keyname = HeroJob.Archer;
                    }
                    if (NextFile.Directory.Name.Contains("Knight"))
                    {
                        keyname = HeroJob.Warrior;
                    }
                    if (NextFile.Directory.Name.Contains("Long Dress") || NextFile.Directory.Name.Contains("Long Robe"))
                    {
                        keyname = HeroJob.Priest;
                    }
                    if (NextFile.Directory.Name.Contains("Sorceress") || NextFile.Directory.Name.Contains("Wizard"))
                    {
                        keyname = HeroJob.Mage;
                    }
                    if (NextFile.Directory.Name.Contains("Special"))
                    {
                        keyname = HeroJob.Assassin;
                    }
                    if (keyname != HeroJob.NULL)
                    {
                        if (!names.ContainsKey(keyname))
                        {
                            names[keyname] = new List<string>();
                        }
                        if (format == NextFile.Extension)
                        {
                            string name = NextFile.Name.Replace(format, "");
                            names[keyname].Add(name.Trim());
                        }
                    }

                }
            }
        }

        return names;

    }
    public Dictionary<HeroPart, List<string>> GetFileNameByPathForDIY2(string path, string format)
    {

        Dictionary<HeroPart, List<string>> names = new Dictionary<HeroPart, List<string>>();
        //1、获得当前运行程序的路径
        string rootPath = Directory.GetCurrentDirectory();
        //C#遍历指定文件夹中的所有文件 
        DirectoryInfo TheFolder = new DirectoryInfo(path);
        if (!TheFolder.Exists)
            return null;


        DirectoryInfo[] directoryInfos = TheFolder.GetDirectories();
        for (int i = 0; i < directoryInfos.Length; i++)
        {
            //FileInfo[] fileInfosAll = directoryInfos[i].GetFiles(directoryInfos[i].FullName, SearchOption.AllDirectories);
            DirectoryInfo[] directoryInfos2 = directoryInfos[i].GetDirectories();
            for (int k = 0; k < directoryInfos2.Length; k++)
            {
                FileInfo[] fileInfos = directoryInfos2[k].GetFiles();
                //遍历文件
                foreach (FileInfo NextFile in fileInfos)
                {
                    //if (NextFile.Name == "0-0-11.grid")
                    //    continue;
                    // 获取文件完整路径
                    //string heatmappath = NextFile.FullName;
                    HeroPart keyname = HeroPart.NULL;
                    if (NextFile.Directory.Name.Contains("Male"))
                    {
                        keyname = HeroPart.Hair;
                    }
                    if (NextFile.Directory.Name.Contains("Female"))
                    {
                        keyname = HeroPart.Hair;
                    }
                    if (NextFile.Directory.Name.Contains("Beards"))
                    {
                        keyname = HeroPart.Beard;
                    }
                
                    if (keyname != HeroPart.NULL)
                    {
                        if (!names.ContainsKey(keyname))
                        {
                            names[keyname] = new List<string>();
                        }
                        if (format == NextFile.Extension)
                        {
                            string name = NextFile.Name.Replace(format, "");
                            names[keyname].Add(name);
                        }
                    }

                }
            }
        }

        return names;

    }
    public List<GameObject> GetGameObjectsByPath(string path,string format)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        //1、获得当前运行程序的路径
        string rootPath = Directory.GetCurrentDirectory();
        //C#遍历指定文件夹中的所有文件 
        DirectoryInfo TheFolder = new DirectoryInfo(path);
        if (!TheFolder.Exists)
            return null;

        //遍历文件
        foreach (FileInfo NextFile in TheFolder.GetFiles())
        {
            //if (NextFile.Name == "0-0-11.grid")
            //    continue;
            // 获取文件完整路径
            //string heatmappath = NextFile.FullName;
            if(format == NextFile.Extension)
            {
                GameObject DBobj;
//#if UNITY_EDITOR
                //DBobj = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path + "/" + NextFile.Name));
                //DBobj = Instantiate(Resources.Load(path + "/" + NextFile.Name)) as GameObject;
//#endif
//#if UNITY_ANDROID || UNITY_IOS
                //3、资源加载的第三种方式，使用AssetBundle加载的方式加载(常用方式)
                AssetBundle assetBundleObj = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + NextFile.Name);
                DBobj = GameObject.Instantiate(assetBundleObj.LoadAsset<GameObject>(NextFile.Name));
                
//#endif
                if(DBobj != null)
                {
                    //gameObjects.Add(DBobj);
                }

            }
            
        }
        return gameObjects;
    }
    //二进制方法：存档
    public void SaveByBin()
    {
        //序列化过程（将Data对象转换为字节流）
        //创建对象并保存当前游戏状态
        //GameData data = new GameData();
        //创建一个二进制格式化程序
        BinaryFormatter bf = new BinaryFormatter();
        //创建一个文件流
        string dir = Application.persistentDataPath;
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
        FileStream fileStream = File.Create(dir + "/gameData.txt");
        //用二进制格式化程序的序列化方法来序列化Data对象,参数：创建的文件流和需要序列化的对象
        bf.Serialize(fileStream, GD);
        //关闭流
        fileStream.Close();

        //如果文件存在，则显示保存成功
        if (File.Exists(dir + "/gameData.txt"))
        {
            //UIManager._instance.ShowMessage("保存成功");
        }
    }

    //二进制方法：读档

    public void LoadByBin()
    {
        string dir = Application.persistentDataPath;
        if (File.Exists(dir + "/gameData.txt"))
        {
            //反序列化过程
            //创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            //打开一个文件流
            FileStream fileStream = File.Open(dir + "/gameData.txt", FileMode.Open);
            //调用格式化程序的反序列化方法，将文件流转换为一个Data对象
            fileStream.Position = 0;
            GD = (GameData)bf.Deserialize(fileStream);
            //关闭文件流
            fileStream.Close();
            //SetData(data);
        }
    }
    public GameData GetGameData()
    {
        return GD;
    }
    public Dictionary<long,Hero> GetHeroes(bool isSort = true)
    {
        if (isSort)
        {
            GD.Heroes = GD.Heroes.OrderBy(p => p.Value.heroQuality).ToDictionary(p => p.Key, p => p.Value);
            GD.Heroes = GD.Heroes.OrderBy(p => p.Value.teamPosition).ToDictionary(p => p.Key, p => p.Value);
        }
        return GD.Heroes;
    }
    public Hero GetHeroById(long heroid)
    {
        if (GD.Heroes.ContainsKey(heroid))
        {
            return GD.Heroes[heroid];
        }
        return null;
    }
    public Hero GetHeroByTeamPosition(int teamPosition)
    {
        Hero hero = null;
        foreach (KeyValuePair< long,Hero > item in GD.Heroes)
        {
            if(item.Value.teamPosition == teamPosition)
            {
                return item.Value;
            }
        }
        return null;
    }
    public void AddHeroToGameData(Hero hero)
    {
        GD.Heroes.Add(hero.id,hero);
        SaveByBin();
    }
}

//UNITY_EDITOR //UNITY编辑器
//UNITY_EDITOR_WIN Windows 操作系统.
//UNITY_EDITOR_OSX macos操作系统
//UNITY_STANDALONE_OSX 专门为macos（包括Universal, PPC，Intel architectures）平台的定义
//UNITY_STANDALONE_WIN    专门为windows平台的定义
//UNITY_STANDALONE_LINUX  专门为Linux平台的定义
//UNITY_STANDALONE    独立平台(Mac OS X, Windows or Linux).
//UNITY_WII WII 游戏机平台
//UNITY_IOS   iOS系统平台
//UNITY_IPHONE    iPhone
//UNITY_ANDROID   android系统平台
//UNITY_PS4   ps4平台
//UNITY_SAMSUNGTV 三星TV平台
//UNITY_XBOXONE   Xbox One 平台
//UNITY_TIZEN Tizen 平台
//UNITY_TVOS Apple TV 平台
//UNITY_WSA #define directive for Universal Windows Platform. Additionally, NETFX_CORE is defined when compiling C# files against .NET Core and using .NET scripting backend.
//UNITY_WSA_10_0 #define directive for Universal Windows Platform. Additionally WINDOWS_UWP is defined when compiling C# files against .NET Core.
//UNITY_WINRT //UNITY_WSA.
//UNITY_WINRT_10_0    //UNITY_WSA_10_0
//UNITY_WEBGL #define directive for WebGL.
//UNITY_FACEBOOK faceBook平台(WebGL or Windows standalone).
//UNITY_ADS 调用广告方法，版本 5.2 以后
//UNITY_ANALYTICS 调用//UNITY分析服务，版本5.2以后
//UNITY_ASSERTIONS    控制指令的过程
