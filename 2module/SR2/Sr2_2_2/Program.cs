using System;

namespace Sr2_2_2
{
    /// <summary>
    /// Класс для блогера
    /// </summary>
    class Blogger 
    {
        /// <summary>
        /// Тематика блогера
        /// </summary>
        public int Subject {get; private set;}

        /// <summary>
        /// Идентификатор блогера
        /// </summary>
        public long Id {get; private set;}

        /// <summary>
        /// Единственный конструктор
        /// </summary>
        /// <param name="subject">тематика блога</param>
        /// <param name="id">идентификатор</param>
        public Blogger(int subject, long id)
        {
            Subject = subject;
            Id = id;
        }

        /// <summary>
        /// Метод, симулирующий действие "Написать пост"
        /// </summary>
        /// <param name="length">длина публикации</param>
        /// <returns>пост</returns>
        public string MakePost(int length)
        {
            string res = "";

            for (int i = 0; i < length; i++)
                res += Subject.ToString();
            
            return res;
        }

        /// <summary>
        /// Переопределенный ToString
        /// </summary>
        /// <returns>Тема блога и идентификатор пользователя</returns>
        public override string ToString() => $"Subject: {Subject}, Id: {Id}";
    }
    
    /// <summary>
    /// Класс для подписчика
    /// </summary>
    class Subscriber
    {
        /// <summary>
        /// Вероятность дислайка
        /// </summary>
        public double DislikeProbability {get; private set;}

        /// <summary>
        /// Любимый размер блога
        /// </summary>
        public int FavouriteSize {get; private set;}
        
        /// <summary>
        /// Нелюбимая тематика
        /// </summary>
        public int HatefullSubject {get; private set;}

        /// <summary>
        /// Единственный конструктор
        /// </summary>
        /// <param name="dislikeProbability">вероятность дислайка</param>
        /// <param name="hatefullSubject">нелюбимая тематика</param>
        /// <param name="favouriteSize">любимый размер блога</param>
        public Subscriber(double dislikeProbability, int hatefullSubject, int favouriteSize)
        {
            DislikeProbability = dislikeProbability;
            HatefullSubject = hatefullSubject;
            FavouriteSize = favouriteSize;
        }

        /// <summary>
        /// Для случайности дислайка
        /// </summary>
        static Random random = new Random();

        public bool ReadPost(string post)
        {
            double size = post.Length;

            double randomNumber = random.NextDouble() * size / FavouriteSize;

            return randomNumber > DislikeProbability || post[0] - '0' == HatefullSubject;
        }

        /// <summary>
        /// Переопределенный ToString
        /// </summary>
        /// <returns>вероятность дислайка, нелюбимая тематика блога и любимый размер блога</returns>
        public override string ToString() => $"DislikeProbability: {DislikeProbability:F3}," +
             $" HatefullSubject: {HatefullSubject}, FavouriteSize: {FavouriteSize}";
    }

    class Program
    {
        /// <summary>
        /// Считывает число, выводя приглашение на консоль
        /// </summary>
        /// <param name="message">приглашение для ввода</param>
        /// <returns>считанное число</returns>
        static int ReadInt(string message)
        {
            bool isCorrect = false;
            int res;

            do 
            {
                Console.Write(message);
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out res) && res > 0 && res < 100))
                    Console.WriteLine("Input error!");
            } while (!isCorrect);

            return res;
        }

        static void Main(string[] args)
        {
            do 
            {
                int n = ReadInt("Введите количество подписчиков: ");
                var subscribers = new Subscriber[n];
                Random random = new Random();

                const int maxSubject = 10;
                const int maxBlogSize = 101;
                const int maxId = 1001;

                for (int i = 0; i < n; i++)
                    subscribers[i] = new Subscriber(random.NextDouble(), random.Next(1, maxSubject),
                                                    random.Next(1, maxBlogSize));

                var b1 = new Blogger(random.Next(1, maxSubject), random.Next(1, maxId));
                var b2 = new Blogger(random.Next(1, maxSubject), random.Next(1, maxId));

                int b1Likes = 0, b2Likes = 0;
                string postB1 = b1.MakePost(random.Next(1, maxBlogSize));
                string postB2 = b2.MakePost(random.Next(1, maxBlogSize));

                foreach (var subscriber in subscribers)
                {
                    bool b1Like = !subscriber.ReadPost(postB1),
                        b2Like = !subscriber.ReadPost(postB2);

                    b1Likes += b1Like ? 1 : -1;
                    b2Likes += b2Like ? 1 : -1;

                    Console.WriteLine("{0} first: {1}, second: {2}", subscriber, b1Like ? "Like" : "Dislike",
                         b2Like ? "Like" : "Dislike");
                }

                Console.WriteLine("Total likes first: {0}, total likes second: {1}", b1Likes, b2Likes);
                Console.WriteLine(b1);
                Console.WriteLine(b2);
                Console.WriteLine("ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
