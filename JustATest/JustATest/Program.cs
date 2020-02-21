using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory<Car> carFactory = new Factory<Car>();
            Factory<Plane> planeFactory = new Factory<Plane>();
            var planeFrame = carFactory.Create<Frame>();
            var carFrame = planeFactory.Create<Frame>();

            IProduct<Car> carProduct = carFactory.Create<Toyota>();
            carProduct = carFactory.Create<Engine<Car>>();
            carProduct.Operate();

            IProduct<Plane> planeProduct = planeFactory.Create<Engine<Plane>>();
        }
    }

    interface IFactory<TFactory> where TFactory : new()
    {
        TProduct Build<TProduct>() where TProduct : IProduct<TFactory>, new();
    }

    class Car : IFactory<Car>
    {
        public TProduct Build<TProduct>() where TProduct : IProduct<Car>, new()
        {
            Console.WriteLine("Creating Car: " + typeof(TProduct));
            return new TProduct();
        }
    }

    class Plane : IFactory<Plane>
    {
        public TProduct Build<TProduct>() where TProduct : IProduct<Plane>, new()
        {
            Console.WriteLine("Creating Plane: " + typeof(TProduct));
            return new TProduct();
        }
    }

    interface IProduct<TFactory>
    {
        void Operate();
    }

    class Toyota : IProduct<Car>
    {
        public void Operate()
        {
            Console.WriteLine("Driving Toyota.");
        }

        public void ToyotaSpecificOperation()
        {
            Console.WriteLine("Performing Toyota-specific operation.");
        }
    }

    class Boeing : IProduct<Plane>
    {
        public void Operate()
        {
            Console.WriteLine("Flying Boeing.");
        }

        public void BoeingSpecificOperation()
        {
            Console.WriteLine("Performing Boeing-specific operation.");
        }
    }

    class Saab : IProduct<Car>, IProduct<Plane>
    {
        public void Operate()
        {
            Console.WriteLine("Operating Saab.");
        }

        public void SaabSpecificOperation()
        {
            Console.WriteLine("Performing Saab-specific operation.");
        }
    }


    class Engine<TFactory> : IProduct<TFactory>
    {
        public void Operate()
        {
            Console.WriteLine("Operating Engine.");
        }

        public void EngineSpecificOperation()
        {
            Console.WriteLine("Performing Engine-specific operation.");
        }
    }

    class Frame : IProduct<Car>, IProduct<Plane>
    {
        public void Operate()
        {
            Console.WriteLine("Operating Frame.");
        }

        public void FrameSpecificOperation()
        {
            Console.WriteLine("Performing Frame-specific operation.");
        }
    }

    class Factory<TFactory> where TFactory : IFactory<TFactory>, new()
    {
        public TProduct Create<TProduct>() where TProduct : IProduct<TFactory>, new()
        {
            return new TFactory().Build<TProduct>();
        }
    }
}
