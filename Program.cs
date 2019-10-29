using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2doParcialEscanioDisla
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        private static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3);
        }
        static void Main(string[] args)
        {
            Maximize();
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            MenuPrincipal();
        }
        static void MenuPrincipal()
        {
            bool execute = false;

            for (int k = 0; ;)
            {
                DrawMenuPrincipal(k);
                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow: k--; break;
                    case ConsoleKey.DownArrow: k++; break;
                    case ConsoleKey.Enter: execute = true; break;
                }

                if (k < 0) k = 6; else if (k > 6) k = 0;

                if (execute)
                {
                    execute = false;
                    switch (k)
                    {
                        case 0: Console.Clear(); MenuEntidades(); break;
                        case 1: Console.Clear(); FacturaTXT(); break;
                        case 2: Console.Clear(); CustomerCSV(); break;
                        case 3: return;
                    }
                    Console.Clear();
                }
            }
        }
        static void DrawMenuPrincipal(int k)
        {
            ConsoleColor cc = ConsoleColor.Black;
            ConsoleColor sel = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("============ MENÚ PRINCIPAL ============");
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = k == 0 ? sel : cc;
            Console.WriteLine("- Mantenimiento de entidades");
            Console.SetCursorPosition(5, 7);
            Console.ForegroundColor = k == 1 ? sel : cc;
            Console.WriteLine("- Exportar una Factura en un archivo TXT");
            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = k == 2 ? sel : cc;
            Console.WriteLine("- Cargar archivo CSV de Clientes");
            Console.SetCursorPosition(5, 11);
            Console.ForegroundColor = k == 3 ? sel : cc;
            Console.WriteLine("- Salir");
            Console.SetCursorPosition(5, 13);
            Console.ForegroundColor = k == 4 ? sel : cc;
        }
        static void DrawMenuEntidades(int k)
        {
            ConsoleColor cc = ConsoleColor.DarkRed;
            ConsoleColor sel = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("============ MANTENIMIENTO DE ENTIDADES ============");
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = k == 0 ? sel : cc;
            Console.WriteLine("- Categorías");
            Console.SetCursorPosition(5, 7);
            Console.ForegroundColor = k == 1 ? sel : cc;
            Console.WriteLine("- Territorios");
            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = k == 2 ? sel : cc;
            Console.WriteLine("- Productos");
            Console.SetCursorPosition(5, 11);
            Console.ForegroundColor = k == 3 ? sel : cc;
            Console.WriteLine("- Salir");
        }
        static void DrawMenuCategory(int k)
        {
            ConsoleColor cc = ConsoleColor.DarkMagenta;
            ConsoleColor sel = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("******************* Mantenimiento de la entidad Categorías *******************");
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = k == 0 ? sel : cc;
            Console.WriteLine("- Insertar registro");
            Console.SetCursorPosition(5, 7);
            Console.ForegroundColor = k == 1 ? sel : cc;
            Console.WriteLine("- Actualizar registro");
            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = k == 2 ? sel : cc;
            Console.WriteLine("- Eliminar registro");
            Console.SetCursorPosition(5, 11);
            Console.ForegroundColor = k == 3 ? sel : cc;
            Console.WriteLine("- Mostrar todos los registros");
            Console.SetCursorPosition(5, 13);
            Console.ForegroundColor = k == 4 ? sel : cc;
            Console.WriteLine("- Salir");
        }
        static void DrawMenuProduct(int k)
        {
            ConsoleColor cc = ConsoleColor.Black;
            ConsoleColor sel = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("******************* Mantenimiento de la entidad Productos *******************");
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = k == 0 ? sel : cc;
            Console.WriteLine("- Insertar registro");
            Console.SetCursorPosition(5, 7);
            Console.ForegroundColor = k == 1 ? sel : cc;
            Console.WriteLine("- Actualizar registro");
            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = k == 2 ? sel : cc;
            Console.WriteLine("- Eliminar registro");
            Console.SetCursorPosition(5, 11);
            Console.ForegroundColor = k == 3 ? sel : cc;
            Console.WriteLine("- Mostrar todos los registros");
            Console.SetCursorPosition(5, 13);
            Console.ForegroundColor = k == 4 ? sel : cc;
            Console.WriteLine("- Salir");
        }
        static void DrawMenuTerritory(int k)
        {
            ConsoleColor cc = ConsoleColor.DarkRed;
            ConsoleColor sel = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("******************* Mantenimiento de la entidad Territorios *******************");
            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = k == 0 ? sel : cc;
            Console.WriteLine("- Insertar registro");
            Console.SetCursorPosition(5, 7);
            Console.ForegroundColor = k == 1 ? sel : cc;
            Console.WriteLine("- Actualizar registro");
            Console.SetCursorPosition(5, 9);
            Console.ForegroundColor = k == 2 ? sel : cc;
            Console.WriteLine("- Eliminar registro");
            Console.SetCursorPosition(5, 11);
            Console.ForegroundColor = k == 3 ? sel : cc;
            Console.WriteLine("- Mostrar todos los registros");
            Console.SetCursorPosition(5, 13);
            Console.ForegroundColor = k == 4 ? sel : cc;
            Console.WriteLine("- Salir");
        }
        static void MenuEntidades()
        {
            bool execute = false;
            for(int k = 0; ;)
            {
                DrawMenuEntidades(k);
                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow: k--; break;
                    case ConsoleKey.DownArrow: k++; break;
                    case ConsoleKey.Enter: execute = true; break;
                }

                if (k < 0) k = 4; else if (k > 4) k = 0;

                if(execute)
                {
                    execute = false;
                    switch(k)
                    {
                        case 0: Console.Clear();
                            MenuCategory();
                            break;

                        case 1: Console.Clear();
                            MenuTerritory();
                            break;

                        case 2: Console.Clear();
                            MenuProduct();
                            break;

                        case 3: return;
                    }
                    Console.Clear();
                }
            }
        }
        static void MenuCategory()
        {
            CategoryData cd = new CategoryData();
            Categories CT = new Categories();
            int IDCat;
            bool execute = false;

            for (int k = 0; ;)
            {
                DrawMenuCategory(k);
                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow: k--; break;
                    case ConsoleKey.DownArrow: k++; break;
                    case ConsoleKey.Enter: execute = true; break;
                }

                if (k < 0) k = 4; else if (k > 4) k = 0;

                if (execute)
                {
                    execute = false;
                    switch (k)
                    {
                        case 0: Console.Clear();
                            Console.Write("\n Ingrese el nombre de la categoría que desea agregar: ");
                            CT.CategoryName = Console.ReadLine();
                            while (!Regex.IsMatch(CT.CategoryName, @"[a-zA-Z]"))
                            {
                                Console.WriteLine("\n No se permiten números. Intente nuevamente: ");
                                Console.Write("\n Ingrese el nombre de la categoría que desea agregar: ");
                                CT.CategoryName = Console.ReadLine();
                            }
                            Console.WriteLine("\n Estamos procesando su petición.................\n");
                            cd.Agregar<Categories>(CT);
                            break;

                        case 1: Console.Clear();
                            Console.Write("\n Ingrese el código de la categoría que desea actualizar: ");
                            while (!int.TryParse(Console.ReadLine(), out IDCat))
                            {
                                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                            }
                            Console.WriteLine("\n Estamos procesando su búsqueda.................\n");
                            while (!cd.Listado<Categories>().Exists(c => c.CategoryID == IDCat))
                            {
                                Console.Write("\n Este código no pertenece a ninguna categoría registrada. Intente nuevamente: ");
                                IDCat = int.Parse(Console.ReadLine());
                            }
                            var resultCAT = cd.Listado<Categories>().Find(a => a.CategoryID == IDCat);
                            if (resultCAT != null && cd.Listado<Categories>().Exists(c => c.CategoryID == IDCat))
                            {
                                var ctNombre = cd.Model.Categories.Where(ct => ct.CategoryID == IDCat).Select(ctn => ctn).FirstOrDefault();
                                Console.Write("\n Categoría: " + ctNombre.CategoryName);
                                Console.Write("\n Ingrese el nuevo nombre de esta categoría: ");
                                CT.CategoryName = Console.ReadLine();
                                CT.CategoryID = IDCat;
                                cd.Model.Entry(resultCAT).State = EntityState.Detached;
                                cd.Actualizar<Categories>(CT);
                            }
                            break;
                        case 2: Console.Clear();
                            Console.Write("\n Ingrese el código de la categoría que desea eliminar: ");
                            while (!int.TryParse(Console.ReadLine(), out IDCat))
                            {
                                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                            }

                            while (!cd.Listado<Categories>().Exists(c => c.CategoryID == IDCat))
                            {
                                Console.Write("\n Este código no pertenece a ninguna categoría registrada. Intente nuevamente: ");
                                IDCat = int.Parse(Console.ReadLine());
                            }
                            var resultCT = cd.Listado<Categories>().Find(a => a.CategoryID == IDCat);
                            if (resultCT != null && cd.Listado<Categories>().Exists(c => c.CategoryID == IDCat))
                            {
                                CT.CategoryID = IDCat;
                                cd.Model.Entry(resultCT).State = EntityState.Detached;
                                cd.Eliminar<Categories>(CT);
                            }
                            break;
                        case 3: Console.Clear();
                            ConsoleTable TablaCAT = new ConsoleTable("Código", "Nombre");
                            foreach (Categories ListCAT in cd.Listado<Categories>())
                            {
                                TablaCAT.AddRow(ListCAT.CategoryID, ListCAT.CategoryName);
                            }
                            TablaCAT.Write(Format.Alternative);
                            break;
                        case 4: return;
                    }
                    Console.Write("\n");
                    Console.WriteLine("\n Presione Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        static void MenuProduct()
        {
            CategoryData cd = new CategoryData();
            Categories CT = new Categories();
            ProductData pd = new ProductData();
            Products PD = new Products();
            SupplierData sd = new SupplierData();
            Suppliers SP = new Suppliers();
            int SEL, IDProd, IDCat, IDSup;

            bool execute = false;

            for (int k = 0; ;)
            {
                DrawMenuProduct(k);
                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow: k--; break;
                    case ConsoleKey.DownArrow: k++; break;
                    case ConsoleKey.Enter: execute = true; break;
                }

                if (k < 0) k = 4; else if (k > 4) k = 0;

                if (execute)
                {
                    execute = false;
                    switch (k)
                    {
                        case 0:
                            Console.Clear();
                            Console.Write("\n Nombre del producto: ");
                            PD.ProductName = Console.ReadLine();
                            while (!Regex.IsMatch(PD.ProductName, @"[a-zA-Z]"))
                            {
                                Console.WriteLine("\n No se permiten números. Intente nuevamente: ");
                                Console.Write("\n Nombre del producto: ");
                                PD.ProductName = Console.ReadLine();
                            }
                            Console.Write("\n");
                            Console.Write("\n A continuación se presentan los suplidores registrados, favor ingresar el código del requerido para el nuevo producto. Presione Enter.");
                            Console.ReadLine();
                            ConsoleTable TablaSuplidores = new ConsoleTable("Código", "Nombre", "Teléfono", "Dirección");
                            foreach (Suppliers SUP in sd.Listado<Suppliers>())
                            {
                                TablaSuplidores.AddRow(SUP.SupplierID, SUP.CompanyName, SUP.Phone, SUP.Address);
                            }
                            TablaSuplidores.Write(Format.Alternative);
                            Console.Write("\n");

                            Console.Write("\n Código del suplidor: ");
                            while (!int.TryParse(Console.ReadLine(), out IDSup))
                            {
                                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                            }
                            while (!pd.Listado<Suppliers>().Exists(c => c.SupplierID == IDSup))
                            {
                                Console.Write("\n Este código no corresponde a ningún suplidor registrado. Intente nuevamente: ");
                                IDSup = int.Parse(Console.ReadLine());
                            }
                            if (pd.Listado<Suppliers>().Exists(s => s.SupplierID == IDSup))
                            {
                                PD.SupplierID = IDSup;
                            }

                            Console.Write("\n A continuación se presentan las categorías registradas, favor ingresar el código de la requerida para el nuevo producto:");
                            Console.Write("\n");
                            ConsoleTable TablaCAT = new ConsoleTable("Código", "Nombre");
                            foreach (Categories ListCAT in cd.Listado<Categories>())
                            {
                                TablaCAT.AddRow(ListCAT.CategoryID, ListCAT.CategoryName);
                            }
                            TablaCAT.Write(Format.Alternative);
                            Console.Write("\n");

                            Console.Write("\n Código de la categoría: ");
                            while (!int.TryParse(Console.ReadLine(), out IDCat))
                            {
                                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                            }

                            while (!pd.Listado<Categories>().Exists(c => c.CategoryID == IDCat))
                            {
                                Console.Write("\n Este código no corresponde a ninguna categoría registrada. Intente nuevamente: ");
                                IDCat = int.Parse(Console.ReadLine());
                            }
                            if (pd.Listado<Categories>().Exists(s => s.CategoryID == IDCat))
                            {
                                PD.CategoryID = IDCat;
                            }

                            Console.Write("\n Cantidad: ");
                            PD.QuantityPerUnit = Console.ReadLine();

                            Console.Write("\n Precio: ");
                            PD.UnitPrice = decimal.Parse(Console.ReadLine());

                            Console.Write("\n Unidades disponibles: ");
                            PD.UnitsInStock = short.Parse(Console.ReadLine());

                            Console.Write("\n Unidades pedidas: ");
                            PD.UnitsOnOrder = short.Parse(Console.ReadLine());

                            Console.WriteLine("\n Estamos procesando su petición.................\n");
                            pd.Agregar<Products>(PD);
                            break;

                        case 1:
                            Console.Clear();
                            Console.Write("\n Ingrese el código del producto que desea actualizar: ");
                            while (!int.TryParse(Console.ReadLine(), out IDProd))
                            {
                                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                            }
                            Console.WriteLine("\n Estamos procesando su búsqueda.................\n");
                            while (!pd.Listado<Products>().Exists(p => p.ProductID == IDProd))
                            {
                                Console.Write("\n Este código no pertenece a ningún producto registrado. Intente nuevamente: ");
                                IDProd = int.Parse(Console.ReadLine());
                            }
                            var resultPROD = pd.Listado<Products>().Find(r => r.ProductID == IDProd);
                            if (resultPROD != null && cd.Listado<Products>().Exists(d => d.ProductID == IDProd))
                            {
                                var pdNombre = pd.Model.Products.Where(pr => pr.ProductID == IDProd).Select(pt => pt).FirstOrDefault();
                                Console.Write("\n Producto: " + pdNombre.ProductName);
                                Console.Write("\n");
                                Console.Write("\n ------------------- ¿Qué desea modificar de este producto? -------------------");
                                Console.Write("\n 1) Nombre");
                                Console.Write("\n 2) Unidades disponibles");
                                Console.Write("\n 3) Precio");
                                Console.Write("\n Ingrese el dígito de la opción que desea modificar: ");

                                while (!int.TryParse(Console.ReadLine(), out SEL))
                                {
                                    Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                                }

                                switch (SEL)
                                {
                                    case 1:
                                        Console.Write("\n Ingrese el nuevo nombre de este producto: ");
                                        PD.ProductName = Console.ReadLine();
                                        while (!Regex.IsMatch(PD.ProductName, @"[a-zA-Z]"))
                                        {
                                            Console.WriteLine("\n No se permiten números. Intente nuevamente: ");
                                            Console.Write("\n Ingrese el nuevo nombre de este producto: ");
                                            PD.ProductName = Console.ReadLine();
                                        }
                                        PD.ProductID = IDProd;
                                        var search = pd.Model.Products.Where(p => p.ProductID == IDProd).Select(m => m).FirstOrDefault();
                                        PD.CategoryID = search.CategoryID;
                                        PD.Discontinued = search.Discontinued;
                                        PD.QuantityPerUnit = search.QuantityPerUnit;
                                        PD.ReorderLevel = search.ReorderLevel;
                                        PD.SupplierID = search.SupplierID;
                                        PD.UnitPrice = search.UnitPrice;
                                        PD.UnitsInStock = search.UnitsInStock;
                                        PD.UnitsOnOrder = search.UnitsOnOrder;
                                        pd.Model.Entry(resultPROD).State = EntityState.Detached;
                                        pd.Actualizar<Products>(PD);
                                        break;

                                    case 2:
                                        Console.Write("\n Ingrese la nueva cantidad de unidades disponibles de este producto: ");
                                        PD.UnitsInStock = short.Parse(Console.ReadLine());
                                        PD.ProductID = IDProd;
                                        var search2 = pd.Model.Products.Where(p => p.ProductID == IDProd).Select(m => m).FirstOrDefault();
                                        PD.ProductName = search2.ProductName;
                                        PD.CategoryID = search2.CategoryID;
                                        PD.Discontinued = search2.Discontinued;
                                        PD.QuantityPerUnit = search2.QuantityPerUnit;
                                        PD.ReorderLevel = search2.ReorderLevel;
                                        PD.SupplierID = search2.SupplierID;
                                        PD.UnitPrice = search2.UnitPrice;
                                        PD.UnitsOnOrder = search2.UnitsOnOrder;
                                        pd.Model.Entry(resultPROD).State = EntityState.Detached;
                                        pd.Actualizar<Products>(PD);
                                        break;

                                    case 3:
                                        Console.Write("\n Ingrese el nuevo precio de este producto: ");
                                        PD.UnitPrice = decimal.Parse(Console.ReadLine());
                                        PD.ProductID = IDProd;
                                        var search3 = pd.Model.Products.Where(p => p.ProductID == IDProd).Select(m => m).FirstOrDefault();
                                        PD.ProductName = search3.ProductName;
                                        PD.CategoryID = search3.CategoryID;
                                        PD.Discontinued = search3.Discontinued;
                                        PD.QuantityPerUnit = search3.QuantityPerUnit;
                                        PD.ReorderLevel = search3.ReorderLevel;
                                        PD.SupplierID = search3.SupplierID;
                                        PD.UnitsInStock = search3.UnitsInStock;
                                        PD.UnitsOnOrder = search3.UnitsOnOrder;
                                        pd.Model.Entry(resultPROD).State = EntityState.Detached;
                                        pd.Actualizar<Products>(PD);
                                        break;
                                }
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write("\n Ingrese el código del producto que desea eliminar: ");
                            while (!int.TryParse(Console.ReadLine(), out IDProd))
                            {
                                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                            }
                            Console.WriteLine("\n Estamos procesando su búsqueda.................\n");
                            while (!pd.Listado<Products>().Exists(p => p.ProductID == IDProd))
                            {
                                Console.Write("\n Este código no pertenece a ningún producto registrado. Intente nuevamente: ");
                                IDProd = int.Parse(Console.ReadLine());
                            }
                            var resultPROD2 = pd.Listado<Products>().Find(a => a.ProductID == IDProd);
                            if (resultPROD2 != null && pd.Listado<Products>().Exists(p => p.ProductID == IDProd))
                            {
                                PD.ProductID = IDProd;
                                pd.Model.Entry(resultPROD2).State = EntityState.Detached;
                                pd.Eliminar<Products>(PD);
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write("\n");
                            ConsoleTable TablaMuestra = new ConsoleTable("Código", "Nombre", "Suplidor", "Categoría", "Cantidad", "Precio",
                     "Unidades en Stock", "Unidades pedidas");
                            foreach (Products PROD in pd.Listado<Products>())
                            {
                                TablaMuestra.AddRow(PROD.ProductID, PROD.ProductName, PROD.Suppliers.CompanyName, PROD.Categories.CategoryName, PROD.QuantityPerUnit,
                                    PROD.UnitPrice, PROD.UnitsInStock, PROD.UnitsOnOrder);
                            }
                            TablaMuestra.Write(Format.Minimal);
                            break;

                        case 4: return;
                    }
                    Console.Write("\n");
                    Console.WriteLine("\n Presione Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        static void MenuTerritory()
        {
            TerritoryData td = new TerritoryData();
            Territories TR = new Territories();

            RegionData rd = new RegionData();
            Region REG = new Region();
            int IDReg;
            string IDTer;

            bool execute = false;

            for (int k = 0; ;)
            {
                DrawMenuTerritory(k);
                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow: k--; break;
                    case ConsoleKey.DownArrow: k++; break;
                    case ConsoleKey.Enter: execute = true; break;
                }

                if (k < 0) k = 4; else if (k > 4) k = 0;

                if (execute)
                {
                    execute = false;
                    switch (k)
                    {
                        case 0:
                            Console.Clear();
                            Console.Write("\n Código: ");
                            TR.TerritoryID = Console.ReadLine();

                            Console.Write("\n Nombre: ");
                            TR.TerritoryDescription = Console.ReadLine();
                            while (!Regex.IsMatch(TR.TerritoryDescription, @"[a-zA-Z]"))
                            {
                                Console.WriteLine("\n No se permiten números. Intente nuevamente: ");
                                Console.Write("\n Nombre: ");
                                TR.TerritoryDescription = Console.ReadLine();
                            }
                            Console.Write("\n");
                            Console.Write("\n A continuación se presentan las regiones registradas, favor ingresar el código de la requerida para el nuevo territorio. Presione Enter. ");
                            Console.ReadLine();
                            ConsoleTable TablaRegiones = new ConsoleTable("Código", "Nombre");
                            foreach (Region RG in rd.Listado<Region>())
                            {
                                TablaRegiones.AddRow(RG.RegionID, RG.RegionDescription);
                            }
                            TablaRegiones.Write(Format.Alternative);
                            Console.Write("\n");

                            Console.Write("\n Código de la región: ");
                            while (!int.TryParse(Console.ReadLine(), out IDReg))
                            {
                                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
                            }
                            while (!rd.Listado<Region>().Exists(c => c.RegionID == IDReg))
                            {
                                Console.Write("\n Este código no corresponde a ninguna región registrada. Intente nuevamente: ");
                                IDReg = int.Parse(Console.ReadLine());
                            }
                            if (rd.Listado<Region>().Exists(c => c.RegionID == IDReg))
                            {
                                TR.RegionID = IDReg;
                            }
                            Console.WriteLine("\n Estamos procesando su petición.................\n");
                            td.Agregar<Territories>(TR);
                            break;

                        case 1:
                            Console.Clear();
                            Console.Write("\n Ingrese el código del territorio que desea actualizar: ");
                            IDTer = Console.ReadLine();
                            Console.WriteLine("\n Estamos procesando su búsqueda.................\n");
                            while (!td.Listado<Territories>().Exists(c => c.TerritoryID == IDTer))
                            {
                                Console.Write("\n Este código no pertenece a ningún territorio registrado. Intente nuevamente: ");
                                IDTer = Console.ReadLine();
                            }
                            var resultTER = td.Listado<Territories>().Find(a => a.TerritoryID == IDTer);
                            if (resultTER != null && td.Listado<Territories>().Exists(c => c.TerritoryID == IDTer))
                            {
                                var terNombre = td.Model.Territories.Where(tr => tr.TerritoryID == IDTer).Select(terr => terr).FirstOrDefault();
                                Console.Write("\n Territorio: " + terNombre.TerritoryDescription);
                                Console.Write("\n Ingrese el nuevo nombre de este territorio: ");
                                TR.TerritoryDescription = Console.ReadLine();
                                TR.TerritoryID = IDTer;
                                var search = td.Model.Territories.Where(t => t.TerritoryID == IDTer).Select(m => m).FirstOrDefault();
                                TR.RegionID = search.RegionID;

                                td.Model.Entry(resultTER).State = EntityState.Detached;
                                td.Actualizar<Territories>(TR);
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write("\n Ingrese el código del territorio que desea eliminar: ");
                            IDTer = Console.ReadLine();
                            Console.WriteLine("\n Estamos procesando su búsqueda.................\n");
                            while (!td.Listado<Territories>().Exists(c => c.TerritoryID == IDTer))
                            {
                                Console.Write("\n Este código no pertenece a ningún territorio registrado. Intente nuevamente: ");
                                IDTer = Console.ReadLine();
                            }
                            var resultTER2 = td.Listado<Territories>().Find(a => a.TerritoryID == IDTer);
                            if (resultTER2 != null && td.Listado<Territories>().Exists(c => c.TerritoryID == IDTer))
                            {
                                TR.TerritoryID = IDTer;
                                td.Model.Entry(resultTER2).State = EntityState.Detached;
                                td.Eliminar<Territories>(TR);
                            }
                            break;

                        case 3:
                            Console.Write("\n");
                            ConsoleTable TablaTerritorios = new ConsoleTable("Código", "Nombre", "Región");
                            foreach (Territories TERT in td.Listado<Territories>())
                            {
                                TablaTerritorios.AddRow(TERT.TerritoryID, TERT.TerritoryDescription, TERT.Region.RegionDescription);
                            }
                            TablaTerritorios.Write(Format.Alternative);
                            break;

                        case 4: return;
                    }
                    Console.Write("\n");
                    Console.WriteLine("\n Presione Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        static void CustomerCSV()
        {
            CustomerData cud = new CustomerData();
            Customers CUST = new Customers();
            List<Customers> CustomerList = new List<Customers>();
            NorthwindDBEntities db = new NorthwindDBEntities();

            ConsoleTable TablaCust = new ConsoleTable("Código", "Nombre");
            foreach (Customers List in cud.Listado<Customers>())
            {
                TablaCust.AddRow(List.CustomerID, List.ContactName);
            }
            TablaCust.Write(Format.Alternative);

            string RutaCSV = Properties.Settings.Default.RutaCSV;
            string[] lines = File.ReadAllLines(RutaCSV);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.Contains(","))
                {
                    var split = line.Split(',');
                    string id = split[0];
                    string CompName = split[1];
                    string ContName = split[2];
                    string ContTitle = split[3];
                    string Address = split[4];
                    string City = split[5];
                    string Region = split[6];
                    string PostalCode = split[7];
                    string Country = split[8];
                    string Phone = split[9];
                    string Fax = split[10];

                    CUST = new Customers();
                    CUST.CustomerID = id;
                    CUST.CompanyName = CompName;
                    CUST.ContactName = ContName;
                    CUST.ContactTitle = ContTitle;
                    CUST.Address = Address;
                    CUST.City = City;
                    CUST.Region = Region;
                    CUST.PostalCode = PostalCode;
                    CUST.Country = Country;
                    CUST.Phone = Phone;
                    CUST.Fax = Fax;
                    CustomerList.Add(CUST);
                }
            }

            foreach (Customers c in CustomerList)
            {
                if (db.Customers.Any(ct => ct.CustomerID == c.CustomerID))
                {
                    try
                    {
                        cud.Actualizar(c);
                    }
                    catch (Exception msj)
                    {
                        Console.WriteLine("\n\n  Ha ocurrido un error actualizando datos: " + msj.Message.ToString());
                    }
                }
                else
                {
                    try
                    {
                        cud.Agregar(c);
                    }
                    catch (Exception msj)
                    {
                        Console.WriteLine("\n\n  Ha ocurrido un error insertando datos: " + msj.Message.ToString());
                    }
                }
            }

            Console.Write("\n");
            Console.WriteLine("\n Presione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        static void FacturaTXT()
        {
            OrderData od = new OrderData();
            Orders ORDER = new Orders();

            OrderDetailData odetdat = new OrderDetailData();
            Order_Details ORDT = new Order_Details();

            int IDFact;

            Console.Write("\n A continuación se presentan todas las facturas creadas. Favor de tomar el código de la deseada para exportar en un archivo txt. Presione Enter.");
            Console.ReadLine();
            Console.Write("\n");
            ConsoleTable TablaDetallesPedidos = new ConsoleTable("Código del pedido", "Producto", "Precio", "Cantidad", "Descuento");
            foreach (Order_Details ORDET in odetdat.Listado<Order_Details>())
            {
                TablaDetallesPedidos.AddRow(ORDET.OrderID, ORDET.Products.ProductName, ORDET.UnitPrice, ORDET.Quantity, ORDET.Discount);
            }
            TablaDetallesPedidos.Write(Format.Alternative);
            Console.Write("\n Ingrese el código de la factura que desea exportar: ");

            while (!int.TryParse(Console.ReadLine(), out IDFact))
            {
                Console.Write("\n Sólo se permiten números. Intente nuevamente: ");
            }
            Console.WriteLine("\n Estamos procesando su búsqueda.................\n");
            while (!odetdat.Listado<Order_Details>().Exists(odt => odt.OrderID == IDFact))
            {
                Console.Write("\n Este código no pertenece a ningua factura registrada. Intente nuevamente: ");
                IDFact = int.Parse(Console.ReadLine());
            }
            var resultFact = odetdat.Listado<Order_Details>().Find(odt => odt.OrderID == IDFact);

            if (resultFact != null && odetdat.Listado<Order_Details>().Exists(ordt => ordt.OrderID == IDFact))
            {
                odetdat.TotalProductos = 0;
                odetdat.TotalFactura = 0;
                ConsoleTable TablaFacturas = new ConsoleTable("Producto", "Precio", "Cantidad", "Importe");
                foreach (Order_Details ORDEN in odetdat.Listado<Order_Details>().Where(ordt => ordt.OrderID == IDFact))
                {
                    odetdat.TotalProductos = odetdat.TotalProductos + ORDEN.Quantity;
                    odetdat.Importe = ORDEN.Quantity * ORDEN.UnitPrice;
                    odetdat.TotalFactura = odetdat.TotalFactura + odetdat.Importe;
                    TablaFacturas.AddRow(ORDEN.Products.ProductName, ORDEN.UnitPrice, ORDEN.Quantity, odetdat.Importe);
                }
                TablaFacturas.Write(Format.Alternative);
                Console.Write("\n Total de artículos: ".PadRight(10) + odetdat.TotalProductos + "\t" + "Total a pagar: RD$".PadRight(15) + odetdat.TotalFactura);
                Console.Write("\n");
                var custNombre = odetdat.Model.Orders.Where(or => or.OrderID == IDFact).Select(pt => pt).FirstOrDefault();

                string ruta = Properties.Settings.Default.ArchivoTxt;
                try
                {
                    StreamWriter sw = new StreamWriter(ruta);
                    sw.Write("\n Cliente: ".PadRight(10) + custNombre.Customers.CompanyName);
                    sw.WriteLine("\n");
                    sw.WriteLine(TablaFacturas);
                    sw.WriteLine("\n");
                    sw.Write("\n Total de artículos: " + odetdat.TotalProductos + "\t" + "Total a pagar: RD$" + odetdat.TotalFactura);
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Orden de compra correcta. Vaya a la siguiente ruta de archivo para encontrar su recibo: ");
                    Console.WriteLine(ruta);
                }
                Console.ReadLine();
            }
            Console.Write("\n");
            Console.WriteLine("\n Presione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

