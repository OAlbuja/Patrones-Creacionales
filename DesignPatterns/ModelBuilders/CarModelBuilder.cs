using System;
using System.Runtime.CompilerServices;
using DesignPatterns.Models;
namespace DesignPatterns.ModelBuilders
{
    public class CarModelBuilder
    {
        private string _color = "red";
        private string _brand = "Ford";
        private string _model = "Mustang";
        private int _year = DateTime.Now.Year; //especificando el año actual segun el documento.

        //Metodos buildStep para construir el producto
        public CarModelBuilder SetColor(string color)
        {
            _color = color;
            return this;
        }

        public CarModelBuilder SetBrand(string brand)
        {
            _brand = brand;
            return this;
        }
        public CarModelBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }

        public CarModelBuilder SetYear(int year)
        {
            _year = year;
            return this;
        }

        //Metodo para construir el proyecto que sera llamado desde el Controllado. 
        public Vehicle Build()
        {
            return new Car(_color, _brand, _model, _year); //se encuentra un error en el que el constructor car no tiene 4 argumentos se procede a agregar el argumento year en el modelo Car.
        }

    }


}
