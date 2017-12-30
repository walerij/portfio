namespace portfio.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdoModel : DbContext
    {
        // Контекст настроен для использования строки подключения "AdoModel" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "portfio.Models.AdoModel" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "AdoModel" 
        // в файле конфигурации приложения.
        public AdoModel()
            : base("name=AdoModel")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Contacts>    PortfolioContacts { get; set; }
        public virtual DbSet<Photos>      PortfolioPhotos { get; set; }
        public virtual DbSet<Prices>      PortfolioPrices { get; set; }
        public virtual DbSet<SocialLinks> PortfolioSocialLinks { get; set; }
        public virtual DbSet<Topics>      PortfolioTopics { get; set; }
        public virtual DbSet<Users>       PortfolioUsers { get; set; }
        public virtual DbSet<Works>       PortfolioWorks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}