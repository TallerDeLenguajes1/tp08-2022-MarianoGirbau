Console.WriteLine("Ingrese un path:");
string? path = Console.ReadLine();

if (Directory.Exists(path)){
    string nombreArchivo = path + "/index.csv"; //donde se guardan los archivos

    FileStream FS;

    if (!File.Exists(nombreArchivo)) //Si no existe el archivo lo crea
    {
        FS = File.Create(nombreArchivo);
        FS.Close();
    }

    FS = new FileStream(nombreArchivo,FileMode.Open);
    StreamWriter SW = new StreamWriter(FS);
    List<string> ListadoDeCarpetas = Directory.GetDirectories(path).ToList();
    int ID=1;
    foreach (string CarpetaPath in ListadoDeCarpetas)
    {
        Console.WriteLine(CarpetaPath);
        //SW.Write(ID + ";" + new DirectoryInfo(CarpetaPath).Name + "; "); //Guardo carpeta

        foreach (string item in Directory.GetFiles(CarpetaPath))
        {
            Console.WriteLine(item);
            SW.WriteLine(ID + ";" + Path.GetFileNameWithoutExtension(item) + "; " + Path.GetExtension(item));//Guardo archivo de cada carpeta, primero el nombre y luego la extension
            ID++;
        }
    }
    foreach (string item in Directory.GetFiles(path))
    {
        Console.WriteLine(item);
        SW.WriteLine(ID + ";" + Path.GetFileNameWithoutExtension(item) + "; " + Path.GetExtension(item)); //paso por los archivos de la raiz
        ID++;
    }
    SW.Close();
    FS.Close();
}