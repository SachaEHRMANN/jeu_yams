using System;
using System.IO;
using System.Collections.Generic;

public class Program
{

    public static void Logo()
    {
        string logo = @"
      ___    ___ ________  _____ ______   ________      
     |\  \  /  /|\   __  \|\   _ \  _   \|\   ____\     
     \ \  \/  / | \  \|\  \ \  \\\__\ \  \ \  \___|_    
      \ \    / / \ \   __  \ \  \\|__| \  \ \_____  \   
       \/  /  /   \ \  \ \  \ \  \    \ \  \|____|\  \  
     __/  / /      \ \__\ \__\ \__\    \ \__\____\_\  \ 
    |\___/ /        \|__|\|__|\|__|     \|__|\_________\
    \|___|/                                 \|_________|

";
    Console.Write(logo);
    }
    public static void creerJson()
    {
        StreamWriter sw = new StreamWriter("yamsresult.json");
        sw.WriteLine("{");
        sw.WriteLine("\t\"parameters\" : { ");
        sw.WriteLine("\t\t\"code\": \"TP4_saan\",");
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        sw.WriteLine("\t\t\"date\": \"" + date + "\"");
        sw.WriteLine("\t},");

        sw.Close();
    }

    public static void creerJoueurs(string j1, string j2)
    {
        string jsonContent = File.ReadAllText("yamsresult.json");
        StreamWriter sw = new StreamWriter("yamsresult.json");
        sw.Write(jsonContent);
        sw.WriteLine("\t\"players\": [");
        sw.WriteLine("\t\t{");
        sw.WriteLine("\t\t\t\"id\": 1,");
        sw.WriteLine("\t\t\t\"pseudo\": \"{0}\"", j1);
        sw.WriteLine("\t\t},");
        sw.WriteLine("\t\t{");
        sw.WriteLine("\t\t\t\"id\": 2,");
        sw.WriteLine("\t\t\t\"pseudo\": \"{0}\"", j2);
        sw.WriteLine("\t\t}");
        sw.WriteLine("\t],");

        sw.Close();
    }

    public static void creerRoundCat()
    {
        string jsonContent = File.ReadAllText("yamsresult.json");
        StreamWriter sw = new StreamWriter("yamsresult.json");
        sw.Write(jsonContent);
        sw.WriteLine("\t\"rounds\": [");

        sw.Close();        
    }

    public static void creerRoundJoueur(int i, object[] result)
    { 
        string jsonContent = File.ReadAllText("yamsresult.json");
        StreamWriter sw = new StreamWriter("yamsresult.json");
        sw.Write(jsonContent);

        int[] dice = (int[])result[1];
        string diceStr = string.Join(",", dice);
        sw.WriteLine("\t\t\t\t\t\"id_player\": {0},", result[0]);
        sw.WriteLine("\t\t\t\t\t\"dice\": [{0}],", diceStr);
        sw.WriteLine("\t\t\t\t\t\"challenge\": \"{0}\",", result[2]);
        sw.WriteLine("\t\t\t\t\t\"score\": \"{0}\"", result[3]);

        sw.Close();
    }

    public static void creerRoundTour(int i, object[] result1, object[] result2)
    {
        string jsonContent = File.ReadAllText("yamsresult.json");
        StreamWriter sw = new StreamWriter("yamsresult.json");
        sw.Write(jsonContent);
        sw.WriteLine("\t\t{");
        sw.WriteLine("\t\t\t\"id\": {0},", i);
        sw.WriteLine("\t\t\t\"results\": [");
        sw.WriteLine("\t\t\t\t{");

        sw.Close();

        creerRoundJoueur(i, result1);

        jsonContent = File.ReadAllText("yamsresult.json");
        sw = new StreamWriter("yamsresult.json");
        sw.Write(jsonContent);
        sw.WriteLine("\t\t\t\t},");
        sw.WriteLine("\t\t\t\t{");
        sw.Close();

        creerRoundJoueur(i, result2);

        jsonContent = File.ReadAllText("yamsresult.json");
        sw = new StreamWriter("yamsresult.json");
        sw.Write(jsonContent);
        sw.WriteLine("\t\t\t\t}");
        if (i != 13)
        {
            sw.WriteLine("\t\t\t]");
            sw.WriteLine("\t\t},");
        }



        sw.Close();

    }

    public static void creerFinResult(ref int somme1, ref  int somme2, ref int bonus1, ref int bonus2)
    {
        string jsonContent = File.ReadAllText("yamsresult.json");
        StreamWriter sw = new StreamWriter("yamsresult.json");
        sw.Write(jsonContent);
        sw.WriteLine("\t\t\t]");
        sw.WriteLine("\t\t}");
        sw.WriteLine("\t],");
        sw.WriteLine("\t\"final_result\": [");
        sw.WriteLine("\t\t{");
        sw.WriteLine("\t\t\t\"id_player\": 1,");
        sw.WriteLine("\t\t\t\"bonus\": \"{0}\",", bonus1);
        sw.WriteLine("\t\t\t\"score\": \"{0}\"", somme1);
        sw.WriteLine("\t\t},");
        sw.WriteLine("\t\t{");
        sw.WriteLine("\t\t\t\"id_player\": 2,");
        sw.WriteLine("\t\t\t\"bonus\": \"{0}\",", bonus2);
        sw.WriteLine("\t\t\t\"score\": \"{0}\"", somme2);
        sw.WriteLine("\t\t}");
        sw.WriteLine("\t]");
        sw.WriteLine("}");

        sw.Close();
    }

    public static string nomJoueur(int id)
    {
        Console.Write("Nom du joueur {0} : ", id);
        return Console.ReadLine();
    }

    public static List<string> ListeChallenge()
    {
        return new List<string> { "nombre1", "nombre2", "nombre3", "nombre4", "nombre5", "nombre6", "brelan", "carre", "full", "petite", "grande", "yams", "chance" };    
    }

    public static void affichage(int[] lancer)
    {
        for (int i = 0; i<lancer.Length; i++)
        {
            Console.WriteLine("Dé n°" + (i+1) + " : " + lancer[i]);
        }
        Console.WriteLine("");
    }

    public static int lancerDe()
    {
        Random rnd = new Random();
        int lancer = rnd.Next(1, 7);
        return lancer;
    }

    public static int[] lancerDes()
    {
        int [] lancer = new int [5];

        for (int i = 0; i < lancer.Length; i++)
        {
            lancer[i]=lancerDe();
        }

        return lancer;
    }

    public static int[] relance(int[] lancer)
    {
        List<int> desAGarder = new List<int> {};

        Console.WriteLine("Voulez vous relancer les dés? (o/n)");
        string choixrelance = Console.ReadLine();

        Console.WriteLine("");

        if (choixrelance == "o" || choixrelance == "O")
            {
            Console.WriteLine("Quels dés voulez-vous garder ? (séparez par des virgules)");
            string desAGarderString = Console.ReadLine();
            string[] desAGarderTab = desAGarderString.Split(',');
            for (int i = 0; i < desAGarderTab.Length; i++)
            {
                try
                {
                    int valeur = int.Parse(desAGarderTab[i]);
                    if (valeur >= 1 && valeur <= 5)                            
                    {
                        desAGarder.Add(valeur);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur de saisie, veuillez entrer des chiffres.");
                    Console.WriteLine("");
                }
            }
        

            for (int j = 0; j < lancer.Length; j++)
            {
                if (!desAGarder.Contains(j + 1))
                {
                    lancer[j] = lancerDe();
                }
            }
    }

        Console.WriteLine("");
        affichage(lancer);
        return lancer;
    }

public static string Challenge(ref List<string> ListeChallenge, int[] lancer, ref int points, ref int somme, ref int bonus)
    {
        affichageChallenge(ListeChallenge);

        Console.WriteLine("");

        Console.WriteLine("Entrer le numero du challenge: ");
        string choixString = Console.ReadLine();
        int choix = 0;
        try
        {
            choix = int.Parse(choixString);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erreur de saisie, veuillez entrer un numero valide.");
            Console.WriteLine("");
        }

        Console.WriteLine("");

        while (choix < 1 || choix > ListeChallenge.Count)
        {
            Console.WriteLine("Entrer le numero du challenge: ");
            choixString = Console.ReadLine();
            try
            {
                choix = int.Parse(choixString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Erreur de saisie, veuillez entrer un numero valide.");
                Console.WriteLine("");
            }
        }

        string nomChallenge = ListeChallenge[choix - 1];
        switch (nomChallenge)
        {
            case "nombre1":
                points = nombre1(lancer);
                somme += points;
                bonus += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "nombre2":
                points = nombre2(lancer);
                somme += points;
                bonus += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "nombre3":
                points = nombre3(lancer);
                somme += points;
                bonus += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "nombre4":
                points = nombre4(lancer);
                somme += points;
                bonus += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "nombre5":
                points = nombre5(lancer);
                somme += points;
                bonus += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "nombre6":
                points = nombre6(lancer);
                somme += points;
                bonus += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "brelan":
                points = brelan(lancer);
                somme += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "carre":
                points = carre(lancer);
                somme += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "full":
                points = full(lancer);
                somme += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "petite":
                points = petite(lancer);
                somme += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "grande":
                points = grande(lancer);
                somme += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "yams":
                points = yams(lancer);
                somme += points;
                ListeChallenge.Remove(nomChallenge);
                break;
            case "chance":
                points = chance(lancer);
                somme += points;
                ListeChallenge.Remove(nomChallenge);
                break;
        }

        return nomChallenge;
    }

    public static void affichageChallenge(List<string> ListeChallenge)
    {
        Console.WriteLine("Liste des challenges disponibles: ");
        for (int i = 0; i < ListeChallenge.Count; i++)
        {
            Console.WriteLine((i+1) + ". " + ListeChallenge[i]);
        }
        Console.WriteLine("");
    }

    public static int nombre1(int[] lancer)
    {
        int somme1 = 0;

        Console.WriteLine("Nombre de 1: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (lancer[i] == 1)
            {
                somme1 += 1;
            }
        }

        Console.WriteLine("{0} points gagnés", somme1);
        return somme1;
        
    }

    public static int nombre2(int[] lancer)
    {
        int somme2 = 0;

        Console.WriteLine("Nombre de 2: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (lancer[i] == 2)
            {
                somme2 += 2;
            }
        }

        Console.WriteLine("{0} points gagnés", somme2);
        return somme2;
        
    }

    public static int nombre3(int[] lancer)
    {
        int somme3 = 0;

        Console.WriteLine("Nombre de 3: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (lancer[i] == 3)
            {
                somme3 += 3;
            }
        }

        Console.WriteLine("{0} points gagnés", somme3);
        return somme3;
        
    }

    public static int nombre4(int[] lancer)
    {
        int somme4 = 0;

        Console.WriteLine("Nombre de 4: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (lancer[i] == 4)
            {
                somme4 += 4;
            }
        }

        Console.WriteLine("{0} points gagnés", somme4);
        return somme4;
    }

    public static int nombre5(int[] lancer)
    {
        int somme5 = 0;

        Console.WriteLine("Nombre de 5: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (lancer[i] == 5)
            {
                somme5 += 5;
            }
        }

        Console.WriteLine("{0} points gagnés", somme5);
        return somme5;
        
    }

    public static int nombre6(int[] lancer)
    {
        int somme6 = 0;

        Console.WriteLine("Nombre de 6: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (lancer[i] == 6)
            {
                somme6 += 6;
            }
        }

        Console.WriteLine("{0} points gagnés", somme6);
        return somme6;
        
    }

    public static int brelan(int[] lancer)
    {
        Console.WriteLine("Brelan: ");
        int sommebrelan = 0;
        int compte = 0;
        for (int i = 0; i < lancer.Length; i++)
        {
            compte = 0;
            for (int j = 0; j < lancer.Length; j++)
            {
                if (lancer[j]==lancer[i])
                {
                    compte +=1;
                }
            }
            if (compte >= 3)
            {  
                sommebrelan = 3 * lancer[i];
                break;
            }
        }
        

        if (compte >= 3)
        {
            Console.WriteLine("{0} points gagnés", sommebrelan);
            return sommebrelan;
        }
        else
        {
            Console.WriteLine("Condition non remplie : 0 point gagné.");
            return 0;
        }
    }

    public static int carre(int[] lancer)
    {
        Console.WriteLine("Carré: ");
        int sommecarre = 0;
        int compte = 0;
        for (int i = 0; i < lancer.Length; i++)
        {
            compte=0;

            for (int j = 0; j < lancer.Length; j++)
            {
                if (lancer[j]==lancer[i])
                {
                    compte +=1;
                }
            }
            if (compte >= 4)
            {
                sommecarre = 4 * lancer[i];
                break;
            }
        }
        

        if (compte >= 4)
        {
            Console.WriteLine("{0} points gagnés", sommecarre);
            return sommecarre;
        }
        else
        {
            Console.WriteLine("Condition non remplie : 0 point gagné.");
            return 0;
        }
    }

    public static int full(int[] lancer)
    {
        Console.WriteLine("Full: ");
        int var1 = 0;
        int var2 = 0;
        for (int i = 0; i < lancer.Length; i++)
        {
            if (lancer[0] == lancer[i])
            {
                var1 += 1;
            }
            else
            {
                var2 += 1;
            }
        }
        if ((var1 == 2 && var2 == 3) || (var1 == 3 && var2 == 2))
        {
            Console.WriteLine("25 points gagnés.");
            return 25;
        }
        else
        {
            Console.WriteLine("Condition non remplie.");
            return 0;
        }

    }
    public static int petite(int[] lancer)
    {
        List<int> suite1 = new List<int> {1, 2, 3, 4};
        List<int> suite2 = new List<int> {2, 3, 4, 5};
        List<int> suite3 = new List<int> {3, 4, 5, 6};

        Console.WriteLine("Petite Suite: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (suite1.Contains(lancer[i]))
            {
                suite1.Remove(lancer[i]);
            }
            if (suite2.Contains(lancer[i]))
            {
                suite2.Remove(lancer[i]);
            }
            if (suite3.Contains(lancer[i]))
            {
                suite3.Remove(lancer[i]);
            }
        }

        if (suite1.Count == 0 || suite2.Count == 0 || suite3.Count == 0)
        {
            Console.WriteLine("30 points gagnés. ");
            return 30;
        }

        else
        {
            Console.WriteLine("Condition non remplie: 0 point gagné. ");
            return 0;
        }
    
    }

    public static int grande(int[] lancer)
    {
        List<int> suite1 = new List<int> {1, 2, 3, 4, 5};
        List<int> suite2 = new List<int> {2, 3, 4, 5, 6};

        Console.WriteLine("Grande Suite: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            if (suite1.Contains(lancer[i]))
            {
                suite1.Remove(lancer[i]);
            }
            if (suite2.Contains(lancer[i]))
            {
                suite2.Remove(lancer[i]);
            }
        }

        if (suite1.Count == 0 || suite2.Count == 0)
        {
            Console.WriteLine("40 points gagnés. ");
            return 40;
        }

        else
        {
            Console.WriteLine("Condition non remplie: 0 point gagné. ");
            return 0;
        }
    
    }

    public static int yams(int[] lancer)
    {
        Console.WriteLine("Yam's: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            int compte = 0;

            for (int j = 0; j < lancer.Length; j++)
            {
                if (lancer[j] == lancer[i])
                {
                    compte += 1;
                }
            }

            if (compte >= 5)
            {
                Console.WriteLine("50 points gagnés. ");
                return 50;
            }

        }

        Console.WriteLine("Condition non remplie: 0 point gagné. ");
        return 0;

    }

    public static int chance(int[] lancer)
    {
        int sommechance = 0;

        Console.WriteLine("Chance: ");

        for (int i = 0; i < lancer.Length; i++)
        {
            sommechance += lancer[i];
        }

        Console.WriteLine("{0} points gagnés", sommechance);
        return sommechance;
    }

    public static void VerifBonus(ref int somme, ref int bonus)
    {
        if (bonus >= 63)
        {
            Console.WriteLine("Bonus gagné !");
            Console.WriteLine("35 points gagnés.");
            somme += 35;
            bonus=35;
        }
        else
        {
            bonus = 0;
        }
    }

    public static object[] Tour(int id, ref List<string> ListeChallenge, ref int somme, ref int bonus)
    {

        int points = 0;

        int[] lancer = lancerDes();

        Console.WriteLine("");

        affichage(lancer);

        Console.WriteLine("");

        affichageChallenge(ListeChallenge);

        Console.WriteLine("");

        lancer = relance(lancer);
        lancer = relance(lancer);

        Console.WriteLine("");

        string ChallengeUse = Challenge(ref ListeChallenge, lancer, ref points, ref somme, ref bonus);

        Console.WriteLine("");

        return new object[] { id, lancer, ChallengeUse, points };
    }

    public static void FinJeu(string j1, string j2, ref int somme1, ref int somme2)
    {
        Console.WriteLine("Score de {0} : {1}.", j1, somme1);
        Console.WriteLine("Score de {0} : {1}.", j2, somme2);
        if (somme1 < somme2)
        {
            Console.WriteLine("Le vainqueur est : {0}.", j2);
        }
        else if (somme1 > somme2)
        {
            Console.WriteLine("Le vainqueur est : {0}.", j1);
        }
        else
        {
            Console.WriteLine("Egalité.");
        }
    }

    public static void Jeu()
    {
        creerJson();

        Logo();

        string j1 = nomJoueur(1);
        string j2 = nomJoueur(2);

        creerJoueurs(j1, j2);
        
        Console.WriteLine("");

        int somme1 = 0;
        int somme2 = 0;

        int bonus1 = 0;
        int bonus2 = 0;

        List<string> challenge1 = ListeChallenge();
        List<string> challenge2 = ListeChallenge();

        creerRoundCat();

        for (int i = 1; i <= 13; i++)
        {


            object[] result1 = new object[3];
            object[] result2 = new object[3];

            Console.WriteLine("Tour n°{0}", i);
            Console.WriteLine("");

            Console.WriteLine("==================================================");

            Console.WriteLine("Au tour de {0}.", j1);

            result1 = Tour(1, ref challenge1, ref somme1, ref bonus1);
            Console.WriteLine("Score : {0}", somme1);

            
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("==================================================");


            Console.WriteLine("Au tour de {0}.", j2);
            result2 = Tour(2, ref challenge2, ref somme2, ref bonus2);
            Console.WriteLine("Score : {0}", somme2);

            Console.WriteLine("");

            creerRoundTour(i, result1, result2);

        }

        VerifBonus(ref somme1, ref bonus1);
        VerifBonus(ref somme2, ref bonus2);

        Console.WriteLine("");

        FinJeu(j1, j2, ref somme1, ref somme2);

        creerFinResult(ref somme1, ref somme2, ref bonus1, ref bonus2);
    }
    public static void Main()
    {
        Jeu();
    }
}