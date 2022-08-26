using AutoMapper;
using DAL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class ReceiverService
    {
        public static List<ReceiverModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Receiver, ReceiverModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ReceiverModel>>(DataAccessFactory.ReceiverDataAccess().Get());
            return data;
        }
        public static ReceiverModel Get(int id)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Receiver, ReceiverModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<ReceiverModel>(DataAccessFactory.ReceiverDataAccess().Get(id));
            return data;
        }
        public static List<string> GetNames()
        {
            var data = DataAccessFactory.ReceiverDataAccess().Get().Select(e => e.Name).ToList();
            return data;
        }
        public static void Add(ReceiverModel a)
        {
            var config = new MapperConfiguration(c =>
            {
               // c.CreateMap<Receiver, ReceiverModel>();
                c.CreateMap<ReceiverModel, Receiver>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Receiver>(a);
            DataAccessFactory.ReceiverDataAccess().Add(data);
        }

        public static void Edit(ReceiverModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Receiver, ReceiverModel>();
                c.CreateMap<ReceiverModel, Receiver>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Receiver>(a);
            DataAccessFactory.ReceiverDataAccess().Edit(data);
        }
        public static void Delete(ReceiverModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Receiver, ReceiverModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<int>(a);
            DataAccessFactory.ReceiverDataAccess().Delete(data);
        }
    }
}