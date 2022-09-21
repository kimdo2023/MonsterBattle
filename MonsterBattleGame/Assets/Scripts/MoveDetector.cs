using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    N,
    S,
    W,
    E
};
public class MoveDetector : MonoBehaviour
{
    public Direction direction;
    public MonsterBehaviour MBScpt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if(collision.gameObject.tag == "monster wall")
        {
            switch (direction)
            {
                case Direction.W:
                    Debug.Log("W");
                    MBScpt.dir.x = -MBScpt.dir.x;
                    break;
                case Direction.E:
                    Debug.Log("E");
                    MBScpt.dir.x = -MBScpt.dir.x;
                    break;
                case Direction.N:
                    Debug.Log("N");
                    MBScpt.dir.y = -MBScpt.dir.y;
                    break;
                case Direction.S:
                    Debug.Log("S");
                    MBScpt.dir.y = -MBScpt.dir.y;
                    break;
            }
        }   
    }
}
