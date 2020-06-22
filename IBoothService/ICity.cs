using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothService
{
    public interface ICity
    {
        List<City> ShowProvince();
        List<City> ShowCity(object id);
        List<City> ShowArea(object id);
    } 
}
