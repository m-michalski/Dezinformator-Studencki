using System;
using System.Collections.Generic;
using System.IO;

namespace Dezinformator
{
    public class QuestionParser
    {
        public Question LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string key = lines[0];

            int questionLines = 0;
            List<bool> correctAnswers = new List<bool>();

            foreach (char c in key)
            {
                if (c == 'X' || c == 'x') 
                    questionLines++;
                else if (c == '0') 
                    correctAnswers.Add(false);
                else if (c == '1') 
                    correctAnswers.Add(true);
            }

            string[] questionText = new string[questionLines];
            for (int i = 0; i < questionLines; i++)
            {
                questionText[i] = lines[i + 1];
            }

            string[][] answers = new string[correctAnswers.Count][];
            for (int i = 0; i < correctAnswers.Count; i++)
            {
                answers[i] = new string[2];
                answers[i][0] = lines[questionLines + 1 + i];
                answers[i][1] = correctAnswers[i].ToString();  
            }

            return new Question
            {
                Q_Key = key,
                Q_Text = questionText,
                Answers = answers
            };
        }
    }
}