using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class Fabrica
    {
        private string name;
        private List<Bombilla> bombillas;

        public Fabrica(string name) 
        {
            this.name = name;
            this.bombillas = new List<Bombilla>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Bombilla> Bombillas
        {
            get { return bombillas; }
            set { bombillas = value; }
        }

        public void CreateBombilla(string lote,Enums.TypeBombilla type, int lumens)
        {
            Bombilla b = new Bombilla(lote,type,lumens);
            bombillas.Add(b);
        }

        public int BombillasTotal()
        {
            return bombillas.Count;
        }

        public int BombillasTotalType(Enums.TypeBombilla type)
        {
            return bombillas.Count(b => b.Type == type);
        }

        public bool RepairBombilla(Bombilla bombilla)
        {
            bool repaired = false;
            if(bombilla.IsBroken == true) 
            {
                bombilla.IsBroken = false;
                repaired = true;
            }
            return repaired;
        }

        public int RepairBombillas(List<Bombilla> bombillas)
        {
            int howManyBroken = 0;
            foreach (Bombilla b in bombillas)
            {       
                bool res = RepairBombilla(b);
                if(res)
                    howManyBroken++;                
            }                       
            return howManyBroken;
        }

        public void SendBombillas(string lote)
        {            
            bombillas.RemoveAll(b=>b.Lote == lote);
        }

    }
}
