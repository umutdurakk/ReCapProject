﻿using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();

        IDataResult<Color> GetById(int colorId);

        IResult Insert(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
