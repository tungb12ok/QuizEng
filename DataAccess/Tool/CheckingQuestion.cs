using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tool
{
    public class CheckingQuestion
    {
        public static bool checkQuestion(Question question, string answer)
        {
            if (question == null)
            {
                return false;
            }
            else if (answer == null)
            {
                return false;
            }
            else
            {
                if (question.CorrectAnswer == answer)
                {
                    return true;
                }
                else { return false; }
            }
        }
    }
}
