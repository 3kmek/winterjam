using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Converter : MonoBehaviour
{
    [SerializeField] List<GameObject> resources;
    [SerializeField] List<Product> products;
    [SerializeField] GameObject Garbage;
    int productNum=0;
    Dictionary<string,int> set = new Dictionary<string,int>();
    Dictionary<int,int> productSet = new Dictionary<int,int>();
    [SerializeField] Transform ProductSpawner;
    [SerializeField] bool isLeverDown = false;
    // Start is called before the first frame update
    void Start()
    {   int tempValue = 0;
        
        set.Add("paper",  0000000001);
        set.Add("plastic",0000000010);
        set.Add("fabric", 0000000100);
        set.Add("leather",0000001000);
        set.Add("paint",  0000010000);
        set.Add("metal",  0000100000);
        set.Add("wood",   0001000000);
        set.Add("cable",  0010000000);
        set.Add("coal",   0100000000);
        set.Add("glass",  1000000000);
        int i = 0;
        foreach (var item in products)
        {
            
            tempValue = 0;
            foreach (var item2 in item.Resources)
            {
                set.TryGetValue(item2.name, out int val);
                tempValue += val;
            }
            productSet.Add( tempValue,i );
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isLeverDown)
        {
            CreateProduct();
            isLeverDown = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            resources.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            resources.Remove(other.gameObject);
        }
    }
    
    void CreateProduct()
    {
        if (resources.Count != 0)
        {
            foreach (GameObject resource in resources) 
            {
                Debug.Log(resource.name);
                if(set.TryGetValue(resource.name, out int value))
                {
                    productNum += value;
                }
                Destroy(resource.gameObject);
            }
            resources.Clear();
            if(productSet.TryGetValue(productNum,out int index))
            {
                Instantiate(products[index], ProductSpawner.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(Garbage, ProductSpawner.transform.position, Quaternion.identity);
            }
        }
        

        
    }


    public void PullLever()
    {
        isLeverDown = true;
    }
}
