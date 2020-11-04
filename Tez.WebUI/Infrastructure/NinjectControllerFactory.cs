using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tez.BLL.Abstract;
using Tez.BLL.Concrete;
using Tez.DAL.Concrete.EntityFramework;

namespace Tez.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        IKernel ninjectkernel;
        public NinjectControllerFactory()
        {
            ninjectkernel = new StandardKernel(new NinjectSettings { LoadExtensions = true });
            AddBLLBindings();
        }

        private void AddBLLBindings()
        {
            TezContext tezContext = new TezContext();
            ninjectkernel.Bind<ITezManager>().To<TezManager>().WithConstructorArgument("projeDal", new EfTezDal(tezContext));
            ninjectkernel.Bind<ITezFikirManager>().To<TezFikirManager>().WithConstructorArgument("tezFikirDal", new EfTezFikirDal(tezContext));
            ninjectkernel.Bind<IDanismanManager>().To<DanismanManager>().WithConstructorArgument("danismanDal", new EfDanismanDal(tezContext));
            ninjectkernel.Bind<IFakulteManager>().To<FakulteManager>().WithConstructorArgument("fakulteDal", new EfFakulteDal(tezContext));
            ninjectkernel.Bind<IBolumManager>().To<BolumManager>().WithConstructorArgument("bolumDal", new EfBolumDal(tezContext));
            ninjectkernel.Bind<IProjeManager>().To<ProjeManager>().WithConstructorArgument("projeDal", new EfProjeDal(tezContext));
            ninjectkernel.Bind<IOgrenciManager>().To<OgrenciManager>().WithConstructorArgument("ogrenciDal", new EfOgrenciDal(tezContext));
            ninjectkernel.Bind<ICiktiManager>().To<CiktiManager>().WithConstructorArgument("ciktiDal", new EfCiktiDal(tezContext));

        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {

            return controllerType == null ? null : (IController)ninjectkernel.Get(controllerType);
        }

    }
}