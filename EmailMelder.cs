using System;
using System.Collections.Generic;
using System.Text;

namespace Frisch_Flott_GmbH
{
    public class EmailMelder : IAlarmEmpfaenger
    {
        private readonly string _empfaenger;
        
        public EmailMelder(string empfaenger)
        {
            _empfaenger = empfaenger;
        }

        public void MeldeAlarm(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Email an " + _empfaenger + ": " + text);
            Console.ResetColor();
        }
    }
}
