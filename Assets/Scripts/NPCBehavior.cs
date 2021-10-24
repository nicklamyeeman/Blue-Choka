using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    private int rotation;
    private bool isTalking = false;
    private bool isDrunk = false;

    public int Rotation { get {return rotation;} set {rotation = value;}}
    public bool IsTalking { get {return isTalking;} set {isTalking = value;}}
    public bool IsDrunk { get {return isDrunk;} set {isDrunk = value;}}
}
