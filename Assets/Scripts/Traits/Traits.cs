using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Trait", menuName = "Trait")]
public class Traits : ScriptableObject
{
   public string traitSet; // Ex: BigSmall, MetalNonmetal
   public bool isTraitActive; //Ex: true = big, false = small
                    
}
