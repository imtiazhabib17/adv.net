using AutoMapper;
using DAL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL
{
    public class DonarService
    {
        public static List<DonarModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Donar, DonarModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<DonarModel>>(DataAccessFactory.DonarDataAccess().Get());
            return data;
        }
        public static DonarModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Donar, DonarModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<DonarModel>(DataAccessFactory.DonarDataAccess().Get(id));
            return data;
        }
        public static List<string> GetNames()
        {
            var data = DataAccessFactory.DonarDataAccess().Get().Select(e => e.Name).ToList();
            return data;
        }
        public static void Add(DonarModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                //c.CreateMap<Donar, DonarModel>();
                c.CreateMap<DonarModel, Donar>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Donar>(a);
            DataAccessFactory.DonarDataAccess().Add(data);
           
             
        }

        public static void Edit(DonarModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Donar, DonarModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Donar>(a);
            DataAccessFactory.DonarDataAccess().Edit(data);
        }
        public static void Delete(DonarModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Donar, DonarModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<int>(a);
            DataAccessFactory.DonarDataAccess().Delete(data);
        }

    }
}