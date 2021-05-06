using UnityEngine;

namespace Game
{
    public struct ShipData 
    {
        public int id;
        public float base_dmg;
        public string name;
        public string kName;
        public float chr_level;
        public int locked;
        public float dmg;

        public ShipData(int id, float base_dmg, string name, string kName, float chr_level = 1, int locked = 1, float dmg = 1)
        {
            this.id = id;
            this.base_dmg = base_dmg;
            this.name = name;
            this.kName = kName;
            this.chr_level = chr_level;
            this.locked = locked;
            this.dmg = dmg;
        }

        public void SetDamage()
        {
            dmg = base_dmg * chr_level;
        }

        public void Show()
        {
            Debug.Log($"id : {id} base_dmg : {base_dmg} name : {name} kName : {kName} chr_level : {chr_level} locked : {locked} dmg : {dmg}");
        }

    }

}

