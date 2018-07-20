using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoints : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private Transform checkPoint;
    private int count = 0;
    public char position;

    void OnTriggerEnter(Collider other)
    {
        if (position == 'l')
            logRecord.leftCurbHits++;
        else if (position == 'r')
            logRecord.rightCurbHits++;

        if (count == 2) {

            player.transform.position = checkPoint.transform.position;
            player.transform.rotation = checkPoint.transform.rotation;
            distance.dis = disRecord.record;
            count = 0;
        }
        else
        {
            count++;
            print("hit!" + count);
        }
    }

}
