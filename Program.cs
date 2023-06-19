// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaNomina
{
    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool salir = false;

            do
            {
                Console.WriteLine("=== Sistema de Nómina ===");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Ver empleados");
                Console.WriteLine("3. Eliminar empleado");
                Console.WriteLine("4. Ver toda la nómina");
                Console.WriteLine("5. Empleados que son mujeres");
                Console.WriteLine("6. Empleados que poseen licencia");
                Console.WriteLine("7. Empleados que ganan por encima de los 50,000");
                Console.WriteLine("8. Posiciones de empleados");
                Console.WriteLine("9. Salir");

                Console.Write("Ingrese la opción deseada: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarEmpleado();
                        break;
                    case "2":
                        VerEmpleados();
                        break;
                    case "3":
                        EliminarEmpleado();
                        break;
                    case "4":
                        VerNominaCompleta();
                        break;
                    case "5":
                        VerEmpleadosMujeres();
                        break;
                    case "6":
                        VerEmpleadosConLicencia();
                        break;
                    case "7":
                        VerEmpleadosSalarioMayor();
                        break;
                    case "8":
                        VerPosicionesEmpleados();
                        break;
                    case "9":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            } while (!salir);
        }

        static void AgregarEmpleado()
        {
            Console.WriteLine("=== Agregar Empleado ===");

            Empleado empleado = new Empleado();

            Console.Write("Nombre: ");
            empleado.Nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            empleado.Apellido = Console.ReadLine();

            Console.Write("Edad: ");
            empleado.Edad = int.Parse(Console.ReadLine());

            Console.Write("Sexo (M/F): ");
            empleado.Sexo = char.Parse(Console.ReadLine());

            Console.Write("Fecha de Nacimiento (dd/mm/aaaa): ");
            empleado.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Posee Licencia (S/N): ");
            empleado.PoseeLicencia = Console.ReadLine().ToUpper() == "S";

            Console.Write("Sueldo Bruto: ");
            empleado.SueldoBruto = decimal.Parse(Console.ReadLine());

            Console.Write("Sueldo Neto: ");
            empleado.SueldoNeto = decimal.Parse(Console.ReadLine());

            Console.Write("TSS: ");
            empleado.TSS = decimal.Parse(Console.ReadLine());

            Console.Write("Impuesto sobre la Renta: ");
            empleado.ImpuestoRenta = decimal.Parse(Console.ReadLine());

            Console.Write("Posición: ");
            empleado.Posicion = Console.ReadLine();

            empleados.Add(empleado);

            GuardarEmpleadosEnArchivo();

            Console.WriteLine("Empleado agregado exitosamente.");
        }

        static void VerEmpleados()
        {
            Console.WriteLine("=== Empleados ===");

            if (empleados.Count > 0)
            {
                for (int i = 0; i < empleados.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {empleados[i].Nombre} {empleados[i].Apellido}");
                }
            }
            else
            {
                Console.WriteLine("No hay empleados registrados.");
            }
        }

        static void EliminarEmpleado()
        {
            Console.WriteLine("=== Eliminar Empleado ===");

            VerEmpleados();

            if (empleados.Count > 0)
            {
                Console.Write("Ingrese el número del empleado que desea eliminar: ");
                int indice = int.Parse(Console.ReadLine()) - 1;

                if (indice >= 0 && indice < empleados.Count)
                {
                    Empleado empleadoEliminado = empleados[indice];
                    empleados.RemoveAt(indice);

                    GuardarEmpleadosEnArchivo();

                    Console.WriteLine($"Se ha eliminado al empleado: {empleadoEliminado.Nombre} {empleadoEliminado.Apellido}");
                }
                else
                {
                    Console.WriteLine("Número de empleado inválido.");
                }
            }
            else
            {
                Console.WriteLine("No hay empleados registrados.");
            }
        }

        static void VerNominaCompleta()
        {
            Console.WriteLine("=== Nómina de Empleados ===");

            if (empleados.Count > 0)
            {
                foreach (Empleado empleado in empleados)
                {
                    Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellido}");
                    Console.WriteLine($"Edad: {empleado.Edad}");
                    Console.WriteLine($"Sexo: {empleado.Sexo}");
                    Console.WriteLine($"Fecha de Nacimiento: {empleado.FechaNacimiento.ToShortDateString()}");
                    Console.WriteLine($"Posee Licencia: {(empleado.PoseeLicencia ? "Sí" : "No")}");
                    Console.WriteLine($"Sueldo Bruto: {empleado.SueldoBruto:C}");
                    Console.WriteLine($"Sueldo Neto: {empleado.SueldoNeto:C}");
                    Console.WriteLine($"TSS: {empleado.TSS:C}");
                    Console.WriteLine($"Impuesto sobre la Renta: {empleado.ImpuestoRenta:C}");
                    Console.WriteLine($"Posición: {empleado.Posicion}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay empleados registrados.");
            }
        }

        static void VerEmpleadosMujeres()
        {
            Console.WriteLine("=== Empleados Mujeres ===");

            List<Empleado> empleadosMujeres = empleados.FindAll(e => e.Sexo == 'F');

            if (empleadosMujeres.Count > 0)
            {
                foreach (Empleado empleado in empleadosMujeres)
                {
                    Console.WriteLine($"{empleado.Nombre} {empleado.Apellido}");
                }
            }
            else
            {
                Console.WriteLine("No hay empleadas mujeres registradas.");
            }
        }

        static void VerEmpleadosConLicencia()
        {
            Console.WriteLine("=== Empleados con Licencia ===");

            List<Empleado> empleadosConLicencia = empleados.FindAll(e => e.PoseeLicencia);

            if (empleadosConLicencia.Count > 0)
            {
                foreach (Empleado empleado in empleadosConLicencia)
                {
                    Console.WriteLine($"{empleado.Nombre} {empleado.Apellido}");
                }
            }
            else
            {
                Console.WriteLine("No hay empleados con licencia registrados.");
            }
        }

        static void VerEmpleadosSalarioMayor()
        {
            Console.WriteLine("=== Empleados con Salario Mayor a 50,000 ===");

            List<Empleado> empleadosSalarioMayor = empleados.FindAll(e => e.SueldoBruto > 50000);

            if (empleadosSalarioMayor.Count > 0)
            {
                foreach (Empleado empleado in empleadosSalarioMayor)
                {
                    Console.WriteLine($"{empleado.Nombre} {empleado.Apellido}");
                }
            }
            else
            {
                Console.WriteLine("No hay empleados con salario mayor a 50,000.");
            }
        }

        static void VerPosicionesEmpleados()
        {
            Console.WriteLine("=== Posiciones de Empleados ===");

            if (empleados.Count > 0)
            {
                List<string> posiciones = new List<string>();

                foreach (Empleado empleado in empleados)
                {
                    if (!posiciones.Contains(empleado.Posicion))
                    {
                        posiciones.Add(empleado.Posicion);
                    }
                }

                foreach (string posicion in posiciones)
                {
                    Console.WriteLine(posicion);
                }
            }
            else
            {
                Console.WriteLine("No hay empleados registrados.");
            }
        }

        static void GuardarEmpleadosEnArchivo()
        {
            using (StreamWriter writer = new StreamWriter("nomina.txt"))
            {
                foreach (Empleado empleado in empleados)
                {
                    writer.WriteLine(empleado.Nombre);
                    writer.WriteLine(empleado.Apellido);
                    writer.WriteLine(empleado.Edad);
                    writer.WriteLine(empleado.Sexo);
                    writer.WriteLine(empleado.FechaNacimiento.ToShortDateString());
                    writer.WriteLine(empleado.PoseeLicencia);
                    writer.WriteLine(empleado.SueldoBruto);
                    writer.WriteLine(empleado.SueldoNeto);
                    writer.WriteLine(empleado.TSS);
                    writer.WriteLine(empleado.ImpuestoRenta);
                    writer.WriteLine(empleado.Posicion);
                }
            }
        }
    }

    class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool PoseeLicencia { get; set; }
        public decimal SueldoBruto { get; set; }
        public decimal SueldoNeto { get; set; }
        public decimal TSS { get; set; }
        public decimal ImpuestoRenta { get; set; }
        public string Posicion { get; set; }
    }
}
