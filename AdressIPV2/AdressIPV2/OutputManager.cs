using System;
using System.Text;

public class OutputManager
{
    
        const int BS = 512; // Buffer Size
        const int SCREEN_SIZE = 80; // Console Size
        string[] buffer = new string[BS];
        int beginBuffer = 0;
        int endBuffer = 0;
        string filename;
        ConsoleColor defaultColor = ConsoleColor.White;

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
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
            endBuffer++;
            checkLimits();
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
        public void SavingDialog(String defaultName)
        {
            string response; // User Interface
            do
            {
                Console.WriteLine("Would you like to save ? (Y/N)");
                response = Console.ReadLine();
                if (response.ToUpper() == "Y")
                {
                    filename = defaultName; 
                    Console.WriteLine("Saving ...");
                    System.Threading.Thread.Sleep(2000);
                    Dump();
                    Console.WriteLine("Done");
                }
            }
            while (response.ToUpper() != "Y" && response.ToUpper() != "N");
        }
        public void Dump()
        {
            // Ouvrir un fichier Dump
            // Si buffer est plein
            
            string directoryAdress = System.IO.Directory.GetCurrentDirectory().Replace("\\", "/") + "/" + filename;
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
        public void ForegroundColor(ConsoleColor color) // change la couleur du texte 
        {
            defaultColor = color;
            Console.ForegroundColor = color;
        }
        public void Center(string texte, char separator = ' ')
        {
            string spacing = Offset(texte);
            string output = spacing + texte + spacing;
            buffer[endBuffer] += texte; // Ajoute du contenu a la dernière ligne  
            Console.WriteLine(output.Substring(0, SCREEN_SIZE - 1), separator); // spacing peut avec un char de trop a cause de l'arrondi de la division par 2
        }
        public void Centera(string texte, char separator = ' ')
        {
            string spacing = Offset(texte);
            string output = spacing + texte + spacing;
            Console.WriteLine(output.Substring(0, SCREEN_SIZE - 1), separator); // spacing peut avec un char de trop a cause de l'arrondi de la division par 2
        }
        public string Offset(string texte)
        {
            return X((SCREEN_SIZE - texte.Length) / 2);
        }
        public string X(int i, char separator = ' ')
        {
            string space = "";
            for (int j = i; i > 0; i--) space += separator;
            return space;
        }
        public void Newline()
        {
            Console.WriteLine();
        }
        public void FullLine(char separator = ' ')
        {
            Console.WriteLine(X(SCREEN_SIZE - 1), separator);
        }
        public void AnyKeyContinue()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen; // (Color)ColorConverter.ConvertFromString("#FFDFD991");
            Centera("Press any key to continue...");
            Console.ReadKey();
            Console.ForegroundColor = defaultColor;
        }
        public void FileWrite (string texte) //Ecrit dans le fichier SEULEMENT
        {
            buffer[endBuffer] = texte; // Memorise tout ce qui est affiché
            endBuffer++;
            checkLimits();
            buffer[endBuffer] = "";
        }
        public void FileWriteLine()
        {
            endBuffer++;
            checkLimits();
        }
        
    }


