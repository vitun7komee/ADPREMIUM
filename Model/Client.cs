using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTODEALERN.Model
{
    public class Client
    {
        public int ClientId { get; set; }// Свойство для идентификатора клиента

        [Required]// поле обязательно для заполнения
        public long ClientNumber { get; set; } 
    
        [Required]
        public string Name { get; set; }



        public virtual ICollection<Order> Orders { get; set; }// Виртуальное свойство для связи с заказами

        public Client()// Конструктор класса, инициализирующий коллекцию заказов
        {
            Orders = new List<Order>();
        }
    }
}
