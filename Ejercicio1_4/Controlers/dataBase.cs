using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1_4.Models;
using SQLite;

namespace Ejercicio1_4.Controlers
{
   public class dataBase
    {
        readonly SQLiteAsyncConnection dBase;

        //Constructor con path
        public dataBase(string dbpaht) {
            dBase = new SQLiteAsyncConnection(dbpaht);
            dBase.CreateTableAsync<Photos>();
        }

        //Guardar un registro de photo
        public Task<int> savePhoto(Photos DatPhoto)
        {
            if (DatPhoto.Id != 0)
            {
                return dBase.UpdateAsync(DatPhoto);
            }
            else
            {
                return dBase.InsertAsync(DatPhoto);
            }
        }
        //Obtener toda información de la tabla Photos
        public Task<List<Photos>> getPhotos() {
            return dBase.Table<Photos>().ToListAsync();
        }

        //Obtener un registro de la tabla Photo
        public Task<Photos> getSinglePhoto(int id) {
            return dBase.Table<Photos>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    } 
}
