using Newtonsoft.Json;
int posit = 0;
do
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Выберете формат файла");
    Console.SetCursorPosition(2, 1);
    Console.WriteLine("TxT");
    Console.SetCursorPosition(2, 2);
    Console.WriteLine("Jons");
    Console.SetCursorPosition(2, 3);
    Console.WriteLine("XML");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.UpArrow)
    {
        Console.Clear();
        posit--;
        Console.SetCursorPosition(0, posit);
        Console.WriteLine("->");
    }
    if (key.Key == ConsoleKey.DownArrow)
    {
        Console.Clear();
        posit++;
        Console.SetCursorPosition(0, posit);
        Console.WriteLine("->");
    }
    if (posit == 1 && key.Key == ConsoleKey.Enter)
    {
        TXT();
    }
    if (posit == 2 && key.Key == ConsoleKey.Enter)
    {
        Json();
    }
    if (posit == 3 && key.Key == ConsoleKey.Enter)
    {
        XML();
    }
    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }
}
while (true);

static void TXT()
{
    Console.WriteLine("Введите текст, который нужно сохранить");
    string read = Console.ReadLine();
    Human Eduard = new Human();
    Eduard.Name = "Эдуард";
    List<Human> humans = new List<Human>();
    humans.Add(Eduard);
    string text = File.ReadAllText("C:\\user\\source\\repos\\TextConverter.txt");
    File.AppendAllText("C:\\user\\source\\repos\\TextConverter.txt", "\n");
    File.AppendAllText("C:\\user\\source\\repos\\TextConverter.txt", Eduard.Name);
    File.AppendAllText("C:\\user\\source\\repos\\TextConverter.txt", "\n");
    File.AppendAllText("C:\\user\\source\\repos\\TextConverter.txt", read);
    Console.SetCursorPosition(5, 5);
    Console.WriteLine(text);
    Console.ReadKey();
    Console.Clear();
}

static void XML()
{
    Console.WriteLine("Введите текст, который нужно сохранить");
    string read = Console.ReadLine();
    Human Eduard = new Human();
    Eduard.Name = "Эдуард";

    List<Human> humans = new List<Human>();
    humans.Add(Eduard);

    System.Xml.Serialization.XmlSerializer XML = new System.Xml.Serialization.XmlSerializer(typeof(Human));
    using (FileStream fs = new FileStream("C:\\user\\source\\repos\\Конвертер.XML", FileMode.OpenOrCreate))
    {
        XML.Serialize(fs, Eduard);
        XML.Serialize(fs, read);
    }

    Human human;

    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(Human));
    using (FileStream fs = new FileStream("C:\\user\\source\\repos\\Конвертер.XML", FileMode.Open))
    {
        human = (Human)XML.Deserialize(fs);
    }
}
static void Json()
{
    Console.WriteLine("Введите текст, который нужно сохранить");
    string read = Console.ReadLine();
    Human Eduard = new Human();
    Eduard.Name = "Эдуард";
    List<Human> humans = new List<Human>();
    humans.Add(Eduard);
    string json = JsonConvert.SerializeObject(humans);
    File.AppendAllText("C:\\user\\source\\repos\\текст.json", "\n");
    File.AppendAllText("C:\\user\\source\\repos\\текст.json", json);
    File.AppendAllText("C:\\user\\source\\repos\\текст.json", "\n");
    File.AppendAllText("C:\\user\\source\\repos\\текст.json", read);
    string text = File.ReadAllText("C:\\user\\source\\repos\\текст.json");
    List<Human> result = JsonConvert.DeserializeObject<List<Human>>(text); 
    Console.SetCursorPosition(5, 5);
    Console.WriteLine(text);
    Console.ReadKey();
    Console.Clear();
}
