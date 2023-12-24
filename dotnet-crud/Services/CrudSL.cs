using System;
using dotnet_crud.Repositories;

namespace dotnet_crud.Services
{
	public class CrudSL : ICrudSL
	{
		public readonly ICrudRL _curdRL;

		public CrudSL(ICrudRL _curdRL)
		{
			this._curdRL = _curdRL;
		}
    }
}

