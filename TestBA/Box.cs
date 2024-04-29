namespace TestBA
{
    class Box
    {
        public int Id { get; }
        public int Width { get; }
        public int Length { get; }
        public int Height { get; }
        public double Weight { get; }
        public DateTime expiration_date;
        public DateTime production_date;

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
    }
}
