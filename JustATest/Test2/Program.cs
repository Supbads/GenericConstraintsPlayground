using System;

namespace Test2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var classche = new Wrap();
            var name1= nameof(classche);
            var type1= typeof(Wrap);
            var name11 = type1.Name;

            var serviceche = new Service<int, Dto>(classche);

            var generic = new Generic<int, Dto2>();
            var name2 = nameof(generic);
            var type2 = typeof(Generic<int, Dto2>);
            var name22 = type2.Name;
            var serviceche2 = new Service<int, Dto2>(generic);
        }
    }

    public class Service<TKey, TVal>
        where TVal : class, new()
    {
        private readonly Generic<TKey, TVal> module;

        public Service(Generic<TKey,TVal> module)
        {
            this.module = module;
        }
    }

    public class Dto
    {
        public Dto()
        {
        }

        public int TestProp { get; set; }
    }

    public class Dto2
    {
        public Dto2()
        {
        }

        public int TestProp2 { get; set; }
    }

    public class Wrap : Generic<int, Dto>
    {

    }

    public class Generic<TKey, TVal> where TVal : class, new()
    { 
        public void Method()
        {
            Console.WriteLine("Invoked");
        }
    }
}
