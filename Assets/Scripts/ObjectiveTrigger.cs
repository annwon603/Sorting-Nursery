using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public Objective objective;
    void Start()
    {
        TriggerObjective();
    }

    // Update is called once per frame
    public void TriggerObjective()
    {
        FindObjectOfType<ObjectiveManager>().SetObjective(objective);
    }
}
