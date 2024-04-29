namespace TestBA
{
    class Pallet
    {
        public int Id { get; }
        public int Width { get; }
        public int Length { get; }
        public int Height { get; }
        double weight;
        public double Weight 
        { 
            get 
            { 
                return weight; 
            } 
        }
        long boxVolume;
        public long Volume
        {
            get
            {
                return boxVolume + (long)Width * Length * Height;
            }
        }
        public List<Box> Boxes;
        DateOnly expirationDate;
        public DateOnly ExpirationDate
        {
            get
            {
                return new DateOnly(expirationDate.Year, expirationDate.Month, expirationDate.Day);
            }
        }

        static double palletWeight = 30;

        public Pallet()
        {
            Boxes = new List<Box>();
            weight = palletWeight;
        }

        public void Add(Box box)
        {
            if (box.Width <= this.Width && box.Length <= this.Length)
            {
                Boxes.Add(box);
                if (this.ExpirationDate.ToString() == new DateOnly().ToString() || this.ExpirationDate > box.ExpirationDate)
                {
                    this.expirationDate = box.ExpirationDate;
                }
                boxVolume += box.Volume;
                weight += box.Weight;
            }
        }
    }
}
