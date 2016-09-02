using System;
using System.Collections.Generic;
using RainHyacinth.Inject;
using RainHyacinth.Kernel.Imp;
using RainHyacinth.Lite;
using RainHyacinth.Lite.Imp;

namespace RainHyacinth.BLL
{
    public class OrmModel : RainLite
    {
        public string Name { get; set; }
    }

    public class OrmMap : RainLiteMap<OrmModel>, IRainLiteMap
    {
        public OrmMap() : base()
        {
        }
    }

    public interface IOrmModelService
    {
        void Add(OrmModel model);
        void BeachAdd(IList<OrmModel> models);
        void Add(IList<OrmModel> models);
    }

    public class OrmModelService : IOrmModelService, IUintOfWorkDependencyInject
    {
        private Lazy<IRepository<OrmModel>> _repository;
        public OrmModelService(Lazy<IRepository<OrmModel>> repository)
        {
            _repository = repository;
        }

        public void Add(OrmModel model)
        {
            _repository.Value.Add(model);
            _repository.Value.Context.SaveChanges();
        }

        public void BeachAdd(IList<OrmModel> models)
        {
            _repository.Value.AddBeachAsync(models);
        }
        public void Add(IList<OrmModel> models)
        {
            foreach (var model in models)
            {
                _repository.Value.Add(model);
            }
            _repository.Value.Context.SaveChanges();
        }
    }

    public class ServicesHelper
    {
        private ServicesHelper()
        {
        }
        public static ServicesHelper Instance = new ServicesHelper();
        public IOrmModelService TestService => KernelManager.Instance.DependencyInjectHub.Resolve<IOrmModelService>();
    }
}
