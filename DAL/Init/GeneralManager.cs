using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntities.Context;
using BlogEntities.Init;
using DAL.Base;
using StructureMap;

namespace DAL.Init
{
    public static class GeneralManager
    {
        public static void Initialize()
        {
            //Hook up the interception
            ObjectFactory.Initialize(
                x =>
                {
                    x.For<IUnitOfWorkFactory>().Use<EFUnitOfWorkFactory>();
                    x.For(typeof(IRepository<>)).Use(typeof(EFRepository<>));
                }
            );

            //Tell the concrete factory what EF model to use
            EFUnitOfWorkFactory.SetObjectContext(() => new BlogEntitiesContext());

            //Initialization of Database creation
            var context = new BlogEntitiesContext();

            //Creates Database & Seeds data
            Database.SetInitializer<BlogEntitiesContext>(new BlogEngineDBInitializer());

            //Checks current context, model, & connection for changes
            context.Database.Initialize(false);

            context.Dispose();

        }

        public static void Commit()
        {
            UnitOfWork.Commit();
        }

        public static void Dispose()
        {
            UnitOfWork.Current.Dispose();
        }

        public static void EndRequest(object sender, EventArgs e)
        {
            //Request cleanup
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }
}
