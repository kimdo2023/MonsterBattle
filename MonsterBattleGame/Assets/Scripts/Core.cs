using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public int HP;
    public ChunkBehaviour chunk_1;
    public ChunkBehaviour chunk_2;
    public ChunkBehaviour chunk_3;
    public ChunkBehaviour chunk_4;
    public ChunkBehaviour chunk_5;
    void Start()
    {
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(attacked by player with fire)
        //if(HP == 0)
         //    Destroy(gameObject);
    }

    public void LaunchAChunk()
    {

        while(true)
        {
            int i = Random.Range(1, 6);
            bool stop = false;
            switch(i)
                {
                case 1:
                    if(chunk_1!=null)
                    {
                        if(chunk_1.isAttached)
                        {
                            chunk_1.isGettingKnockedOff = true;
                            stop = true;
                        }
                    }
                    break;
                case 2:
                    if (chunk_2 != null)
                    {
                        if (chunk_2.isAttached)
                        {
                            chunk_2.isGettingKnockedOff = true;
                            stop = true;
                        }
                    }
                    break;
                case 3:
                    if (chunk_3 != null)
                    {
                        if (chunk_3.isAttached)
                        {
                            chunk_3.isGettingKnockedOff = true;
                            stop = true;
                        }
                    }
                    break;
                case 4:
                    if (chunk_4 != null)
                    {
                        if (chunk_4.isAttached)
                        {
                            chunk_4.isGettingKnockedOff = true;
                            stop = true;
                        }
                    }
                    break;
                case 5:
                    if (chunk_5 != null)
                    {
                        if (chunk_5.isAttached)
                        {
                            chunk_5.isGettingKnockedOff = true;
                            stop = true;
                        }
                    }
                    break;
            }
            if (stop) break;
        }
    }
}
