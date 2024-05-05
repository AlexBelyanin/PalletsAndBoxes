namespace TestBA
{
    public class Box
    {
        public int Id { get; }
        public int Width { get; }
        public int Length { get; }
        public int Height { get; }
        public double Weight { get; }
        DateTime expiration_date;
        DateTime production_date;

        static int shelfLife = 100;

        public DateOnly ExpirationDate
        {
            get
            {
                if (production_date.ToString() != new DateTime().ToString())
                {
                    DateTime temp = production_date.AddDays(shelfLife);
                    return new DateOnly(temp.Year, temp.Month, temp.Day);
                }
                else
                    return new DateOnly(expiration_date.Year, expiration_date.Month, expiration_date.Day);
            }
        }

        public long Volume
        {
            get
            {
                return (long)Width * Length * Height;
            }
        }

        public Box() { }

        public Box(int id, int width, int length, int height, double weight, DateTime expirationDate, DateTime productionDate)
        {
            Id = id;
            Width = width;
            Length = length;
            Height = height;
            Weight = weight;
            expiration_date = expirationDate;
            production_date = productionDate;
        }
    }
}
