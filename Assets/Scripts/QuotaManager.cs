using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuotaManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI manQuotaText;

    public TextMeshProUGUI optQuotaText;

    public GameObject quotaPanel;



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetQuota(Quota quota)
    {
        manQuotaText.text = quota.manQuote.dialouge;
        optQuotaText.text = quota.optQuote.dialouge;
    }

    public void CompleteMandatory()
    {
        manQuotaText.fontStyle = FontStyles.Strikethrough; 

    }

    public void CompleteOpt()
    {
        optQuotaText.fontStyle = FontStyles.Strikethrough;

    }
}
