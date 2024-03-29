﻿using DigitalVaccineRecord.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Interfaces
{
    public interface IVaccineRepository : IRepository<VaccineModel>
    {
        VaccineModel GetByDose(Guid doseId);
    }
}
