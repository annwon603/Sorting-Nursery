using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuotaTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public Quota quota;
    public void TriggerQuota()
    {
        FindObjectOfType<QuotaManager>().SetQuota(quota);
    }

    // Update is called once per frame
    public void Start()
    {
        TriggerQuota();
    }
}
