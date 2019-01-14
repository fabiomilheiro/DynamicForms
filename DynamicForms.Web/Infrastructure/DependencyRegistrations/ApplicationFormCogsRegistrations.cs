using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Json.Converters;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.ApplicationTransitions;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Fields;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Scoring.ScoreOutcomeMethods;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Validation;
using DynamicForms.Web.Infrastructure.Helpers;
using DynamicForms.Web.Infrastructure.Repositories;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class ApplicationFormCogsRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IApplicationFormContextService, ApplicationFormContextService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IApplicationRepository, ApplicationRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ApplicationFormContext>(
                new HierarchicalLifetimeManager(),
                new InjectionFactory(c => c.Resolve<IApplicationFormContextService>()
                    .RetrieveApplicationFormContext()));

            container.RegisterType<IFieldFactory, FieldFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<IModelStateValidator, ModelStateValidator>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFieldMappingOrchestrator, FieldMappingOrchestrator>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFieldMapperFactory, FieldMapperFactory>(new ContainerControlledLifetimeManager());

            container.RegisterType<ISubmitApplicationTransition, SubmitApplicationTransition>(new ContainerControlledLifetimeManager());
            container.RegisterType<IScoringOutcomeMethodFactory, ScoringOutcomeMethodFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<DefaultScoringOutcomeMethod>(new ContainerControlledLifetimeManager());
            container.RegisterType<IScoringPointsCalculator, ScoringPointsCalculator>(new ContainerControlledLifetimeManager());

            foreach (var fieldMapperType in GetFieldMapperTypes())
            {
                container.RegisterType(typeof(IFieldMapper), fieldMapperType, fieldMapperType.FullName, new ContainerControlledLifetimeManager());
            }
        }

        private IEnumerable<Type> GetFieldMapperTypes()
        {
            return GetType()
                .Assembly
                .GetTypes()
                .Where(t => typeof(IFieldMapper).IsAssignableFrom(t))
                .Where(t => t.IsConcreteClass())
                .ToList();
        }
    }
}