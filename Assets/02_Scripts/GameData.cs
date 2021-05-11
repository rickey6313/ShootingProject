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
        public float nextDmg;
        public float unlockCoin;

        public ShipData(int id, float base_dmg, string name, string kName, float unlockCoin, float chr_level = 1, int locked = 1, float dmg = 1, float nextDmg = 1)
        {
            this.id = id;
            this.base_dmg = base_dmg;
            this.name = name;
            this.kName = kName;
            this.chr_level = chr_level;
            this.locked = locked;
            this.dmg = dmg;
            this.nextDmg = nextDmg;
            this.unlockCoin = unlockCoin;
        }

        public string GetImageName()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            return sb.AppendFormat("Character/{0}/0", id.ToString()).ToString();
        }

        public void SetDamage()
        {
            dmg = base_dmg * chr_level;
            this.nextDmg = (chr_level + 1) * base_dmg;
        }

        public void Show()
        {
            Debug.Log($"id : {id} base_dmg : {base_dmg} name : {name} kName : {kName} chr_level : {chr_level} unlockCoin : {unlockCoin} locked : {locked} dmg : {dmg}");
        }

    }

}

