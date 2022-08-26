using AutoMapper;
using DAL;
using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;


namespace BLL
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
            var data = mapper.Map<List<ReceiverModel>>(ReceiverDAL.Get());
            return data;
        }
        public static List<string> GetNames()
        {
            var data = ReceiverDAL.Get().Select(e => e.Name).ToList();
            return data;
        }
        public static void Add(ReceiverModel a)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Receiver, ReceiverModel>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Receiver>(a);
            ReceiverDAL.Add(data);
        }
    }
}