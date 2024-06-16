using System;
using System.IO;

class ReadTextFileExample
{
    // Bước 2: Tạo phương thức ReadTextFile
    public void ReadTextFile(string filePath)
    {
        try
        {
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
            {
                throw new FileNotFoundException();
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int sum = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    try
                    {
                        sum += Int32.Parse(line);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Khong the chuyen doi '{line}' thanh so nguyen.");
                    }
                }
                Console.WriteLine("Total: " + sum);
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Tep khong ton tai");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Da xay ra loi khong xac dinh: " + ex.Message);
        }
    }

    // Bước 3: Tạo hàm Main() để gọi đến phương thức ReadTextFile và chạy chương trình
    static void Main(string[] args)
    {
        Console.WriteLine("Vui long nhap duong dan toi tep (text):");
        string path = Console.ReadLine();
        Console.WriteLine("Duong dan cua tep: " + path);
        ReadTextFileExample example = new ReadTextFileExample();
        example.ReadTextFile(path);
    }
}
