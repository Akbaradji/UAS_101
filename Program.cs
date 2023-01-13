using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_101
{
    class Node
    {
        public int Nim;
        public string Nama_Mhs;
        public string Jenis_Kelamin;
        public string Kelas;
        public string Kota_Asal;
        public Node next;
    }
    class DoubleLinkedlist
    {
        Node START;
        public DoubleLinkedlist()
        {
            START = null;
        }
        public void insert()
        {
            int nm;
            string nmhs,jk,kls, ka;
            Console.Write("Masukan NIM : ");
            nm = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan Nama Mahasiswa : ");
            nmhs = Console.ReadLine();
            Console.Write("Masukan Kelas : ");
            kls = Console.ReadLine();
            Console.Write("Masukan Jenis Kelamin : ");
            jk = Console.ReadLine();
            Console.Write("Masukan Kota Asal : ");
            ka = Console.ReadLine();

            Node newnode = new Node();

            newnode.Nim = nm;
            newnode.Nama_Mhs = nmhs;
            newnode.Kelas = kls;
            newnode.Jenis_Kelamin = jk;
            newnode.Kota_Asal = ka;

            if (START == null || nm <= START.Nim)
            {
                if ((START != null) && (nm == START.Nim))
                {
                    Console.WriteLine("\nDuplicade number not allowed");
                    return;
                }

                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nm >= current.Nim))
            {
                if (nm == current.Nim)
                {
                    Console.WriteLine("\nDuplikat nomor buku tidak diperbolehkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool search(string ka, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (ka != current.Kota_Asal))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList data Mahasiswa : ");
                Console.Write("Nim" + "   " + "Nama Mahasiswa" + "    " + "Kelas" + "   " + "Jenis Kelamin" + "  " + "Kota Asal" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.Nim + "    " + currentNode.Nama_Mhs + "    " + currentNode.Kelas + "  "+ currentNode.Jenis_Kelamin +"  " + currentNode.Kota_Asal + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedlist obj = new DoubleLinkedlist();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Masukkan Data Mahasiswa");
                    Console.WriteLine("2. Melihat Data Mahasiswa");
                    Console.WriteLine("3. Mencari Data Mahasiswa");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nmasukan kota asal yang ingin dicari : ");
                                string ka = Console.ReadLine();
                                if (obj.search(ka, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Node TH;
                                    for (TH = current; TH != null; TH = TH.next)
                                    {
                                        Console.WriteLine("\nRecord  found");
                                        Console.WriteLine("\nNim: " + current.Nim);
                                        Console.WriteLine("\nNama Mahasiswa : " + current.Nama_Mhs);
                                        Console.WriteLine("\nNama Kelas: " + current.Kelas);
                                        Console.WriteLine("\nJenis Kelamin: " + current.Jenis_Kelamin);
                                        Console.WriteLine("\nKota Asal: " + current.Kota_Asal);
                                    }
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for for the value entered");
                }
            }
        }
    }

    
}


/*Jawaban 2-5
 
 2. Saya menggunakan Double Linked List, Alasannnya karena algoritma ini tersedia menampilkan,megnurutkan,mencari
 3. Enqueue dan Dequeue
 4. Array : Mencari data dalam bentuk angka
    Linked List : Mempermudah dalam menampilkan, mengurutkan, dan mencari data
 5. a. Parent : 5,16,32,12
       Children : 16,20,28
    b. Inorder : 16,18,12,10,15,5,10,15,20,25,28,20,30,32,20
*/