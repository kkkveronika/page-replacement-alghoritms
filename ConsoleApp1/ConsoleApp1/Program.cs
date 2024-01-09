using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        //ПОЛИМОРФИЗМ - это свойство одних и тех же объектов и методов принимать разные формы.
        //То есть нужды запоминать кучу имён методов, которые совершают одинаковые действия с разными типами данных.
        //Что нужно запомнить: метод идентифицируется не только по имени, но и по его параметрам.
        //Полиморфизм это ПЕРЕГРУЗКА 

        //приветствие пользователь noname
        void Hello()
        {
            Console.WriteLine("Привет");
        }

        //приветствие зареганного пользователя
        void Hello(string name)
        {
            Console.WriteLine("Привет" + name);
        }
        //Изменили передаваемое значение, но название одно: Hello

        //ИНКАПСУЛЯЦИЯ - это возможность (механизм) с помощью которой мы можем спрятать от
        //конечного пользователя реализацию того или иного метода,
        //устройства объекта и так далее и представить в пользование только то, что необходимо для работы,
        //обеспечив тем самым целостность объекта.
        //В C# для инкапсуляции используются публичные (public) свойства и методы объекта,
        //а переменные (за очень редким исключением) остаются закрытыми (private) от пользователя.


        //НАСЛЕДОВАНИЕ - Благодаря наследованию один класс может унаследовать функциональность другого класса.

        //класс Человек
        class Person: Program
        {
            private string name = "";
            private int age = 0;
            public string Name { get { return name; } set {name=value; } }
            public int Age { get { return age; } set { age = value; } }

            public void get_info()
            {
                Console.WriteLine(Name, Age);
            }
        }

        //класс Студент, имеет те же данные, что и человек, поэтому для описания студента можно взять методы из класса человек

        class Student : Person
        {
            public int group { get; set; }
        }

        //Создаем объект человек
        Person person = new Person {Name="Tom", Age=12 };
        Student stud = new Student { };
        
        
    }
}