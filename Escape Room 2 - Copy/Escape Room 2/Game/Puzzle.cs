using System.Collections.Generic;

namespace Escape_Room_2.Game
{
    /// <summary>
    /// המחלקה מייצגת חידה בודדת במשחק
    /// כל חידה מכילה: השאלה, מיקום הצגתה, התשובה הנכונה,
    /// רמז (טקסט או תמונה), סוג החידה, תמונות,
    /// ובאופן אופציונלי עבור שאלות ברירה רשימת אפשרויות בחירה.
    /// </summary>
    public class Puzzle
    {
        public string Question { get; set; } //השאלה
        public string QuestionLocation { get; set; } ////מיקום הצגת השאלה("SCREEN" or "CHAT" - על המסך או בצ'אט)
        public string Answer { get; set; } //התשובה הנכונה
        public string HintText { get; set; } //רמז טקסט שמוצג לאחר 3 תשובות שגויות
        public string HintImage { get; set; } //רמז תמונה שמוצג לאחר 3 תשובות שגויות
        public string Type { get; set; } //סוג השאלה("TEXT", "CHOICE", "CLICK" - הקלדת טקסט, בחירה, הקלקה)
        public List<string> Images { get; set; } //תמונות בשביל החידה
        public List<string> Choices { get; set; } //אפשרויות בחירה עבור שאלות ברירה

        /// <summary>
        /// יוצר חידה חדשה עם כל תכונותיה
        /// מקבל את השאלה, מיקום הצגתה, התשובה, הרמז, סוג החידה,
        /// תמונות, ובאופן אופציונלי רשימת אפשרויות בחירה עבור שאלות ברירה.
        public Puzzle(string question,string questionLocation, string answer, string hintText, string hintImage, string type, List<string> images, List<string> choices=null)
        {
            Question = question;
            QuestionLocation = questionLocation;
            Answer = answer;
            HintText = hintText;
            HintImage = hintImage;
            Type = type;
            Images = images;
            Choices = choices;
        }
    }
}
