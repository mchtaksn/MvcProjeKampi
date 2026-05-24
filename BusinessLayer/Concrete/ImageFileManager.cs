using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstact;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService

    {
        IimageFileDal _imagedfileDal;

        public ImageFileManager(IimageFileDal imagedfileDal)
        {
            _imagedfileDal = imagedfileDal;
        }

        public List<ImageFile> GetList()
        {
            return _imagedfileDal.List();
        }
    }
}
