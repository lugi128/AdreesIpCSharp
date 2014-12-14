using System;

public class OutputManager
{
    class OutputManager
    {
        const int BS = 128; // Buffer Size
        string[] buffer = new string[BS];
        int beginBuffer = 0;
        int endBuffer = 0;
        private void checkLimits()
        {
            if (endBuffer == BS) endBuffer = 0; // On efface le debut du buffer
            if (endBuffer == beginBuffer) beginBuffer++; // On deplace le debut du buffer (puisqu'il a été effacé)
            if (beginBuffer == BS) beginBuffer = 0; // On gère un buffer circulaire
        }
        public void Write(string texte)
        {
            buffer[endBuffer] += texte; // Ajoute du contenu a la dernière ligne  
            Console.Write(texte);
        }
        public void WriteLine() // Ajoute une ligne vide
        {
            buffer[endBuffer] = "";
            endBuffer++;
            checkLimits();
            buffer[endBuffer] = "";
            Console.WriteLine();
        }
        public void WriteLine(string texte)
        {
            buffer[endBuffer] = texte; // Memorise tout ce qui est affiché
            endBuffer++;
            checkLimits();
            buffer[endBuffer] = "";
            Console.WriteLine(texte);
        }
        public void Dump()
        {
            // Ouvrir un fichier Dump
            // Si buffer est plein
            string directoryAdress = System.IO.Directory.GetCurrentDirectory().Replace("\\", "/") + "/ipadress.txt";
            if (endBuffer < beginBuffer)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(directoryAdress);
                for (int i = beginBuffer; i < BS; i++)
                    file.WriteLine(buffer[i]);
                for (int i = 0; i <= endBuffer; i++)
                    file.WriteLine(buffer[i]);
                file.Close();
            }
            else  // Sinon on sort les elements dans l'ordre naturel
            {
                System.IO.File.WriteAllLines(directoryAdress, buffer);
            }
        }
    }
}
