using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Student_Data> DATA = new List<Student_Data>()
        {
            new Student_Data("Alice", new List<int> { 90, 80, 70 }),
            new Student_Data("Bob", new List<int> { 60, 75, 85 }),
            new Student_Data("Charlie", new List<int> { 100, 90, 95 }),
            new Student_Data("Daisy", new List<int> { 50, 40, 30 })
        };

        PrintData(DATA);
    }

    static void PrintData(List<Student_Data> studentData)
    {
        Console.WriteLine($"Average: {Math.Round(ClassAverage(studentData), 2)}");
        Console.WriteLine($"Top Student: {GetTopStudent(studentData).Name}");
        Console.WriteLine($"Passing Amount: {PassingStudentCount(studentData)}");

        Console.WriteLine("\nInfo:");
        foreach (var student in studentData)
        {
            Console.WriteLine($"{student.Name} -> {Math.Round(student.Average(), 2)} ({CalculateGrade(student.Average())})");
        }
    }

    static double ClassAverage(List<Student_Data> studentData)
    {
        double total = 0;

        foreach (var studentScore in studentData)
        {
            total += studentScore.Average();
        }
        return total / studentData.Count;
    }

    static Student_Data GetTopStudent(List<Student_Data> studentList)
    {
        Student_Data topStudent = studentList[0];

        foreach (var student in studentList)
        {
            if (student.Average() > topStudent.Average())
            {
                topStudent = student;
            }
        }

        return topStudent;
    }

    static int PassingStudentCount(List<Student_Data> studentData)
    {
        int count = 0;

        foreach (var student in studentData)
        {
            if (IsPassing(student.Average()))
            {
                count++;
            }
        }

        return count;
    }

    static bool IsPassing(double number)
    {
        if (number > 60)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static string CalculateGrade(double grade)
    {
        if (grade >= 90) return "A";
        if (grade >= 80) return "B";
        if (grade >= 70) return "C";
        if (grade >= 60) return "D";
        return "F";
    }
}

class Student_Data
{
    public string Name { get; set; }
    public List<int> Scores { get; set; }

    public Student_Data(string name, List<int> scores)
    {
        Name = name;
        Scores = scores;
    }

    public double Average()
    {
        int total = 0;

        for (int i = 0; i < Scores.Count; i++)
        {
            total += Scores[i];
        }

        return (double)total / Scores.Count;
    }
}