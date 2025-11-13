using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Core.Singleton;

public class CheckpointManger : Singleton<CheckpointManger>
{
    public int lastCheck = 0;
    public List<CheckpointBase> checkpoints;


    public bool HasCheckpoint()
    {
        return lastCheck > 0;
    }
    public void SaveCheck(int i)
    {
        if (i > lastCheck)
        {
            lastCheck = i;
        }
    }
    
    public Vector3 GetPositionRespawn()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheck);
        return checkpoint.transform.position;
    }
}
