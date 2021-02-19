using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal:ICarDal  
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 250, ModelYear = "2018", Description = "BMW"},
                new Car{Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 350, ModelYear = "2021", Description = "AUDI"},
                new Car{Id = 3, BrandId = 3, ColorId = 2, DailyPrice = 450, ModelYear = "2021", Description = "MERCEDES"}
            };
        }


        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
          return  _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetByColorId(int colorId)
        {
           return _cars.Where(p => p.ColorId == colorId).ToList();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(carToDelete);
        }
    }
}
