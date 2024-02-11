namespace Katas
{
    public class Bombilla
    {        
        private Enums.TypeBombilla type;
        private int lumens;
        private bool isBroken;
        private string lote;

        public Bombilla(string lote, Enums.TypeBombilla type = Enums.TypeBombilla.Led, int lumens = 800) 
        {             
            this.type = type;   
            this.lumens = lumens;
            isBroken = false;
            this.lote = lote;
        }               

        public Enums.TypeBombilla Type
        {
            get { return type; }            
        }

        public int Lumens
        {
            get { return lumens; }
        }

        public bool IsBroken
        {
            get { return isBroken; }
            set { isBroken = value; }
        }

        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }
        
    }
}
