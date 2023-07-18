using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EC
{
    public class ItemBlueprint
    {
        public string itemName;

        public string req1;
        public string req2;

        public int req1Amount;
        public int req2Amount;

        public int numofReq;

        public ItemBlueprint(string itemName, int numofReq, string req1, int req1Amount, string req2, int req2Amount)
        {
            this.itemName = itemName;

            this.req1 = req1;
            this.req2 = req2;

            this.req1Amount = req1Amount;
            this.req2Amount = req2Amount;

            this.numofReq = numofReq;
        }
        

    }
}
