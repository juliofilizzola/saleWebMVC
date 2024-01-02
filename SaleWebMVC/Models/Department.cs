using System.Collections.Generic;
namespace SaleWebMVC.Models;

public class Department {
    public int                 Id      { get; set; }
    public string              Name    { get; set; }
    public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

    public Department() { }

    public Department(int id, string name) {
        Id   = id;
        Name = name;
    }

    public void AddSeller(Seller seller) {
        Sellers.Add(seller);
    }

    public double TotalSales(DateTime initial, DateTime final) {
        return Sellers.Sum(seller => seller.TotalSales(initial, final));  // Sum() retorna a soma de todos os elementos da coleção.
                                                                            // Ou seja, retorna o total de vendas de todos os vendedores.
                                                                            // Ou seja, retorna o total de vendas de todos os departamentos.
                                                                            // Ou seja, retorna o total de vendas de todos os vendedores de todos os departamentos.
                                                                            // Ou seja, retorna o total de vendas de todos os vendedores de todos os departamentos.
                                                                            // Ou seja, retorna o total de vendas de todos os vendedores de todos os departamentos.
                                                                            // Ou seja, retorna o total de vendas de todos os vendedores de todos os departamentos.
                                                                            // Ou seja, retorna o total de vendas de todos os vendedores de todos os
    }

}