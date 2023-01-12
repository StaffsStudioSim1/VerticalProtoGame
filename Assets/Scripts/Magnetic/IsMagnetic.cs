 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IsMagnetic
{
    void isBeingMagnetic(Vector2 pushingPlayerPos, directionOfMagnet forceDirection, PlayerMovment player);


}


public enum directionOfMagnet
{
    TOWARDS,
    AWAY
}