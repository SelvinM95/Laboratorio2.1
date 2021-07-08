using LaboratorioFirma.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioFirma.Modelos
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Datos>().Wait();
        }

        //Guardar Datos
        public Task<int> SaveDatosAsync(Datos datos)
        {
            if (datos.id != 0)
            {
                return db.UpdateAsync(datos);
            }
            else
            {
                return db.InsertAsync(datos);
            }
        }

        //Muestar todos los datos de la BD
        public Task<List<Datos>> GetDatosAsync()
        {
            return db.Table<Datos>().ToListAsync();
        }

        //Muestar todos los datos de la BD por ID
        public Task<Datos> GetDatosByIdAsync(int id)
        {
            return db.Table<Datos>().Where(a => a.id == id).FirstOrDefaultAsync();
        }

        //Borrar datos
        public Task<int> DeleteDatosAsync(Datos datos)
        {
            return db.DeleteAsync(datos);
        }

    }
} 
