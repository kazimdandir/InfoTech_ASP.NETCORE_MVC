﻿namespace InfoTechCoreMVCQuiz26052024.Models
{
    public static class Repository
    {
        public static List<Product> products;
        public static List<UserClaim> users;

        static Repository()
        {
            users = new List<UserClaim>
        {
            new UserClaim { UserID = 1, UserName = "Emma", UserLastName = "Richardson" },
            new UserClaim { UserID = 2, UserName = "James", UserLastName = "Campbell" },
            new UserClaim { UserID = 3, UserName = "Sophia", UserLastName = "Mitchell" },
            new UserClaim { UserID = 4, UserName = "Michael", UserLastName = "Turner" },
            new UserClaim { UserID = 5, UserName = "Olivia", UserLastName = "Brooks" }
        };

            products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Wireless Headphones", ProductPrice = 79.99, ProductStockQuantity = 150 },
            new Product { ProductID = 2, ProductName = "Smartwatch", ProductPrice = 129.99, ProductStockQuantity = 75 },
            new Product { ProductID = 3, ProductName = "Electric Kettle", ProductPrice = 39.99, ProductStockQuantity = 200 },
            new Product { ProductID = 4, ProductName = "Yoga Mat", ProductPrice = 24.99, ProductStockQuantity = 300 },
            new Product { ProductID = 5, ProductName = "Bluetooth Speaker", ProductPrice = 49.99, ProductStockQuantity = 120 }
        };
        }

        public static List<UserClaim> UserList()
        {
            return users;
        }

        public static List<Product> ProductList()
        {
            return products;
        }
    }

}
