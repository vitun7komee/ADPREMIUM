﻿using AUTODEALERN.DAL;
using AUTODEALERN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTODEALERN.Interface
{
    internal class OrderInterface
    {
        private readonly ADDBStorage _dbStorage;

        public OrderInterface(ADDBStorage dbStorage)
        {
            _dbStorage = dbStorage;
        }
        public void AddOrder() 
        {
            Console.WriteLine("Добавление нового заказа:");

            DateTime orderDateTime = DateTime.Now;   

            Console.WriteLine("Доступные продавцы (ID):");
            foreach (var employee in _dbStorage.GetAllSalesmans())
            {
                Console.WriteLine($"ID: {employee.SalesmanId}, Имя: {employee.Name}, Должность: {employee.Position}, Контактная информация: {employee.ContactInfo}");
            }

            Console.Write("Введите ID продавца: ");
            int employeeId;
            if (!int.TryParse(Console.ReadLine(), out employeeId))
            {
                Console.WriteLine("Некорректный ID продавца.");
                return;
            }

            //Console.WriteLine("Клиенты (ID):");
            ////foreach (var client in _dbStorage.GetNewClients())
            //foreach (var client in _dbStorage.GetAllClients())// Вывод информации о доступных столах с доступными ID
            //{
            //    Console.WriteLine($"ID: {client.ClientId}, Номер Клиента: {client.ClientNumber}, Имя клиента: {client.Name}");
            //}

            Console.WriteLine(" Новый клиент? ");
            Console.WriteLine(" 1. Да / 2. Нет ");
            string actionChoicE = Console.ReadLine();
            switch (actionChoicE)
            {
                case "1":
                    Console.WriteLine("Введите имя нового клиента:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Введите номер нового клиента:");
                   
                    string number = Console.ReadLine();

                    long.TryParse(number, out long Number);
                   


                    Client newClient = new Client 
                    {
                        Name = name,
                        ClientNumber = Number
                     
                    };

                    _dbStorage.CreateClient(newClient);
                    Console.WriteLine("Клиент успешно добавлен.");
                    break;
            }

            Console.WriteLine("Клиенты (ID):");
            foreach (var client in _dbStorage.GetAllClients())// Вывод информации о доступных клиентах
            {
                Console.WriteLine($"ID: {client.ClientId}, Номер Клиента: {client.ClientNumber}, Имя клиента: {client.Name}");
            }

            Console.Write("Введите ID клиента: ");
            int clientId;
            if (!int.TryParse(Console.ReadLine(), out clientId))
            {
                Console.WriteLine("Некорректный ID клиента.");
                return;
            }

            Console.WriteLine("Доступные автомобили (ID):");
            foreach (var menuItem in _dbStorage.GetAllMenuItems())// Вывод информации о доступных блюдах с доступными ID
            {
                Console.WriteLine($"ID: {menuItem.MenuItemId}, Марка: {menuItem.Name}, Модель: {menuItem.Description}, Цена: {menuItem.Price} rub, Категория: {menuItem.Category}");
            }

            Console.Write("Введите ID автомобиля: ");
            int menuItemId;
            if (!int.TryParse(Console.ReadLine(), out menuItemId))
            {
                Console.WriteLine("Некорректный ID автомобиля.");
                return;
            }

            Order newOrder = new Order
            {
                OrderDateTime = orderDateTime,
                EmployeeId = employeeId,
                ClientId = clientId,
                MenuItemId = menuItemId,
  
            };

            _dbStorage.CreateOrder(newOrder);

            Console.WriteLine("Заказ успешно добавлен.");
        }

        public void DisplayAllOrdersInfo()// Метод для отображения информации о всех заказах
        {
            List<Order> orders = _dbStorage.GetAllOrders().ToList(); 

            Console.WriteLine("Информация о заказах:");

            foreach (var order in orders)
            {
                
                Salesman employee = _dbStorage.GetSalesmanById(order.EmployeeId);
                Client client = _dbStorage.GetClientById(order.ClientId);
                MenuItem menuItem = _dbStorage.GetMenuItemById(order.MenuItemId);
                // Вывод информации о заказе
                Console.WriteLine($"ID заказа: {order.OrderId}");
                Console.WriteLine($"Продавец: {employee.Name}");
                Console.WriteLine($"Номер телефона Клиента: {client.ClientNumber}, Имя клиента: {client.Name}");
                Console.WriteLine($"Марка: {menuItem.Name}, Модель: {menuItem.Description}, Цена: {menuItem.Price} rub");
                Console.WriteLine();
            }
        }

        public void RemoveOrder()
        {
            Console.WriteLine("Введите ID заказа для удаления:");
            if (int.TryParse(Console.ReadLine(), out int OrderId))
            {
                _dbStorage.DeleteOrder(OrderId);
                Console.WriteLine("Заказ успешно удален.");
            }
            else
            {
                Console.WriteLine("Некорректный ID Заказа.");
            }
        }

    }
}
