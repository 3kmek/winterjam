using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAli : MonoBehaviour
{
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
            if (hedefZaman < Time.time)
            {
                Spawn();
                hedefZaman = Time.time + Cooldown;
            }
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
        random -= CableRate;
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
        switch (obj)
        {
            case "paper":
                Instantiate(matters[0],transform.position,Quaternion.identity);
                break;
            case "plastic":
                Instantiate(matters[1], transform.position, Quaternion.identity);
                break;
            case "fabric":
                Instantiate(matters[2], transform.position, Quaternion.identity);
                break;
            case "leather":
                Instantiate(matters[3], transform.position, Quaternion.identity);
                break;
            case "paint":
                Instantiate(matters[4], transform.position, Quaternion.identity);
                break;
            case "metal":
                Instantiate(matters[5], transform.position, Quaternion.identity);
                break;
            case "wood":
                Instantiate(matters[6], transform.position, Quaternion.identity);
                break;
            case "cable":
                Instantiate(matters[7], transform.position, Quaternion.identity);
                break;
            case "coal":
                Instantiate(matters[8], transform.position, Quaternion.identity);
                break;
            case "glass":
                Instantiate(matters[9], transform.position, Quaternion.identity);
                break;
             default:
                Debug.Log("oh noooo");
                break;
        }
    }
}