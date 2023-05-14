using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace ProductManagement
{
    internal class Program
    {
        static string filePath = "D:\\Code Gym\\ProductManagement\\Product.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("=== Quản lý thông tin sản phẩm ===");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Hiển thị danh sách sản phẩm");
                Console.WriteLine("3. Tìm kiếm sản phẩm");
                Console.WriteLine("4. Thoát");
                Console.Write("Vui lòng chọn một tùy chọn: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        DisplayProducts();
                        break;
                    case "3":
                        SearchProduct();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ.");
                        break;
                }

                Console.ReadLine();
            }
        }
        static void AddProduct()
        {
            Console.WriteLine("=== Thêm sản phẩm ===");

            Console.Write("Nhập mã sản phẩm: ");
            string code = Console.ReadLine();

            Console.Write("Nhập tên sản phẩm: ");
            string name = Console.ReadLine();

            Console.Write("Nhập hãng sản xuất: ");
            string manufacturer = Console.ReadLine();

            Console.Write("Nhập giá sản phẩm: ");
            double price = Convert.ToDouble(Console.ReadLine());
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{code},{name},{manufacturer},{price}");
                }

                Console.WriteLine("Thêm sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }
        static void DisplayProducts()
        {
            Console.WriteLine("=== Danh sách sản phẩm ===");
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 4)
                        {
                            string code = parts[0];
                            string name = parts[1];
                            string manufacturer = parts[2];
                            double price = Convert.ToDouble(parts[3]);

                            Console.WriteLine($"Mã: {code}, Tên: {name}, Hãng: {manufacturer}, Giá: {price}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi hiển thị danh sách sản phẩm: " + ex.Message);
            }
        }
        static void SearchProduct()
        {
            Console.WriteLine("=== Tìm kiếm sản phẩm ===");

            Console.Write("Nhập mã sản phẩm cần tìm: ");
            string searchCode = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    bool found = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 4)
                        {
                            string code = parts[0];

                            if (code == searchCode)
                            {
                                string name = parts[1];
                                string manufacturer = parts[2];
                                double price = Convert.ToDouble(parts[3]);
                                Console.WriteLine("Sản phẩm được tìm thấy:");
                                Console.WriteLine($"Mã: {code}, Tên: {name}, Hãng: {manufacturer}, Giá: {price}");

                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Không tìm thấy sản phẩm với mã tìm kiếm đã nhập.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm sản phẩm: " + ex.Message);
            }
        }   
    }    
}
