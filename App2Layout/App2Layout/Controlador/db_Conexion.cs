using App2Layout.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App2Layout.Vistas;
using System.Collections.ObjectModel;



namespace App2Layout.Controlador
{
    public class db_Conexion
    {
        public SQLiteAsyncConnection _database;

        public db_Conexion(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Tarea>().Wait();
            _database.CreateTableAsync<TareasDelHogar>().Wait();
        }

        //Metodos para la tabla Tarea
        public Task<int> InsertItem(Tarea item)
        {
            return _database.InsertAsync(item);
        }


        public Task<List<Tarea>> GetItemsAsync()
        {
            return _database.Table<Tarea>().ToListAsync();
        }

        public Task<Tarea> GetItemAsync(int id)
        {
            return _database.Table<Tarea>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateItemAsync(Tarea item)
        {
            return _database.UpdateAsync(item);
        }

        public Task<int> DeleteItemAsync(Tarea item)
        {
            return _database.DeleteAsync(item);
        }
        // Métodos para la tabla TareasDelHogar
        public Task<int> InsertTareaDelHogar(TareasDelHogar item)
        {
            return _database.InsertAsync(item);
        }

        public Task<List<TareasDelHogar>> GetTareasDelHogarAsync()
        {
            return _database.Table<TareasDelHogar>().ToListAsync();
        }

        public Task<TareasDelHogar> GetTareaDelHogarAsync(int Id)
        {
            return _database.Table<TareasDelHogar>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateTareaDelHogarAsync(TareasDelHogar item)
        {
            return _database.UpdateAsync(item);
        }

        public Task<int> DeleteTareaDelHogarAsync(TareasDelHogar item)
        {
            return _database.DeleteAsync(item);
        }

    }
}
