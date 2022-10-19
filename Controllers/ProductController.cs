using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;

namespace WebCRUDMVCSQL.Controllers
{
    public class ProductsController : Controller
    {
        // SALVAR PRODUTO //
        [HttpPost ("/saveproduct")]
       public static async Task <string> SaveProduct ([FromBody]Product product)
        {
            using (var db = new BancoDeDados()) 
            {
                var products = new Product() {Id = 1, Name = "teste"};
                db.Products.Add(product);
                await db.SaveChangesAsync();
            } 
            return "Produto salvo com sucesso";
        }

        // RECEBER PRODUTO //
        [HttpGet ("/getproduct/{Id}")]
       public static async Task <Product> GetProduct ([FromRoute]int Id)
        {
            using (var db = new BancoDeDados()) 
            {
                Product product = db.Products.Find(Id);
                db.Products.Update(product);
                await db.SaveChangesAsync();
                return product;
            }
        }

        // EDITAR PRODUTO //
        [HttpPut ("/editproduct")]
       public static async Task<String> EditProduct ([FromBody]Product product)
        {
            using (var db = new BancoDeDados()) 
            {
               var products = new Product();
                db.Products.Update(product);
                await db.SaveChangesAsync();
                return "Produto editado com sucesso";
            } 
        }

        // DELETAR PRODUTO //
        [HttpDelete ("/deleteproduct/{Id}")]
       public static async Task<string> DeleteProduct ([FromRoute]int Id)
        {   
            using (var db = new BancoDeDados()) 
            {
                Product product = db.Products.Find(Id);
                db.Products.Remove(product);
                db.SaveChanges();
                return "Produto deletado com sucesso";
            }
        }


        public class PgProductController : Controller
    {
        // SALVAR PRODUTO PG //
        [HttpPost ("/saveproduct")]
       public static async Task <string> SaveProduct ([FromBody]Product product)
        {
            using (var pg = new bancoGres()) 
            {
                var products = new Product();
                pg.products.Add(product);
                await pg.SaveChangesAsync();
            } 
            return "Produto salvo com sucesso";
        }

        // RECEBER PRODUTO PG //
        [HttpGet ("/getproduct/{Id}")]
       public static async Task <Product> GetProduct ([FromRoute]int Id)
        {
            using (var pg = new bancoGres()) 
            {
                Product product = pg.products.Find(Id);
                pg.products.Update(product);
                await pg.SaveChangesAsync();
                return product;
            }
        }

        // EDITAR PRODUTO PG //
        [HttpPut ("/editproduct")]
       public static async Task<String> EditProduct ([FromBody]Product product)
        {
            using (var pg = new bancoGres()) 
            {
               var products = new Product();
                pg.products.Update(product);
                await pg.SaveChangesAsync();
                return "Produto editado com sucesso";
            } 
        }

        // DELETAR PRODUTO PG //
        [HttpDelete ("/deleteproduct/{Id}")]
       public static async Task<string> DeleteProduct ([FromRoute]int Id)
        {   
            using (var pg = new bancoGres()) 
            {
                Product product = pg.products.Find(Id);
                pg.products.Remove(product);
                pg.SaveChanges();
                return "Produto deletado com sucesso";
            }
        }
    }
}
    }
