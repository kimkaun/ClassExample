using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample
{
    class Program
    {
        class Parent
        {
            public int variable = 273;
            public new void Method() { Console.WriteLine("부모의 메서드"); }
            public void MethodO() { Console.WriteLine("부모의 메서드"); }
            public static int counter = 0;
            public void CounterParent()
            {
                Parent.counter++;
            }
            public Parent() {
                Console.WriteLine("Parent()");  
            }
            public Parent(int Param)
            {
                Console.WriteLine("Parent(int param)");
            }
            public Parent(string param)
            {
                Console.WriteLine("Parent(string param)");
            }
            //public Parent(string name)
            //{
            //    Console.WriteLine("부모 생성자2");
            //}
        }
        class Child : Parent
        {
            public new string variable = "하이딩";
            public new void Method() { Console.WriteLine("자식의 메서드"); }
            //public override void MethodO() { Console.WriteLine("자식의 메서드"); }
            public void CounterChild()
            {
                Child.counter++;
            }
            public Child() : base(10)
            {
                Console.WriteLine("Child() : base(10)");
            }

            public Child(string input) : base(input)
            {
                Console.WriteLine("Child(string input) : base(input)");
            }
        }

        public static int number = 10;  // 가려진 부모 변수

        static void Main(string[] args)
        {
            // 섀도잉
            int number = 20;        // 섀도잉 예 number 클래스 변수가 지연 변수로 가려짐
            Console.WriteLine(number);
            Console.WriteLine(Program.number);

            // 하이딩
            Child c = new Child();
            Console.WriteLine(c.variable);
            Console.WriteLine(((Parent)c).variable); // 하이딩 된 부모의 변수 접근
            Console.WriteLine((c as Parent).variable);  // 하이딩 된 부모의 변수 접근
            c.Method();
            ((Parent)c).Method();  // 하이딩 된 부모의 메서드 접근

            // 오버라이딩
            c.Method();
            ((Parent)c).MethodO();      // 오버라이딩 된 부모의  메서드 접근(자식 메서드 내용으로 덮어써짐)

            Child childA = new Child();
            Child childB = new Child("string");

            Parent parent = new Parent();
            Child child = new Child();

            parent.CounterParent();
            child.CounterParent();
            Console.WriteLine(Parent.counter);
            Console.WriteLine(Child.counter);
        }
    }
}
