namespace TestBA
{
    public class Pallet
    {
        public int Id { get; }
        public int Width { get; }
        public int Length { get; }
        public int Height { get; }

        double weight;
        public double Weight { get { return weight; } }

        long boxVolume;
        public long Volume { get { return boxVolume + (long)Width * Length * Height; } }

        List<Box> boxes;
        public int Count { get { return boxes.Count; } }

        DateOnly expirationDate;
        public DateOnly ExpirationDate { get { return new DateOnly(expirationDate.Year, expirationDate.Month, expirationDate.Day); } }

        static double palletWeight = 30;

        public Pallet()
        {
            boxes = new List<Box>();
            weight = palletWeight;
        }

        public Pallet(int id, int width, int length, int height, List<Box> boxes)
        {
            this.boxes = new List<Box>();
            weight = palletWeight;
            Id = id;
            Width = width;
            Length = length;
            Height = height;
            foreach (Box box in boxes)
            {
                this.Add(box);
            }
        }

        public void Add(Box box)
        {
            if (box.Width <= this.Width && box.Length <= this.Length)
            {
                boxes.Add(box);
                if (this.ExpirationDate.ToString() == new DateOnly().ToString() || this.ExpirationDate > box.ExpirationDate)
                {
                    this.expirationDate = box.ExpirationDate;
                }
                boxVolume += box.Volume;
                weight += box.Weight;
            }
        }

        public Box this[int i]
        {
            get
            {
                return boxes[i];
            }
        }
    }
}
