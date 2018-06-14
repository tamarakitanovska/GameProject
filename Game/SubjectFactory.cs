using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SubjectFactory
    {

        //Arhitektura i organizacija na kompjuteri
        private static Subject AOK=new Subject(Color.Blue,"Архитектура и организација на копмјутери",Questions.AokQuestion,Questions.AokAnswers);
        //Operativni sistemi
        private static Subject OS=new Subject(Color.Black,"Оперативни системи",Questions.OsQuestion,Questions.OsAnswers);
        //strukturno programiranje
        private static Subject SP= new Subject(Color.Green, "Софтверско инженерство", Questions.SpQuestion, Questions.SpAnswers);
        //Softversko inzinerstvo
        private static Subject SI=new Subject(Color.Red, "Софтверско инжинерство", Questions.SiQuestion, Questions.SiAnswers);

        private static Random Random = new Random();
        public static Color[] possibleColors { get; set; } = { Color.Red, Color.Yellow, Color.Blue, Color.Pink };
        
        private static Dictionary<Color, Subject> ColorsToSubjects { get; set; } = new Dictionary<Color, Subject>() { { Color.Black, OS },
        { Color.Red, SI },{ Color.Green,SP},{Color.Blue,AOK } };

        //return a Subject
        public static Subject GetSubject()
        {
            int color = Random.Next(0, possibleColors.Length);
            Subject toReturn=null;
            ColorsToSubjects.TryGetValue(possibleColors[color], out toReturn);
            return toReturn;              
            
        }

        public class Subject
        {

            public List<String> Questions { get; set; }
            public List<String> Answers { get; set; }
            public String Name { get; set; }
            public Color Color { get; set; }
            public Random Random { get; set; } = new Random();


            public  Subject(Color c,String n,List<String> q, List<String> a)
            {
                Name = n;
                Color = c;
                Questions = q;
                Answers = a;


            }
            
            //return a pair -Question,Answer
            public Dictionary<String,String> getQuestionAndAnswer()
            {
                int q = Random.Next(0, Questions.Count);
                
                return new Dictionary<string, string>() { { Questions.ElementAt(q), Answers.ElementAt(q) } };
            }
        }
    }
}
}
