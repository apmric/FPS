using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public enum PoolFlag
{
    target,
    bullet,
    effect,
    hitEffect,
    shootEffect,
}

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Original
    {
        public GameObject obj;
        public int initCount = 50;
    }

    public Original[] originals;

    List<Queue<GameObject>> pools;

    void Awake()
    {
        pools = new List<Queue<GameObject>>();

        for (int index = 0; index < originals.Length; index++)
        {
            pools.Add(new Queue<GameObject>());

            for (int i = 0; i < originals[index].initCount; i++)
            {
                pools[index].Enqueue(CreatObject(originals[index].obj));
            }
        }
    }

    private GameObject CreatObject(GameObject obj)
    {
        GameObject temp = GameObject.Instantiate(obj, this.transform);
        temp.gameObject.SetActive(false);
        return temp;
    }

    public GameObject GetPool(PoolFlag flag)
    {
        int index = (int)flag;

        GameObject temp = null;

        if (pools[index].Count == 0)
            temp = CreatObject(originals[index].obj);
        else
            temp = pools[index].Dequeue();

        temp.gameObject.SetActive(true);

        return temp;
    }

    public void SetPool(PoolFlag flag, GameObject obj)
    {
        int index = (int)flag;

        obj.gameObject.SetActive(false);

        pools[index].Enqueue(obj);
    }
}