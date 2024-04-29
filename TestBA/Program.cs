using TestBA;

List<Pallet> pallets = SQLiteDataAccess.LoadPallets();
foreach (Pallet p in pallets)
{
    List<Box> boxes = SQLiteDataAccess.LoadBoxes(p.Id);
    foreach (Box box in boxes)
    {
        p.Add(box);
    }
}

var c = pallets.OrderBy(x => x.ExpirationDate).ThenBy(x => x.Weight).ToList();
foreach(Pallet p in c)
{
    Console.WriteLine(p.Id + " " + p.ExpirationDate + " " + p.Weight);
}
Console.WriteLine();
c = pallets.OrderBy(x => x.ExpirationDate).TakeLast(3).OrderBy(x => x.Volume).ToList();
foreach (Pallet p in c)
{
    Console.WriteLine(p.Id + " " + p.ExpirationDate + " " + p.Volume);
}