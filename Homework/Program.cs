using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    
        class Program
    {
       
        
            static void Main(string[] args)
            {

                List<Song> songs = new List<Song>();
                int counsong = 4;
                for (int i = 0; i < counsong; i++)
                {
                    Console.WriteLine("Введите название песни");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите артиста");
                    string author = Console.ReadLine();
                    songs.Add(new Song(name, author));
                }
                Song.SearchEqualsSongs(songs);
            Song.SearchPrevSong(songs);
       


                Console.ReadKey();
            }
        }
    }


