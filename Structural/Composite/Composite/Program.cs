using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            Test2();

        }

        private static void Test2()
        {
            var neuronLayer = new NeuronLayer();

            var neuronLayer2 = new NeuronLayer();

            neuronLayer.ConnectTo(neuronLayer2);

            var neuron = new Neuron();
            var otherNeuron = new Neuron();
            neuron.ConnectTo(otherNeuron);
            neuron.ConnectTo(neuronLayer);
            neuronLayer.ConnectTo(neuron);

            
        }

        private static void Test1()
        {
            var graphicObject = new GraphicObject() { Name = "My Drawing" };

            graphicObject.Children.Add(new Square() { Color = "Red" });
            graphicObject.Children.Add(new Circle() { Color = "Red" });

            var group = new GraphicObject();

            group.Children.Add(new Square() { Color = "Yellow" });
            group.Children.Add(new Circle() { Color = "Yellow" });

            graphicObject.Children.Add(group);

            Console.WriteLine(graphicObject);
        }
    }
}
