using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManagement : MonoBehaviour
{
    // isPortal : is Player placed on portal?
    // idk will use it later
    public bool isPortal = false;

    // linkedPortal : class for portal pair
    public class linkedPortal {
        // portal : an array for the portal pair info (Transform)
        private Transform[] portal = new Transform[2];
        
        // getPortalTrans : return the Transform from one of the two portals
        public Transform getPortalTrans(int num)
        {
            return portal[num];
        }

        // constructor : saving the portal pair info
        public linkedPortal(Transform[] transArray)
        {
            for(int i = 0; i < 2; i++)
                portal[i] = transArray[i];
        }
    }

    // enterPortal : return the Transform informatino of opponent portal
    public Transform enterPortal(Transform currentPos)
    {
        float tempX, tempY;
        tempX = tempPos.position.x;
        tempY = tempPos.position.y;
        Transform pos;
        // need the linkedPortal array that have every portals
        // search the portals within the array for this position (currentPos)
        // return the Transform information of opponent portal
        return pos;
    }
}
