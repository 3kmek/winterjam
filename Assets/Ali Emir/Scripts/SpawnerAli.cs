using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAli : MonoBehaviour
{
    [SerializeField] GameObject[] meats;
    int spawnedMeat = 0;
    int i = 1;
    [SerializeField] GameObject[] matters;
    [SerializeField] public GameObject belt;
    [SerializeField] private float RaySpeed;

    [SerializeField] int PaperRate = 0;
    [SerializeField] int PlasticRate = 0;
    [SerializeField] int FabricRate = 0;
    [SerializeField] int LeatherRate = 0;
    [SerializeField] int PaintRate = 0;
    [SerializeField] int MetalRate = 0;
    [SerializeField] int WoodRate = 0;
    [SerializeField] int CableRate = 0;
    [SerializeField] int CoalRate = 0;
    [SerializeField] int GlassRate = 0;

    int total;
    float hedefZaman;
    public float Cooldown = 2f;

   void Start()
    {
        total = PaperRate + PlasticRate + FabricRate + LeatherRate + PaintRate + MetalRate + WoodRate + CableRate + CoalRate + GlassRate;
        belt = GameObject.FindWithTag("Belt");
        
    }

    void Update()
    {
        RaySpeed = belt.GetComponent<ConveyorBelt>().RaySpeed;
        if (RaySpeed > 0)
        {
            
            
            if (spawnedMeat < meats.Length && i%9==0)
            {
                i++;
                
                Instantiate(meats[spawnedMeat], transform.position, Quaternion.identity);
                spawnedMeat++;
            }
            else if (hedefZaman < Time.time)
            {   i++;
                Spawn();
                hedefZaman = Time.time + Cooldown;
            }
            Debug.Log(i);
            Debug.Log(spawnedMeat);
        }
    }

    void Spawn()
    {
        int random = Random.Range(0, total+1);
        if (random < PaperRate)
        {
            Spawn("paper");
            return;
        }
        random -= PaperRate;
        if (random < PlasticRate)
        {
            Spawn("plastic");
            return;
        }
        random -= PlasticRate;
        if (random < FabricRate)
        {
            Spawn("fabric");
            return;
        }
        random -= FabricRate;
        if(random < LeatherRate)
        {
            Spawn("leather");
            return;
        }
        random -= LeatherRate;
        if(random < PaintRate)
        {
            Spawn("paint");
            return;
        }
        random -= PaintRate;
        if(random < MetalRate)
        {
            Spawn("metal");
            return;
        }
        random -= MetalRate;
        if (random < WoodRate)
        {
            Spawn("wood");
            return;
        }
        random -= WoodRate;
        if (random < CableRate)
        {
            Spawn("cable");
            return;
        }
        if (random < CoalRate)
        {
            Spawn("coal");
            return;
        }
        random -= CoalRate;
        if (random < GlassRate) 
        {
            Spawn("glass");
            return;
        }
        random -= GlassRate;
        
        Debug.Log("spawn failed");
       
    }

    void Spawn(string obj)
    {
        GameObject o;
        switch (obj)
        {
            case "paper":
                o=Instantiate(matters[0],transform.position,Quaternion.identity);
                o.name = obj;
                break;
            case "plastic":
                o = Instantiate(matters[1], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "fabric":
                o = Instantiate(matters[2], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "leather":
                o = Instantiate(matters[3], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "paint":
                o = Instantiate(matters[4], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "metal":
                o = Instantiate(matters[5], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "wood":
                o = Instantiate(matters[6], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "cable":
                o = Instantiate(matters[7], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "coal":
                o = Instantiate(matters[8], transform.position, Quaternion.identity);
                o.name = obj;
                break;
            case "glass":
                o = Instantiate(matters[9], transform.position, Quaternion.identity);
                o.name = obj;
                break;
             default:
                Debug.Log("oh noooo");
                break;
        }
    }
}