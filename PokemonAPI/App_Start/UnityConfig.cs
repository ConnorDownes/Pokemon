using AutoMapper;
using PokemonAPI.App_Start.MappingConfigurations;
using PokemonAPI.Factories;
using PokemonAPI.Factories.Interfaces;
using PokemonAPI.Repositories;
using PokemonAPI.Repositories.Interfaces;
using PokemonAPI.Services;
using PokemonAPI.Services.Interfaces;
using System;

using Unity;

namespace PokemonAPI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.AddProfile<PokemonProfile>();
            });

            IMapper mapper = config.CreateMapper();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IFactory, DeserialiserFactory>();
            container.RegisterType<IApiService, HTTPClientService>();
            container.RegisterType<IPokeApiRepository, PokeApiRepository>();
            container.RegisterInstance(mapper);
        }
    }
}