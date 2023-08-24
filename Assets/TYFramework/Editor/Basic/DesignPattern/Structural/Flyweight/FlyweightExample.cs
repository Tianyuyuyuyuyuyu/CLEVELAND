using System.Collections.Generic;
using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Flyweight
{
    public class FlyweightExample : MonoBehaviour
    {
        void Start()
        {
            var school = new School();
            var student = school.GetStudent(1);
            Debug.LogError(student.ToString());

            student = school.GetStudent(2);
            Debug.LogError(student.ToString());
        }
    }

    public abstract class AbStudent
    {
        public string Name;
        public string SchName;
        public string Sex;

        public AbStudent()
        {
            SchName = "吉林大学";
            Sex = "男";
        }

        public override string ToString()
        {
            return string.Format($"我叫{Name}, 性别{Sex}, 在读学校{SchName}");
        }
    }

    public class Student : AbStudent
    {
        public Student(string name)
        {
            Name = name;
        }
    }
    
    public class School
    {
        private Dictionary<int, AbStudent> _students;
        public School()
        {
            _students = new Dictionary<int, AbStudent>
            {
                { 1, new Student("张三") },
                { 2, new Student("李四") }
            };
        }

        public Student GetStudent(int key)
        {
            return _students[key] as Student;
        }
    }
}
