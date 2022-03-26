/*
 Придумать класс, описывающий студента. Предусмотреть в нем следующие моменты: фамилия, имя, 
отчество, группа, возраст, массив (зубчатый) оценок по 
программированию, администрированию и дизайну.
А также добавить методы по работе с перечисленными 
данными: возможность установки/получения оценки, получение среднего балла по заданному предмету, 
распечатка данных о студенте
 */

using System.Runtime.InteropServices;

namespace ConsoleStudent;

public class Student
{
    private enum Predmets
    {
        Programming = 0,
        Administration,
        Disain
    }

    private readonly static Dictionary<Predmets, string> InfoPredmets = new Dictionary<Predmets, string>
    {
        {
            Predmets.Programming, "Программирование"
        },
        {
            Predmets.Administration, "Администрирование"
        },
        {
            Predmets.Disain, "Дизайн"
        }
    };

    private string name;
    private string secondname;
    private string surname;
    private string group;
    private int yearsold;

    private List<int>[] Balls;
    private float[] mediumBalls;

    public Student()
    {
        Console.WriteLine("Введите имя отчество и фамилию студента ");
        string str_in = Console.ReadLine();
        string[] strs = str_in.Split();
        this.name = strs[0];
        this.secondname = strs[1];
        this.surname = strs[2];

        Console.WriteLine("Введите группу");
        this.group = Console.ReadLine();
        Console.WriteLine("Введите возраст ");
        this.yearsold = Int32.Parse(Console.ReadLine());

        Balls = new List<int>[3];

        this.Balls[0] = new List<int>();
        this.Balls[1] = new List<int>();
        this.Balls[2] = new List<int>();

        mediumBalls = new float[3];
    }

    public static void PrintPredmets()
    {
        Console.WriteLine("-----------------------------");
        foreach (var value in Enum.GetValues(typeof(Predmets)))
            Console.Write((int) value + " - " + InfoPredmets[(Predmets) value] + "; ");

        Console.WriteLine("\n-----------------------------");
    }

    public void AddBall()
    {
        Console.WriteLine("Выберите предмет(0-2):");
        PrintPredmets();
        int n = Int32.Parse(Console.ReadLine());

        string newball = "Y";
        int ball;
        while (newball == "Y")
        {
            Console.WriteLine("Введите оценку по предмету " + InfoPredmets[(Predmets) n]);
            ball = Int32.Parse(Console.ReadLine());
            Balls[n].Add(ball);
            Console.WriteLine("Продолжть? (Y)");
            newball = Console.ReadLine();
        }
    }

    public void print()
    {
        Console.WriteLine("Студент : " + this.name + " " + this.secondname + " " + this.surname);
        Console.WriteLine("Группа " + this.group);
        Console.WriteLine("Возраст " + this.yearsold + " лет");

        foreach (Predmets predmet in Enum.GetValues(typeof(Predmets)))
        {
            float medBall = 0;
            Console.WriteLine("Оценки по предмету " + InfoPredmets[predmet]);
            foreach (var ball in Balls[(int)predmet])
            {
                Console.Write(ball + " ");
                medBall += ball;
            }

            if (medBall > 0) medBall = medBall / Balls[(int)predmet].Count;
            Console.WriteLine("Средний балл по предмету " + medBall);
            mediumBalls[(int)predmet] = medBall;
        }
    }
}