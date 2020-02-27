using PokemonAPI.Enums;
using PokemonAPI.Factories.Interfaces;
using PokemonAPI.Services;
using PokemonAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonAPI.Factories
{
    public class DeserialiserFactory : IFactory, IDisposable
    {
        private bool disposedValue = false; // To detect redundant calls

        // TODO: Refactor to abide by OCP, currently a new deserialiser would require this class to be changed
        public IDeserialise Create(ApiResponseFormat Format)
        {
            switch (Format)
            {
                case ApiResponseFormat.JSON:
                    return new JsonDeserialise();
                default:
                    throw new ArgumentException("Invalid argument");
            }
        }

        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DeserialiserFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
    }
}