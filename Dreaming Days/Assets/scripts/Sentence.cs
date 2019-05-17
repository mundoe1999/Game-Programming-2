using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence
{
  public bool hasChoice;
  public bool doesChoiceMatter;
  public Choice option;
  [TextArea(3,10)]
  public string[] words;

}
