using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Quiz
{
    public class Quiz
    {
        public List<Question> Questions;
        public Player Player;
        

        public Quiz()
        {


            LoadQuestionsFromFile("Questions.txt");


        }

        private void LoadQuestionsFromFile(string filePath)
        {
        var lines = File.ReadAllLines(filePath);
        var counter =0;
            Questions = new List<Question>();


            var currentQuestion = new Question();


            foreach(var line in lines)
            {
                if (counter == 6)
                {
                    counter = 0;
                }

              

                if (counter == 0)
                {
                    currentQuestion.Title = line;
                }                     
                if (counter == 1)
                {
                    currentQuestion.AnswerA = line;   
                }
                if (counter == 2)
                {
                    currentQuestion.AnswerB = line;
                }
                if (counter == 3)
                {
                    currentQuestion.AnswerC = line;
                }
                if (counter == 4)
                {
                    currentQuestion.AnswerD = line;
                }
                if (counter == 5)
                {
                    currentQuestion.RightAnswerLetter = line[0].ToString();
                    currentQuestion.Score = int.Parse(line[1].ToString());

                    var newQuestion = new Question
                    {
                        Title = currentQuestion.Title,
                        AnswerA = currentQuestion.AnswerA,
                        AnswerB = currentQuestion.AnswerB,
                        AnswerC = currentQuestion.AnswerC,
                        AnswerD = currentQuestion.AnswerD,
                        RightAnswerLetter = currentQuestion.RightAnswerLetter,
                        Score = currentQuestion.Score
                    };

                    Questions.Add(newQuestion);
                                 
                }

                counter++;

            }

        }

        public void Start()
        {

            Player = new Player();

            Console.WriteLine("Podaj Imie: ");
            Player.Name = Console.ReadLine();
            Player.Score = 0;
            Player.CurrentQuestion = 1;


            for (var i=0;i<Questions.Count;i++)
            {
                var Score = ShowQuestion(Player.CurrentQuestion);
                Player.Score += Score;
                Player.CurrentQuestion++; 
            }

            Console.WriteLine("Otrzymałaś: " + Player.Score);
        }

        public int ShowQuestion(int questionCounter)
        {

            var currentQuestionToShow = Questions[questionCounter - 1];

            Console.WriteLine("Pytanie: " + currentQuestionToShow.Title);
            Console.WriteLine("A " + currentQuestionToShow.AnswerA);
            Console.WriteLine("B " + currentQuestionToShow.AnswerB);
            Console.WriteLine("C " + currentQuestionToShow.AnswerC);
            Console.WriteLine("D " + currentQuestionToShow.AnswerD);

            var userResponse = Console.ReadLine();

            if (userResponse == currentQuestionToShow.RightAnswerLetter)
            {
                Console.WriteLine("dobra odpowiedź");
                return currentQuestionToShow.Score;
                
            }
            Console.WriteLine("zła odpowiedź");
            return 0;





        }





    }

}
