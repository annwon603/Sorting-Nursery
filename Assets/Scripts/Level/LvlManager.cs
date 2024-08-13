using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{

    [Header("Events")]
    public GameEvent testing;
    public DialogueManager dialogueManager;
    public QuotaManager quotaManager;
    public EggManager eggManager;




    // Start is called before the first frame update
    void Start()
    {
        testing.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
