using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Song
    {
        private string name; //название песни
        private string author; //автор песни
        private Song prevSong;
        public Song(string name, string author)
        {
            this.author = author;
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
        public string Author
        {
            get { return author; }
        }
        public string Title()
        {
            return name + " " + author;
        }
        public Song PrevSong
        {
            get { return prevSong; }

        }
        public static void SearchPrevSong(List<Song> songs)
        {
            for (int i = 0; i < songs.Count; i++)
            {
                if (i != 0)
                {
                    songs[i].prevSong = songs[i - 1];
                    Console.WriteLine($"Для песни {songs[i].Title()} предыдущая является {songs[i].prevSong.Title()}");
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Song song = obj as Song;
            return (this.name == song.name) && (this.author == song.author);
        }
        public static void SearchEqualsSongs(List<Song> songs)
        {
            bool isFonded = false;
            for (int i = 0; i < songs.Count; i++)
            {
                for (int j = i + 1; j < songs.Count; j++)
                {
                    if (songs[i].Equals(songs[j]))
                    {
                        isFonded = true;
                        Console.WriteLine($"Совпали песни под номерами {i + 1} и {j + 1}");
                        Console.WriteLine($"Песня под названием {songs[i].name} , автор {songs[i].author}");
                    }
                }
            }
            if (!isFonded)
            {
                Console.WriteLine("Одинаковых песен не найдено");
            }
        }
    }
}
