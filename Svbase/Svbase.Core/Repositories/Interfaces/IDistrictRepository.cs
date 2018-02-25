﻿using System.Collections.Generic;
using Svbase.Core.Data.Entities;
using Svbase.Core.Models;
using Svbase.Core.Repositories.Abstract;

namespace Svbase.Core.Repositories.Interfaces
{
    public interface IDistrictRepository : IGenericRepository<District>
    {
        IEnumerable<DistrictListModel> GetAllDistricts();
        DashboardDistrictsModel GetDashboardDistrictsModel();

        IEnumerable<int> GetPersonsIdsByDistrictIds(IEnumerable<int> districtIds);
        //DistrictCreateModel GetDistrictById(int id);
        //IEnumerable<BaseViewModel> GetStretsBaseModelByDistrictIds(IList<int> districtIds);
    }
}
