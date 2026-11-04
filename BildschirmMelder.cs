using System;
using System.Collections.Generic;
using System.Text;

namespace Frisch_Flott_GmbH
{
    public class BildschirmMelder : IAlarmEmpfaenger
    {
        public void MeldeAlarm(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bildschirm: " + text);
            Console.ResetColor();
        }
    }
}
